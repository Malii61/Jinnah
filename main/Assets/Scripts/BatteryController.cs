using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    private float batteryFullness = 100f;
    private bool isActive = false;
    public GameObject battery;
    private bool isPicked = false;
    // Start is called before the first frame update



    void Start()
    {
        
    }

    public float getBatteryFullness()
    {
        return this.batteryFullness;
    }

    public void setBatteryFullness(float changeRate)
    {
        this.batteryFullness += changeRate;
    }
    

    public bool getIsActive()
    {
        return this.isActive;
    }

    public void setIsPicked(bool isPicked)
    {
        this.isPicked = isPicked;
    }

    public bool getIsPicked()
    {
        return this.isPicked;
    }

    public void setIsActive(bool isActive)
    {
        print("batarya aktifleştirildi");
        this.isActive = isActive;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            if(batteryFullness <= 0f)
            {
                isActive = false;
            }
        }
    }
}
