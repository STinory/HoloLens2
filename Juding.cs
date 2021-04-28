using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.Input;
using System.Net;
using Microsoft.MixedReality.Toolkit.Utilities;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.MixedReality.Toolkit.UI;

public class Juding : MonoBehaviour
{
    //存储位置信息List
    List<Vector3> ThumbTipList = new List<Vector3>();
    List<Vector3> ThumbDistalList = new List<Vector3>(); 
    List<Vector3> ThumbProximalList = new List<Vector3>();
    List<Vector3> ThumbMetacarpalList = new List<Vector3>();     //拇指关节数据  
    List<Vector3> IndexTipList = new List<Vector3>();
    List<Vector3> IndexDistalList = new List<Vector3>();
    List<Vector3> IndexMiddleList = new List<Vector3>();
    List<Vector3> IndexKnuckleList = new List<Vector3>();
    List<Vector3> IndexMetacarpalList = new List<Vector3>();//中指
    List<Vector3> MiddleTipList = new List<Vector3>();
    List<Vector3> MiddleDistalList = new List<Vector3>();
    List<Vector3> MiddleMiddleList = new List<Vector3>();
    List<Vector3> MiddleKnuckleList = new List<Vector3>();
    List<Vector3> MiddleMetacarpalList = new List<Vector3>();//食指
    List<Vector3> RingTipList = new List<Vector3>();
    List<Vector3> RingDistalList = new List<Vector3>();
    List<Vector3> RingMiddleList = new List<Vector3>();
    List<Vector3> RingKnuckleList = new List<Vector3>();
    List<Vector3> RingMetacarpalList = new List<Vector3>();//无名指
    List<Vector3> PinkyTipList = new List<Vector3>();
    List<Vector3> PinkyDistalList = new List<Vector3>();
    List<Vector3> PinkyMiddleList = new List<Vector3>();
    List<Vector3> PinkyKnuckleList = new List<Vector3>();
    List<Vector3> PinkyMetacarpalList = new List<Vector3>();//小指

    //存储速度信息List

    List<Vector3> VThumbTipList = new List<Vector3>();
    List<Vector3> VThumbDistalList = new List<Vector3>();
    List<Vector3> VThumbProximalList = new List<Vector3>();
    List<Vector3> VThumbMetacarpaltList = new List<Vector3>();     //拇指关节数据  
    List<Vector3> VIndexTipList = new List<Vector3>();
    List<Vector3> VIndexDistalList = new List<Vector3>();
    List<Vector3> VIndexMiddleList = new List<Vector3>();
    List<Vector3> VIndexKnuckleList = new List<Vector3>();
    List<Vector3> VIndexMetacarpalList = new List<Vector3>();//中指
    List<Vector3> VMiddleTipList = new List<Vector3>();
    List<Vector3> VMiddleDistalList = new List<Vector3>();
    List<Vector3> VMiddleMiddleList = new List<Vector3>();
    List<Vector3> VMiddleKnuckleList = new List<Vector3>();
    List<Vector3> VMiddleMetacarpalList = new List<Vector3>();//食指
    List<Vector3> VRingTipList = new List<Vector3>();
    List<Vector3> VRingDistalList = new List<Vector3>();
    List<Vector3> VRingMiddleList = new List<Vector3>();
    List<Vector3> VRingKnuckleList = new List<Vector3>();
    List<Vector3> VRingMetacarpalList = new List<Vector3>();//无名指
    List<Vector3> VPinkyTipList = new List<Vector3>();
    List<Vector3> VPinkyDistalList = new List<Vector3>();
    List<Vector3> VPinkyMiddleList = new List<Vector3>();
    List<Vector3> VPinkyKnuckleList = new List<Vector3>();
    List<Vector3> VPinkyMetacarpalList = new List<Vector3>();//小指

    //存储冲量信息List
    List<double> IThumbTipDistalList = new List<double>();
    List<double> IThumbDistalProximalList = new List<double>();
 //   List<double> IThumbProximalMetacarpalList = new List<double>(); /拇指指节数据  

