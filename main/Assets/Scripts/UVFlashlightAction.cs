using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVFlashlightAction : MonoBehaviour
{
    public Light myLight;

    public GameObject flashlight;
    public GameObject otherFlashlight;

    
    // Start is called before the first frame update
    void Start()
    {
        myLight = myLight.GetComponent<Light>();
    }

    public bool getLightState()
    {
        return myLight.enabled;
    }

    public void setLightState(bool state)
    {
        myLight.enabled = state;
    }

    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            print("uv flashlight was" + getLightState());
                if(otherFlashlight.GetComponent<FlashlightManager>().getLightState())
                {
                    otherFlashlight.GetComponent<FlashlightManager>().setLightState(false);
                    myLight.enabled = !myLight.enabled;
                     print("uv flashlight is on");
                    print("other flashlight is off");
                    
                }
            else{
                myLight.enabled = !myLight.enabled;
                     print("uv flashlight is on");
            }
        }
        
    }
}
