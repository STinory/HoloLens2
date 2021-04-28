using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleFatigue : MonoBehaviour
{

    public static GameObject MiddleTip;
    GameObject MiddleDistal;
    GameObject MiddleMiddle;
    GameObject MiddleKnuckle;
    GameObject MiddleDistal1;
    GameObject MiddleMiddle1;
    GameObject MiddleKnuckle1;
    public int yes = 0;
    private Color CubeColor;

    // Start is called before the first frame update
    void Start()
    {
        MiddleTip = GameObject.Find("MiddleTip");
        MiddleTip.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
        CubeColor = MiddleTip.GetComponent<Renderer>().material.GetColor("_Color");
        MiddleDistal = MiddleTip.transform.Find("MiddleDistal").gameObject;
        MiddleMiddle = MiddleTip.transform.Find("MiddleMiddle").gameObject;
        MiddleKnuckle = MiddleTip.transform.Find("MiddleKnuckle").gameObject;
        MiddleDistal1 = MiddleTip.transform.Find("MiddleDistal1").gameObject;
        MiddleMiddle1 = MiddleTip.transform.Find("MiddleMiddle1").gameObject;
        MiddleKnuckle1 = MiddleTip.transform.Find("MiddleKnuckle1").gameObject;
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

        if (Juding.LimitForceSymbol[5] > 0)
        {
            MiddleDistal1.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        if (Juding.LimitForceSymbol[6] > 0)
        {
            MiddleMiddle1.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        if (Juding.LimitForceSymbol[7] > 0)
        {
            MiddleKnuckle1.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
    /// <summary>
    /// 极限角度损伤，对应指示红色
    /// </summary>
    public void DisplayAngleFatigue()
    {

        if (Juding.LimitAngleSymbol[5] > 0)
        {
            MiddleDistal.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (Juding.LimitAngleSymbol[6] > 0)
        {
            MiddleMiddle.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (Juding.LimitAngleSymbol[7] > 0)
        {
            MiddleKnuckle.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
    public void DisplayFatigue()
    {
        if (Juding.FatigueSymbol[2] > Juding.FatigueRange)
        {
            MiddleTip.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
    public void ResetColor()
    {

        MiddleTip.GetComponent<MeshRenderer>().material.color = CubeColor;
        MiddleDistal.GetComponent<MeshRenderer>().material.color = CubeColor;
        MiddleDistal1.GetComponent<MeshRenderer>().material.color = CubeColor;
        MiddleMiddle.GetComponent<MeshRenderer>().material.color = CubeColor;
        MiddleMiddle1.GetComponent<MeshRenderer>().material.color = CubeColor;
        MiddleKnuckle.GetComponent<MeshRenderer>().material.color = CubeColor;
        MiddleKnuckle1.GetComponent<MeshRenderer>().material.color = CubeColor;


    }
}