    List<double> IIndexTipDistalList = new List<double>();
    List<double> IIndexDistalMiddleList = new List<double>();
    List<double> IIndexMiddleKnuckleList = new List<double>();
    //  List<double> IIndexKnuckleMetacarpalList = new List<double>();//食指

    List<double> IMiddleTipDistalList = new List<double>();
    List<double> IMiddleDistalMiddleList = new List<double>();
    List<double> IMiddleMiddleKnuckleList = new List<double>();
    // List<double> IMiddleKnuckleMetacarpalList = new List<double>();//中指

    List<double> IRingTipDistalList = new List<double>();
    List<double> IRingDistalMiddleList = new List<double>();
    List<double> IRingMiddleKnuckleList = new List<double>();
    //   List<double> IRingKnuckleMetacarpalList = new List<double>();//无名指

    List<double> IPinkyTipDistalList = new List<double>();
    List<double> IPinkyDistalMiddleList = new List<double>();
    List<double> IPinkyMiddleKnuckleList = new List<double>();
    //  List<double> IPinkyKnuckleMetacarpalList = new List<double>();//小指

    List<bool> ThumbFatigue = new List<bool>();
    List<bool> IndexFatigue = new List<bool>();
    List<bool> MiddleFatigue = new List<bool>();
    List<bool> RingFatigue = new List<bool>();
    List<bool> PinkyFatigue = new List<bool>();



    public static int KeyPress = 0;
    public const int FPS = 60;
    float dt = 5.0f / 60;
    public const int Period = 1;
    public const int PeriodFrame = FPS / 5 * Period;
    public float Mass = 1.0f;
    public static double FatigueRange = 0.3;  

    //极限力标记
    public static int[] LimitForceSymbol = new int[14];
    //极限角度标记
    public static int[] LimitAngleSymbol =new int[14];

    public static double[] FatigueSymbol = new double[7];
    

