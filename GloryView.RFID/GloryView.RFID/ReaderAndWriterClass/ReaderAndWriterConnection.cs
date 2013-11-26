using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModuleTech;
using System.Windows;
using GloryView.RFID.UserManager.IU;
using GloryView.RFID.DeviceMigrations;
using GloryView.RFID.PageControl;
using System.Windows.Controls;
using System.Diagnostics;
using System.Threading;
using ModuleTech.Gen2;
using ModuleLibrary;
using System.Text.RegularExpressions;
using GloryView.RFID.Utilities;

namespace GloryView.RFID.ReaderAndWriterClass
{
    public class ReaderAndWriterConnection
    {
        public Reader modulerdr = null;
        delegate void ReconnectHandler(Exception ex);
        string sourceip;
        delegate void OpFailedHandler(Exception ex);
        public ReaderParams rParms = new ReaderParams(200, 300, 1);
        delegate void AutoStopReaderHandler();
        /************************************************************************/
        /* 读写器连接方法                                                                     */
        /************************************************************************/
        public int Connection()
        {


            if (modulerdr != null)
            {
                modulerdr.Disconnect();
            }
            rParms.resetParams();
            sourceip = "com4".Trim();
            if (!"com4".Trim().ToLower().Contains("com"))
            {
                rParms.hasIP = true;
            }
            else
                rParms.hasIP = false;

            try
            {
               
                modulerdr = Reader.Create(sourceip, ModuleTech.Region.NA, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败，请检查读写器是否正常连接!" + ex.ToString());
                return BaseRequest.ERROR;
            }
            rParms.AntsState.Clear();
            rParms.readertype = modulerdr.HwDetails.logictype;
            if (modulerdr.HwDetails.module == Reader.Module_Type.MODOULE_M6E ||
                modulerdr.HwDetails.module == Reader.Module_Type.MODOULE_M6E_PRC
                || modulerdr.HwDetails.module == Reader.Module_Type.MODOULE_M6E_MICRO)
                rParms.isMultiPotl = true;

            if (modulerdr.HwDetails.board == Reader.MaindBoard_Type.MAINBOARD_WIFI)
                rParms.hasIP = false;

            if (modulerdr.HwDetails.logictype != ReaderType.MT_A7_16ANTS)
            {
                if (rParms.readertype != ReaderType.PR_ONEANT)
                {
                    int[] connectedants = (int[])modulerdr.ParamGet("ConnectedAntennas");

                }
            }
            else
            {
                this.rParms.SixteenDevConAnts = (int[])modulerdr.ParamGet("ConnectedAntennas");
                rParms.antcnt = 0;
            }
            if (rParms.readertype != ReaderType.PR_ONEANT)
            {
                //     Debug.WriteLine("before HardwareVersion");
                rParms.hardvir = (string)modulerdr.ParamGet("HardwareVersion");
                Debug.WriteLine("before SoftwareVersion");
                rParms.softvir = (string)modulerdr.ParamGet("SoftwareVersion");
            }
            else
            {
                rParms.hardvir = "pr9000";
                rParms.softvir = "pr9000";
                rParms.sleepdur = 50;
                rParms.readdur = 500;
            }
            Debug.WriteLine("before RfPowerMax");
            rParms.powermax = ((int)modulerdr.ParamGet("RfPowerMax")) / 100;
            rParms.powermin = ((int)modulerdr.ParamGet("RfPowerMin")) / 100;
            rParms.gen2session = (int)modulerdr.ParamGet("Gen2Session");
            rParms.fisrtLoad = true;
            return BaseRequest.SUCCESS;



        }
        /************************************************************************/
        /* 读取标签方法                                                                     */
        /************************************************************************/
        public string ReaderEPC()
        {
            Gen2TagFilter filter = null;

            modulerdr.ParamSet("AccessPassword", (uint)0);

            ushort[] readdata = null;
            try
            {
                int index = 1;
                int st = Environment.TickCount;
                readdata = modulerdr.ReadTagMemWords(filter, (MemBank)index, 2, 6);
                Debug.WriteLine("read dur :" + (Environment.TickCount - st).ToString());
                if (rParms.setGPO1)
                {
                    modulerdr.GPOSet(1, true);
                    System.Threading.Thread.Sleep(20);
                    modulerdr.GPOSet(1, false);
                }

            }
            catch (OpFaidedException notagexp)
            {
                if (notagexp.ErrCode == 0x400)
                    MessageBox.Show("没法发现标签");
                else
                    MessageBox.Show("操作失败:" + notagexp.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败:" + ex.ToString());
            }

            string readdatastr = "";
            for (int i = 0; i < readdata.Length; ++i)
                readdatastr += readdata[i].ToString("X4");
            return readdatastr;
            
        }
        /************************************************************************/
        /*写入标签方法                                                                      */
        /************************************************************************/
        public  int WritertEPC(string _EpcStr,Window win)
        {
            Gen2TagFilter filter = null;
            byte[] filterbytes = new byte[(_EpcStr.Length - 1) / 8 + 1];
            for (int c = 0; c < filterbytes.Length; ++c)
                filterbytes[c] = 0;

            int bitcnt = 0;
            foreach (Char ch in _EpcStr.Trim())
            {
                if (ch == '1')
                    filterbytes[bitcnt / 8] |= (byte)(0x01 << (7 - bitcnt % 8));
                bitcnt++;

            }
            //modulerdr.ParamSet("AccessPassword", (uint)0);

            if (IsValidHexstr(_EpcStr.Trim(), 600) != 0)
            {
                JXMessageBox.Show(win, "将要写入的数据是16进制的字符,且长度为4字符的整数倍", MsgImage.Error);
                return BaseRequest.ERROR;
            }
            try
            {
                modulerdr.WriteTag(filter, new TagData(_EpcStr.Trim()));
                JXMessageBox.Show(win, "写入标签成功!",MsgImage.Success);
            }
            catch (Exception ex)
            {
                JXMessageBox.Show(win, "写入标签失败，请检查设备是否正常状态!", MsgImage.Error);
                return BaseRequest.ERROR;
            }
            if (modulerdr != null)
            {
                modulerdr.Disconnect();
            }

            return BaseRequest.SUCCESS;

        }
        /************************************************************************/
        /* 获得16进制的标签字符串                                                                     */
        /************************************************************************/
        public static string getEPCCode(int id){

            ushort crc1 = 0;
            ushort crc2 = 0;
            ushort[] readdata = { 4096, 48, 56, 32, 0, 0 };
            crc1 = readdata[5];
            crc2 = readdata[4];
            readdata[5] = (ushort)(crc1 ^ id);
            id >>= 16;
            readdata[4] = (ushort)(crc2 ^ id);
            string readdatastr = "";
            for (int i = 0; i < readdata.Length; ++i)
            {
                readdatastr += readdata[i].ToString("X4");
            }


            return readdatastr;
        }
        /************************************************************************/
        /* 把16进制字符串转换成ushout数组                                                                     */
        /************************************************************************/
        public static ushort[] toUshortArray(string _Epc)
        {
            ushort[] data = Regex.Split(_Epc, @"(?<=\G\w{4})",
            RegexOptions.IgnorePatternWhitespace).Where(a => !string.IsNullOrEmpty(a)).
            Select(a => Convert.ToUInt16(a, 16)).ToArray();
            return data;
        }
        /************************************************************************/
        /* 验证16进制字符串是否合法                                                                     */
        /************************************************************************/
        public static int IsValidHexstr(string str, int len)
        {
            if (str == "")
                return -3;
            if (str.Length % 4 != 0)
                return -2;
            if (str.Length > len)
                return -4;
            string lowstr = str.ToLower();
            byte[] hexchars = Encoding.ASCII.GetBytes(lowstr);

            foreach (byte a in hexchars)
            {
                if (!((a >= 48 && a <= 57) || (a >= 97 && a <= 102)))
                    return -1;
            }
            return 0;
        }
    }

     

}
