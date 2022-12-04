using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnable : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject light;

    public bool Action = false;
    private bool opened = false;
    // Start is called before the first frame update
    public void beginScript()
    {
        Action = true;
    }

    void Update()
    {


        if (Action)
        {
            if (opened)
            {
                light.GetComponent<Light>().enabled = false;
                opened = !opened;
            }
            else
            {
                light.GetComponent<Light>().enabled = true;
                opened = !opened;
            }
        }
        Action = false;


    }
}
