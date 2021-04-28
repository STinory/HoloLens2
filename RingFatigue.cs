using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingFatigue : MonoBehaviour
{

    public static GameObject RingTip;
    GameObject RingDistal;
    GameObject RingMiddle;
    GameObject RingKnuckle;
    GameObject RingDistal1;
    GameObject RingMiddle1;
    GameObject RingKnuckle1;
    public int yes = 0;
    private Color CubeColor;

    // Start is called before the first frame update
    void Start()
    {
        RingTip = GameObject.Find("RingTip");
       RingTip.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
        CubeColor =RingTip.GetComponent<Renderer>().material.GetColor("_Color");

        RingDistal = RingTip.transform.Find("RingDistal").gameObject;
        RingMiddle = RingTip.transform.Find("RingMiddle").gameObject;
        RingKnuckle = RingTip.transform.Find("RingKnuckle").gameObject;
        RingDistal1 = RingTip.transform.Find("RingDistal1").gameObject;
        RingMiddle1 = RingTip.transform.Find("RingMiddle1").gameObject;
        RingKnuckle1 = RingTip.transform.Find("RingKnuckle1").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (Juding.KeyPress == 3 && yes != 1)
        {

            DisplayForceFatigue();
            DisplayAngleFatigue();
            DisplayFatigue();
            // Debug.Log(Juding.LimitForceSymbol[ ]);
            yes = 1;
        }
    }
    public void DisplayForceFatigue()
    {

        if (Juding.LimitForceSymbol[8] > 0)
        {
            RingDistal1.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        if (Juding.LimitForceSymbol[9] > 0)
        {
            RingMiddle1.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        if (Juding.LimitForceSymbol[10] > 0)
        {
            RingKnuckle1.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
    /// <summary>
    /// 极限角度损伤，对应指示红色
    /// </summary>
    public void DisplayAngleFatigue()
    {

        if (Juding.LimitAngleSymbol[8] > 0)
        {
            RingDistal.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (Juding.LimitAngleSymbol[9] > 0)
        {
            RingMiddle.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (Juding.LimitAngleSymbol[10] > 0)
        {
            RingKnuckle.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
    public void DisplayFatigue()
    {
        if (Juding.FatigueSymbol[3] > Juding.FatigueRange)
        {
            RingTip.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
    public void ResetColor()
    {

        RingTip.GetComponent<MeshRenderer>().material.color = CubeColor;
        RingDistal.GetComponent<MeshRenderer>().material.color = CubeColor;
        RingDistal1.GetComponent<MeshRenderer>().material.color = CubeColor;
        RingMiddle.GetComponent<MeshRenderer>().material.color = CubeColor;
        RingMiddle1.GetComponent<MeshRenderer>().material.color = CubeColor;
        RingKnuckle.GetComponent<MeshRenderer>().material.color = CubeColor;
        RingKnuckle1.GetComponent<MeshRenderer>().material.color = CubeColor;


    }
}