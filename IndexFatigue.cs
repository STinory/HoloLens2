using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexFatigue : MonoBehaviour
{
    public static GameObject IndexTip;
    GameObject IndexDistal;
    GameObject IndexMiddle;
    GameObject IndexKnuckle;
    GameObject IndexDistal1;
    GameObject IndexMiddle1;
    GameObject IndexKnuckle1;
    public int yes = 0;
    private Color CubeColor;

    // Start is called before the first frame update
    void Start()
    {
        IndexTip = GameObject.Find("IndexTip");
        IndexTip.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
        CubeColor = IndexTip.GetComponent<Renderer>().material.GetColor("_Color");

        IndexDistal = IndexTip.transform.Find("IndexDistal").gameObject;
        IndexMiddle = IndexTip.transform.Find("IndexMiddle").gameObject;
        IndexKnuckle = IndexTip.transform.Find("IndexKnuckle").gameObject;
        IndexDistal1 = IndexTip.transform.Find("IndexDistal1").gameObject;
        IndexMiddle1 = IndexTip.transform.Find("IndexMiddle1").gameObject;
        IndexKnuckle1 = IndexTip.transform.Find("IndexKnuckle1").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Juding.KeyPress == 3&&yes!=1)
        {
            
            DisplayForceFatigue();
            DisplayAngleFatigue();
            DisplayFatigue();
           // Debug.Log(Juding.LimitForceSymbol[2]);
            yes = 1;
        }
    }
    public void DisplayForceFatigue()
    {

        if (Juding.LimitForceSymbol[2] > 0)
        {
            IndexDistal1.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        if (Juding.LimitForceSymbol[3] > 0)
        {
            IndexMiddle1.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        if (Juding.LimitForceSymbol[4] > 0)
        {
            IndexKnuckle1.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
    /// <summary>
    /// 极限角度损伤，对应指示红色
    /// </summary>
    public void DisplayAngleFatigue()
    {

        if (Juding.LimitAngleSymbol[2] > 0)
        {
           IndexDistal.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (Juding.LimitAngleSymbol[3] > 0)
        {
            IndexMiddle.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (Juding.LimitAngleSymbol[4] > 0)
        {
            IndexKnuckle.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    public void DisplayFatigue()
    {
        if (Juding.FatigueSymbol[1] > Juding.FatigueRange)
        {
           IndexTip.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }

    public void ResetColor()
    {

        IndexTip.GetComponent<MeshRenderer>().material.color = CubeColor;
        IndexDistal.GetComponent<MeshRenderer>().material.color = CubeColor;
        IndexDistal1.GetComponent<MeshRenderer>().material.color = CubeColor;
        IndexMiddle.GetComponent<MeshRenderer>().material.color = CubeColor;
        IndexMiddle1.GetComponent<MeshRenderer>().material.color = CubeColor;
        IndexKnuckle.GetComponent<MeshRenderer>().material.color = CubeColor;
        IndexKnuckle1.GetComponent<MeshRenderer>().material.color = CubeColor;


    }
}
