using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batteryPicker : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject battery;
    public GameObject pickedBattery;
    public GameObject flashlight;
    private bool Action = false;
    // Start is called before the first frame update
    void Start()
    {
        Instruction.GetComponent<MeshRenderer>().enabled = true;
        Instruction.SetActive(false);
    }

    public void beginScript()
    {
        Action = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Action)
        {

                print(pickedBattery.name);
                pickedBattery.GetComponent<BatteryController>().setIsActive(true);
                flashlight.GetComponent<FlashlightManager>().makeReady();
                Destroy(battery);
                Action = false;
            
        }
    }
}