    //极限力值
    double LimitForceRange=1.5;
    //极限角度范围，第i个关节范围LimitAngleRange[i][0]~LimitAngleRange[i][1]，选14个关节判断，大拇指：Proximal，Distal；剩余四指：Knuckle，Middle，Distal；
    public  double[,] LimitAngleRange = new double[14,2]{{-30,90},{0,90},{-70,90},{0,90},{0,90},{-70,90},{0,90},{0,90},{-70,90},{0,90},{0,90},{-70,90},{0,90},{0,90}};
      

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (KeyPress == 1)
        {

            if (Time.frameCount % 5 == 0)
            {

                //读取拇指数据
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbDistalJoint, Handedness.Right, out MixedRealityPose ThumbDistalJointpose))
                {
                    ThumbDistalList.Add(ThumbDistalJointpose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbMetacarpalJoint, Handedness.Right, out MixedRealityPose ThumbMetacarpalJointpose))
                {
                    ThumbMetacarpalList.Add(ThumbMetacarpalJointpose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbProximalJoint, Handedness.Right, out MixedRealityPose ThumbProximalJointpose))
                {
                    ThumbProximalList.Add(ThumbProximalJointpose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out MixedRealityPose ThumbTippose))
                {
                    ThumbTipList.Add(ThumbTippose.Position);
                }
                //食指读取数据
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose IndexTippose))
                {
                    IndexTipList.Add(IndexTippose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexDistalJoint, Handedness.Right, out MixedRealityPose IndexDistalJointpose))
                {
                    IndexDistalList.Add(IndexDistalJointpose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMiddleJoint, Handedness.Right, out MixedRealityPose IndexMiddleJointpose))
                {
                    IndexMiddleList.Add(IndexMiddleJointpose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexKnuckle, Handedness.Right, out MixedRealityPose IndexKnucklepose))
                {
                    IndexKnuckleList.Add(IndexKnucklepose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMetacarpal, Handedness.Right, out MixedRealityPose IndexMetacarpalpose))
                {
                    IndexMetacarpalList.Add(IndexMetacarpalpose.Position);
                }
                //读取中指数据
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleDistalJoint, Handedness.Right, out MixedRealityPose MiddleDistalJointpose))
                {
                    MiddleDistalList.Add(MiddleDistalJointpose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleKnuckle, Handedness.Right, out MixedRealityPose MiddleKnucklepose))
                {
                    MiddleKnuckleList.Add(MiddleKnucklepose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMetacarpal, Handedness.Right, out MixedRealityPose MiddleMetacarpalpose))
                {
                    MiddleMetacarpalList.Add(MiddleMetacarpalpose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMiddleJoint, Handedness.Right, out MixedRealityPose MiddleMiddleJointpose))
                {
                    MiddleMiddleList.Add(MiddleMiddleJointpose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out MixedRealityPose MiddleTippose))
                {
                    MiddleTipList.Add(MiddleTippose.Position);
                }
                //读取无名指数据
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingDistalJoint, Handedness.Right, out MixedRealityPose RingDistalJointpose))
                {
                    RingDistalList.Add(RingDistalJointpose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingKnuckle, Handedness.Right, out MixedRealityPose RingKnucklepose))
                {
                    RingKnuckleList.Add(RingKnucklepose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMetacarpal, Handedness.Right, out MixedRealityPose RingMetacarpalpose))
                {
                    RingMetacarpalList.Add(RingMetacarpalpose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMiddleJoint, Handedness.Right, out MixedRealityPose RingMiddleJointpose))
                {
                    RingMiddleList.Add(RingMiddleJointpose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Right, out MixedRealityPose RingTippose))
                {
                    RingTipList.Add(RingTippose.Position);
                }
                //读取小指数据
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyDistalJoint, Handedness.Right, out MixedRealityPose PinkyDistalJointpose))
                {
                    PinkyDistalList.Add(PinkyDistalJointpose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyKnuckle, Handedness.Right, out MixedRealityPose PinkyKnucklepose))
                {
                    PinkyKnuckleList.Add(PinkyKnucklepose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMetacarpal, Handedness.Right, out MixedRealityPose PinkyMetacarpalpose))
                {
                    PinkyMetacarpalList.Add(PinkyMetacarpalpose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMiddleJoint, Handedness.Right, out MixedRealityPose PinkyMiddleJointpose))
                {
                    PinkyMiddleList.Add(PinkyMiddleJointpose.Position);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out MixedRealityPose PinkyTippose))
                {
                    PinkyTipList.Add(PinkyTippose.Position);
                }
            }
        }
        if (KeyPress == 2)
        {

            VelocityCalculateAllJoint();
            ImpulseCalculateAllJoint();
            AllLimitFroceTest();
            AllLimitAngleTest();
            AllFatigueTest();
            
            KeyPress = 3;
           
        } 
    }
