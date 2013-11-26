using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ModuleTech;
using System.Diagnostics;
using ModuleTech.Gen2;
using ModuleLibrary;

namespace GloryView.RFID.ReaderAndWriterClass
{
    public class ReaderParams
    {
        public ReaderParams(int rdur, int sdur, int sess)
        {
            readdur = rdur;
            sleepdur = sdur;
            gen2session = sess;
            isIpModify = false;
            isM5eModify = false;
            fisrtLoad = true;

            ip = "";
            subnet = "";
            gateway = "";
            macstr = "";
            hasIP = false;
            isGetIp = false;
            Gen2Qval = -2;
            isCheckConnection = false;
            isMultiPotl = false;
            antcnt = -1;
            isRevertAnts = false;
            weightgen2 = 30;
            weight180006b = 30;
            weightipx64 = 30;
            weightipx256 = 30;

            isIdtAnts = false;
            IdtAntsType = 0;
            DurIdtval = 0;
            AfterIdtWaitval = 0;

            FixReadCount = 0;
            isReadFixCount = false;
            isOneReadOneTime = false;

            usecase_ishighspeedblf = false;
            usecase_tagcnt = -1;
            usecase_readperform = -1;
            usecase_antcnt = -1;
        }

        public void resetParams()
        {
            isIpModify = false;
            isM5eModify = false;
            fisrtLoad = true;

            ip = "";
            subnet = "";
            gateway = "";
            macstr = "";
            hasIP = false;
            isGetIp = false;
            Gen2Qval = -2;
            isCheckConnection = false;
            isMultiPotl = false;
            antcnt = -1;
            SixteenDevsrp = null;
            SixteenDevConAnts = null;
            isRevertAnts = false;
            weightgen2 = 30;
            weight180006b = 30;
            weightipx64 = 30;
            weightipx256 = 30;

            isChangeColor = true;
            isUniByEmd = false;
            isUniByAnt = false;

            isIdtAnts = false;
            IdtAntsType = 0;
            DurIdtval = 0;
            AfterIdtWaitval = 0;

            FixReadCount = 0;
            isReadFixCount = false;
            isOneReadOneTime = false;

            usecase_ishighspeedblf = false;
            usecase_tagcnt = -1;
            usecase_readperform = -1;
            usecase_antcnt = -1;

        }

        public bool setGPO1;
        public int gen2session;
        public int readdur;
        public int sleepdur;
        public int antcnt;
        public string hardvir;
        public string softvir;
        public ReaderType readertype;

        public List<AntAndBoll> AntsState = new List<AntAndBoll>();
        public int ModuleReadervir;
        public string ip;
        public string subnet;
        public string gateway;
        public string macstr;
        public bool isGetIp;
        public bool isIpModify;
        public bool isM5eModify;
        public bool fisrtLoad;
        public bool hasIP;
        public int powermin;
        public int powermax;
        public int Gen2Qval;
        public bool isCheckConnection;
        public bool isMultiPotl;
        public SimpleReadPlan SixteenDevsrp = null;
        public int[] SixteenDevConAnts = null;
        public bool isRevertAnts;

        public int weightgen2;
        public int weight180006b;
        public int weightipx64;
        public int weightipx256;

        public bool isChangeColor;
        public bool isUniByEmd;
        public bool isUniByAnt;

        public bool isIdtAnts;
        public int IdtAntsType;
        public int DurIdtval;
        public int AfterIdtWaitval;

        public int FixReadCount;
        public bool isReadFixCount;
        public bool isOneReadOneTime;

        public bool usecase_ishighspeedblf;
        public int usecase_tagcnt;
        public int usecase_readperform;
        public int usecase_antcnt;

    }
}
