using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbFatigue : MonoBehaviour
{
    public static GameObject ThumbTip;
    GameObject ThumbDistal;
    GameObject ThumbProximal;
    GameObject ThumbDistal1;
    GameObject ThumbProximal1;
    private Color CubeColor;



    int yes = 0;

    // Start is called before the first frame update
    void Start()
    {
        ThumbTip = GameObject.Find("ThumbTip");
        ThumbTip.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
        CubeColor = ThumbTip.GetComponent<Renderer>().material.GetColor("_Color");

        ThumbDistal1 = ThumbTip.transform.Find("ThumbDistal1").gameObject;
        ThumbDistal = ThumbTip.transform.Find("ThumbDistal").gameObject;
        ThumbProximal = ThumbTip.transform.Find("ThumbProximal").gameObject;
       
        ThumbProximal1= ThumbTip.transform.Find("ThumbProximal1").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Juding.KeyPress == 2)
        {
            yes = 0;
        }
        if (Juding.KeyPress == 3 && yes != 1)
        {
            DisplayForceFatigue();
            DisplayAngleFatigue();
            DisplayFatigue();
            //Debug.Log("red");
           // Debug.Log(Juding.LimitAngleSymbol[2]);
            yes = 1;
        }
    }
    public void DisplayForceFatigue()
    {
        if (Juding.LimitForceSymbol[0] > 0)
        {
            ThumbDistal1.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        if (Juding.LimitForceSymbol[1] > 0)
        {
            ThumbProximal1.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
    /// <summary>
    /// 极限力损伤，对应指示红色
    /// </summary>
    public void DisplayAngleFatigue()
    {
       
        if(Juding.LimitAngleSymbol[0]>0)
        {
            ThumbDistal.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (Juding.LimitAngleSymbol[1] > 0)
        {
            ThumbProximal.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    public void DisplayFatigue()
    {
        if (Juding.FatigueSymbol[0] > Juding.FatigueRange)
        {
            ThumbTip.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }

    public void ResetColor()
    {
       
       ThumbTip.GetComponent<MeshRenderer>().material.color = CubeColor;
       ThumbDistal.GetComponent<MeshRenderer>().material.color = CubeColor;
       ThumbProximal.GetComponent<MeshRenderer>().material.color = CubeColor; 
       ThumbDistal1.GetComponent<MeshRenderer>().material.color = CubeColor; 
       ThumbProximal1.GetComponent<MeshRenderer>().material.color = CubeColor; 
 

    }
}