/// <summary>
/// 获取按键按压次数
/// </summary>
    public void GetToggleValue()
    {
        bool value = this.GetComponent<Interactable>().IsToggled;
        //Debug.Log(value);
        if (value == true)
        {
            KeyPress = 1;
        }
        if (value == false && KeyPress == 1)
        {
            KeyPress = 2;
         
        }

    }

    /// <summary>
    /// 所有关节的速度计算集合
    /// </summary>
    public void VelocityCalculateAllJoint()
    {     
           Debug.Log("设定时间值"+dt);
        VelocityCalculateSingle(ThumbTipList, VThumbTipList);
        VelocityCalculateSingle(ThumbDistalList, VThumbDistalList);
        VelocityCalculateSingle(ThumbProximalList, VThumbProximalList);
        VelocityCalculateSingle(ThumbMetacarpalList, VThumbMetacarpaltList);
        VelocityCalculateSingle(IndexTipList, VIndexTipList);
        VelocityCalculateSingle(IndexDistalList, VIndexDistalList);
        VelocityCalculateSingle(IndexMiddleList, VIndexMiddleList);
        VelocityCalculateSingle(IndexKnuckleList, VIndexKnuckleList);
        VelocityCalculateSingle(IndexMetacarpalList, VIndexMetacarpalList);
        VelocityCalculateSingle(MiddleTipList, VMiddleTipList);
        VelocityCalculateSingle(MiddleDistalList, VMiddleDistalList);
        VelocityCalculateSingle(MiddleMiddleList, VMiddleMiddleList);
        VelocityCalculateSingle(MiddleKnuckleList, VMiddleKnuckleList);
        VelocityCalculateSingle(MiddleMetacarpalList, VMiddleMetacarpalList);
        VelocityCalculateSingle(RingTipList, VRingTipList);
        VelocityCalculateSingle(RingDistalList, VRingDistalList);
        VelocityCalculateSingle(RingMiddleList, VRingMiddleList);
        VelocityCalculateSingle(RingKnuckleList, VRingKnuckleList);
        VelocityCalculateSingle(RingMetacarpalList, VRingMetacarpalList);
        VelocityCalculateSingle(PinkyTipList, VPinkyTipList);
        VelocityCalculateSingle(PinkyDistalList, VPinkyDistalList);
        VelocityCalculateSingle(PinkyMiddleList, VPinkyMiddleList);
        VelocityCalculateSingle(PinkyKnuckleList, VPinkyKnuckleList);
        VelocityCalculateSingle(PinkyMetacarpalList, VPinkyMetacarpalList);


    }


    /// <summary>
    /// 所有关节的冲量计算集合
    /// </summary>
    public void ImpulseCalculateAllJoint()
        {
        ImpulseCalculateSingle(VThumbTipList, VThumbDistalList, IThumbTipDistalList);
        ImpulseCalculateSingle(VThumbDistalList, VThumbProximalList, IThumbDistalProximalList);

        ImpulseCalculateSingle(VIndexTipList,VIndexDistalList,IIndexTipDistalList);
        ImpulseCalculateSingle(VIndexDistalList, VIndexMiddleList, IIndexDistalMiddleList);
        ImpulseCalculateSingle(VIndexMiddleList, VIndexKnuckleList, IIndexMiddleKnuckleList);

        ImpulseCalculateSingle(VMiddleTipList, VMiddleDistalList, IMiddleTipDistalList);
        ImpulseCalculateSingle(VMiddleDistalList, VMiddleMiddleList, IMiddleDistalMiddleList);
        ImpulseCalculateSingle(VMiddleMiddleList, VMiddleKnuckleList, IMiddleMiddleKnuckleList);

        ImpulseCalculateSingle(VRingTipList, VRingDistalList, IRingTipDistalList);
        ImpulseCalculateSingle(VRingDistalList, VRingMiddleList, IRingDistalMiddleList);
        ImpulseCalculateSingle(VRingMiddleList, VRingKnuckleList, IRingMiddleKnuckleList);

        ImpulseCalculateSingle(VPinkyTipList, VPinkyDistalList, IPinkyTipDistalList);
        ImpulseCalculateSingle(VPinkyDistalList, VPinkyMiddleList, IPinkyDistalMiddleList);
        ImpulseCalculateSingle(VPinkyMiddleList, VPinkyKnuckleList, IPinkyMiddleKnuckleList);
    }

    /// <summary>
    /// 所有极限力判断集合
    /// </summary>
    public void AllLimitFroceTest()
    {
        Debug.Log("设定力值"+LimitForceRange);
        LimitForceTestSingle(IThumbTipDistalList, 1);
        LimitForceTestSingle(IThumbDistalProximalList, 2);
        LimitForceTestSingle(IIndexTipDistalList, 3);
        LimitForceTestSingle(IIndexDistalMiddleList, 4);
        LimitForceTestSingle(IIndexMiddleKnuckleList, 5);
        LimitForceTestSingle(IMiddleTipDistalList, 6);
        LimitForceTestSingle(IMiddleDistalMiddleList, 7);
        LimitForceTestSingle(IMiddleMiddleKnuckleList, 8);
        LimitForceTestSingle(IRingTipDistalList, 9);
        LimitForceTestSingle(IRingDistalMiddleList, 10);
        LimitForceTestSingle(IRingMiddleKnuckleList, 11);
        LimitForceTestSingle(IPinkyTipDistalList, 12);
        LimitForceTestSingle(IPinkyDistalMiddleList, 13);
        LimitForceTestSingle(IPinkyMiddleKnuckleList, 14);



    }


    /// <summary>
    /// 所有极限角度判断集合
    /// </summary>
    public void AllLimitAngleTest()
    {
        LimitAngleTestSingle(ThumbTipList, ThumbDistalList, ThumbProximalList, 1);
        LimitAngleTestSingle(ThumbDistalList, ThumbProximalList, ThumbMetacarpalList, 2);
        LimitAngleTestSingle(IndexTipList, IndexDistalList, IndexMiddleList, 3);
        LimitAngleTestSingle(IndexDistalList, IndexMiddleList, IndexKnuckleList, 4);
        LimitAngleTestSingle(IndexMiddleList, IndexKnuckleList,IndexMetacarpalList, 5);

        LimitAngleTestSingle(MiddleTipList, MiddleDistalList, MiddleMiddleList, 6);
        LimitAngleTestSingle(MiddleDistalList, MiddleMiddleList, MiddleKnuckleList, 7);
        LimitAngleTestSingle(MiddleMiddleList, MiddleKnuckleList, MiddleMetacarpalList, 8);
        LimitAngleTestSingle(RingTipList, RingDistalList, RingMiddleList, 9);
        LimitAngleTestSingle(RingDistalList, RingMiddleList, RingKnuckleList, 10);
        LimitAngleTestSingle(RingMiddleList, RingKnuckleList, RingMetacarpalList, 11);
        LimitAngleTestSingle(PinkyTipList, PinkyDistalList, PinkyMiddleList, 12);
        LimitAngleTestSingle(PinkyDistalList, PinkyMiddleList, PinkyKnuckleList, 13);
        LimitAngleTestSingle(PinkyMiddleList, PinkyKnuckleList, PinkyMetacarpalList,14);

        /*
        //   LimitAngleTestSingle(IndexTipList, IndexMiddleList, IndexDistalList, 3);
        for (int i = 0; i <14; i++)
        {
            Debug.Log("Angle" + i + " " + LimitAngleSymbol[i]);
        }
        */

    }


    public void AllFatigueTest()                                                //疲劳判断 7段指节
    {
        int n = IIndexTipDistalList.Count / PeriodFrame;
        double corrm = 0;

        for (int i = 1; i < n; i++)
        {
            double[] d1 = new double[PeriodFrame];
            double[] d2 = new double[PeriodFrame];
            double corrc;
            
            //
            for (int j = 0; j < PeriodFrame; j++)
            {
                d1[j] = IThumbDistalProximalList[(i - 1) * PeriodFrame + j];
                d2[j] = IThumbDistalProximalList[i * PeriodFrame + j];
            }
            corrc = Corrcoef(d1, d2);


            if (corrc >= -0.3 && corrc <= 0.3)
            {
                for (int j = 0; j < PeriodFrame; j++)
                {
                    ThumbFatigue.Add(false);
                }
            }
            else if (corrc > 0.3 || corrc < -0.3)
            {
                for (int j = 0; j < PeriodFrame; j++)
                {
                    ThumbFatigue.Add(true);
                }
            }

            //
            for (int j = 0; j < PeriodFrame; j++)
            {
                d1[j] = IIndexMiddleKnuckleList[(i - 1) * PeriodFrame + j];
                d2[j] = IIndexMiddleKnuckleList[i * PeriodFrame + j];
            }
            corrc = Corrcoef(d1, d2);


            if (corrc >= -0.3 && corrc <= 0.3)
            {
                for (int j = 0; j < PeriodFrame; j++)
                {
                    IndexFatigue.Add(false);
                }
            }
            else if (corrc > 0.3 || corrc < -0.3)
            {
                for (int j = 0; j < PeriodFrame; j++)
                {
                    IndexFatigue.Add(true);
                }
            }
            //
            for (int j = 0; j < PeriodFrame; j++)
            {
                d1[j] = IMiddleMiddleKnuckleList[(i - 1) * PeriodFrame + j];
                d2[j] = IMiddleMiddleKnuckleList[i * PeriodFrame + j];
            }
            corrc = Corrcoef(d1, d2);


            if (corrc >= -0.3 && corrc <= 0.3)
            {
                for (int j = 0; j < PeriodFrame; j++)
                {
                    MiddleFatigue.Add(false);
                }
            }
            else if (corrc > 0.3 || corrc < -0.3)
            {
                for (int j = 0; j < PeriodFrame; j++)
                {
                    MiddleFatigue.Add(true);
                }
            }
            //
            for (int j = 0; j < PeriodFrame; j++)
            {
                d1[j] = IRingMiddleKnuckleList[(i - 1) * PeriodFrame + j];
                d2[j] = IRingMiddleKnuckleList[i * PeriodFrame + j];
            }
            corrc = Corrcoef(d1, d2);


            if (corrc >= -0.3 && corrc <= 0.3)
            {
                for (int j = 0; j < PeriodFrame; j++)
                {
                    RingFatigue.Add(false);
                }
            }
            else if (corrc > 0.3 || corrc < -0.3)
            {
                for (int j = 0; j < PeriodFrame; j++)
                {
                    RingFatigue.Add(true);
                }
            }
            //
            for (int j = 0; j < PeriodFrame; j++)
            {
                d1[j] = IPinkyMiddleKnuckleList[(i - 1) * PeriodFrame + j];
                d2[j] = IPinkyMiddleKnuckleList[i * PeriodFrame + j];
            }
            corrc = Corrcoef(d1, d2);


            if (corrc >= -0.3 && corrc <= 0.3)
            {
                for (int j = 0; j < PeriodFrame; j++)
                {
                    PinkyFatigue.Add(false);
                }
            }
            else if (corrc > 0.3 || corrc < -0.3)
            {
                for (int j = 0; j < PeriodFrame; j++)
                {
                    PinkyFatigue.Add(true);
                }
            }
        }


        //

        int num = 0;
        for (int j = 0; j < ThumbFatigue.Count; j++)
        {
            if (ThumbFatigue[j] == true)
            {
                num++;
            }
        }
        FatigueSymbol[0] = (double) (num) / (n * PeriodFrame);
        Debug.Log(FatigueSymbol[0]);

        num = 0;
        for (int j = 0; j < IndexFatigue.Count; j++)
        {
            if (IndexFatigue[j] == true)
            {
                num++;
            }
        }
        FatigueSymbol[1] = (double)(num) / (n * PeriodFrame);
        Debug.Log(FatigueSymbol[1]);

        num = 0;
        for (int j = 0; j < MiddleFatigue.Count; j++)
        {
            if (MiddleFatigue[j] == true)
            {
                num++;
            }
        }
        FatigueSymbol[2] = (double)(num) / (n * PeriodFrame);
        Debug.Log(FatigueSymbol[2]);
        num = 0;
        for (int j = 0; j < RingFatigue.Count; j++)
        {
            if (RingFatigue[j] == true)
            {
                num++;
            }
        }
        FatigueSymbol[3] = (double)(num) / (n * PeriodFrame);
        Debug.Log(FatigueSymbol[3]);
        num = 0;
        for (int j = 0; j < PinkyFatigue.Count; j++)
        {
            if (PinkyFatigue[j] == true)
            {
                num++;
            }
        }
        FatigueSymbol[4] = (double)(num) / (n * PeriodFrame);
        Debug.Log(FatigueSymbol[4]);
    }

    /// <summary>
    /// 计算每个关节的速度，输入关节位置List，输出速度List
    /// </summary>
    /// <param name="HandJointList"></param>
    /// <param name="VHandJoint"></param>
    public void VelocityCalculateSingle(List<Vector3> HandJointList, List<Vector3> VHandJoint)  
    {

        for (int i = 1; i < HandJointList.Count; i++)
        {
            VHandJoint.Add(new Vector3((HandJointList[i].x - HandJointList[i-1].x)/dt, (HandJointList[i].y - HandJointList[i-1].y) / dt, (HandJointList[i].z - HandJointList[i-1].z) / dt));

        }
      
    }

        /// <summary>
        ///   计算指节冲量 输入相邻两个关节速度List，输出冲量List
        /// </summary>
    public void ImpulseCalculateSingle(List<Vector3> HandJointVelocity1, List<Vector3> HandJointVelocity2, List<double>HandJointImpulse)                                              
    {
        double xsubtract = 0;
        double ysubtract = 0;
        double zsubtract = 0;

        for (int i = 0; i < VIndexTipList.Count; i++)
        {
            xsubtract = Math.Pow((HandJointVelocity1[i].x - HandJointVelocity2[i].x),2);
            ysubtract = Math.Pow((HandJointVelocity1[i].y - HandJointVelocity2[i].y),2);
            zsubtract = Math.Pow((HandJointVelocity1[i].z - HandJointVelocity2[i].z),2);
          
            //Debug.Log( Mass * Math.Sqrt(xsubtract + ysubtract + zsubtract));
            HandJointImpulse.Add(Mass * Math.Sqrt(xsubtract + ysubtract + zsubtract));
          
        }
    }
    /// <summary>
    /// 判断极限力，输入关节冲量List和标志位
    /// </summary>
    /// <param name="ImpulseList"></param>
    /// <param name="j"></param>
    public void LimitForceTestSingle(List<double> ImpulseList,int j)
    {
        double Number = 0;
        double Num_Max = 0;
        for (int i=0;i<ImpulseList.Count;i++)
        {
            Number =ImpulseList[i]/dt;
            if (Number > Num_Max) Num_Max = Number;
         
            if(Number> LimitForceRange)
            {
                LimitForceSymbol[j-1]++;
                
            }

        }
        /*
        Debug.Log(Num_Max);
        Debug.Log("标志位" + j + "  " + LimitForceSymbol[j - 1]);
        */

    }
    /// <summary>
    /// 极限角度判断：若超过范围，标志位数组不为0
    /// 输入外关节位置List，中关节位置List，内关节位置List，极限角度标志位顺序数
    /// </summary>
    /// <param name="ExternalHandJointList"></param>
    /// <param name="MiddleHandJointList"></param>
    /// <param name="InternalHandJointList"></param>
    /// <param name="LimitAngleSymbolNumber"></param>
    public void LimitAngleTestSingle(List<Vector3> ExternalHandJointList,List<Vector3> MiddleHandJointList,List<Vector3> InternalHandJointList,int LimitAngleSymbolNumber )
    {
        for(int i=0;i<ExternalHandJointList.Count;i++)
        {
            Vector3 v1 = MiddleHandJointList[i] - InternalHandJointList[i];
            Vector3 v2 = ExternalHandJointList[i] - MiddleHandJointList[i];
            Vector3 n = Vector3.Cross(v1, v2).normalized;  
            
            if (AngleSigned(v1, v2, n) < LimitAngleRange[LimitAngleSymbolNumber-1,0] || AngleSigned(v1, v2, n) > LimitAngleRange[LimitAngleSymbolNumber-1,1])
            {
                LimitAngleSymbol[LimitAngleSymbolNumber-1]++;
                //Debug.Log("Angle" + (LimitAngleSymbolNumber-1) + ":  "+AngleSigned(v1, v2, n));
             
            }
         
        }
        
    }
    /// <summary>
    /// 计算带符号的角度，v1，v2为所求角度向量，n为两向量法向量
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n)       //带符号角度
    {
        return Mathf.Atan2(Vector3.Dot(n, Vector3.Cross(v1, v2)), Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
    }

    public static double Corrcoef(double[] d1, double[] d2)                  //相关系数
    {
        double xy = 0, x = 0, y = 0, xsum = 0, ysum = 0;
        double corrc;
        int m = d1.Length;
        for (int i = 0; i < m; i++)
        {
            xsum += d1[i];
            ysum += d2[i];
        }
        for (int i = 0; i < m; i++)
        {
            x += (m * d1[i] - xsum) * (m * d1[i] - xsum);
            y += (m * d2[i] - ysum) * (m * d2[i] - ysum);
            xy += (m * d1[i] - xsum) * (m * d2[i] - ysum);
        }
        corrc = Math.Abs(xy) / (Math.Sqrt(x) * Math.Sqrt(y));
        return corrc;
    }
}
