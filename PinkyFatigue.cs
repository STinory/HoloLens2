using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkyFatigue : MonoBehaviour
{
    public static GameObject PinkyTip;
    GameObject PinkyDistal;
    GameObject PinkyMiddle;
    GameObject PinkyKnuckle;
    GameObject PinkyDistal1;
    GameObject PinkyMiddle1;
    GameObject PinkyKnuckle1;
    public int yes = 0;
    private Color CubeColor;

    // Start is called before the first frame update
    void Start()
    {
        PinkyTip = GameObject.Find("PinkyTip ");
       PinkyTip.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
        CubeColor = PinkyTip.GetComponent<Renderer>().material.GetColor("_Color");

        PinkyDistal = PinkyTip.transform.Find("PinkyDistal").gameObject;
        PinkyDistal1 = PinkyTip.transform.Find("Cube").gameObject;
        PinkyMiddle1 = PinkyTip.transform.Find("PinkyMiddle1").gameObject;
        PinkyMiddle =PinkyTip.transform.Find("PinkyMiddle").gameObject;
        PinkyKnuckle1 = PinkyTip.transform.Find("PinkyKnuckle1").gameObject;
        PinkyKnuckle = PinkyTip.transform.Find("PinkyKnuckle").gameObject;
       
    
      
    }

    // Update is called once per frame
    void Update()
    {

        if (Juding.KeyPress == 3 && yes != 1)
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

        if (Juding.LimitForceSymbol[11] > 0)
        {
            PinkyDistal1.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        if (Juding.LimitForceSymbol[12] > 0)
        {
            PinkyMiddle1.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        if (Juding.LimitForceSymbol[13] > 0)
        {
            PinkyKnuckle1.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
    /// <summary>
    /// 极限角度损伤，对应指示红色
    /// </summary>
    public void DisplayAngleFatigue()
    {

        if (Juding.LimitAngleSymbol[11] > 0)
        {
            PinkyDistal.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (Juding.LimitAngleSymbol[12] > 0)
        {
            PinkyMiddle.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (Juding.LimitAngleSymbol[13] > 0)
        {
            PinkyKnuckle.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
    public void DisplayFatigue()
    {
        if (Juding.FatigueSymbol[4] > Juding.FatigueRange)
        {
            PinkyTip.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
    public void ResetColor()
    {

        PinkyTip.GetComponent<MeshRenderer>().material.color = CubeColor;
        PinkyDistal.GetComponent<MeshRenderer>().material.color = CubeColor; 
        PinkyDistal1.GetComponent<MeshRenderer>().material.color = CubeColor;
        PinkyMiddle.GetComponent<MeshRenderer>().material.color = CubeColor;
        PinkyMiddle1.GetComponent<MeshRenderer>().material.color = CubeColor;
        PinkyKnuckle.GetComponent<MeshRenderer>().material.color = CubeColor;
        PinkyKnuckle1.GetComponent<MeshRenderer>().material.color = CubeColor;
 

    }
}
