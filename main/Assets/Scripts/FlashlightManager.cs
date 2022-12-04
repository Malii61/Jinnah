using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightManager : MonoBehaviour
{

    public Light myLight;

    public GameObject batteryInfoField;
    public GameObject batteryFullnessBar;

    public GameObject otherFlashlight;
    
    private bool isActive;

    public List<GameObject> batteries;
    GameObject currentBattery;
    List<GameObject> activeBatteries = new List<GameObject>();
    private float flashlightTimer = 0;
    private float maxIntensity = 2.0f;
    private float minIntensity = 0.1f;
    private float fadeRate = 0.01f;
    private float chargeRate = 0.8f;
    bool startFlashlightTimer = true;
    // Start is called before the first frame update
    void Start()
    {
        myLight = myLight.GetComponent<Light>();
        print("toplam batarya: " + batteries.Count);
        myLight.enabled = true;

    }

    public void makeReady()
    {
        setActiveBatteries(this.batteries);


        if (this.activeBatteries.Count > 0)
        {
            setCurrentBattery(this.activeBatteries);
        }
        else
        {
            this.currentBattery = null;
        }
    }

    void setActiveBatteries(List<GameObject> batteries)
    {
        for (int i = 0; i < batteries.Count; i++)
        {
            bool batteryActiveness = batteries[i].GetComponent<BatteryController>().getIsActive();
            bool isPicked = batteries[i].GetComponent<BatteryController>().getIsPicked();
            if (batteryActiveness && !isPicked)
            {
                batteries[i].GetComponent<BatteryController>().setIsPicked(true);

                this.activeBatteries.Add(batteries[i]);
            }
            else
            {
            }
        }
    }

    void setCurrentBattery(List<GameObject> batteries)
    {
        for (int i = 0; i < batteries.Count; i++)
        {
            bool batteryActiveness = batteries[i].GetComponent<BatteryController>().getIsActive();
            float batteryFullness = batteries[i].GetComponent<BatteryController>().getBatteryFullness();
            bool isPicked = batteries[i].GetComponent<BatteryController>().getIsPicked();
            if (batteryActiveness && isPicked)
            {
                currentBattery = batteries[i];
                break;
            }
            else
            {
                this.activeBatteries.Remove(batteries[i]);
            }
        }

    }

    void setCurrentBatteryFullness()
    {
        currentBattery.GetComponent<BatteryController>().setBatteryFullness(-0.5f * Time.deltaTime);
    }

    void changeBattery()
    {
        if (this.activeBatteries.Count > 0)
        {
            setCurrentBattery(this.activeBatteries);
        }
        else
        {
            this.currentBattery = null;
        }
    }

    bool checkLight()
    {
        if (this.currentBattery != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void changeLightIntensity(float newIntensity)
    {
        if (this.currentBattery != null)
        {
            this.myLight.intensity = newIntensity;
        }
    }

    void setBatteryInfoField()
    {
        this.batteryInfoField.GetComponent<TextMesh>().text = "Batarya Sayısı: " + this.activeBatteries.Count;
    }

    void setBatteryFullnessBar()
    {
        if (this.currentBattery != null)
        {
            float batteryFullness = this.currentBattery.GetComponent<BatteryController>().getBatteryFullness();
            this.batteryFullnessBar.GetComponent<TextMesh>().text = "(" + Mathf.Round(batteryFullness) + "%)";
        }
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
        setBatteryInfoField();
        setBatteryFullnessBar();
        
        if (Input.GetMouseButtonDown(0) && checkLight())
        {   
                if(otherFlashlight.GetComponent<UVFlashlightAction>().getLightState())
                {
                    otherFlashlight.GetComponent<UVFlashlightAction>().setLightState(false);
                    startFlashlightTimer = true;
                }
            else{
                startFlashlightTimer = true;
            }
        }
        if (startFlashlightTimer)
        {
            flashlightTimer += Time.deltaTime;
            if (flashlightTimer > 0.2f)
            {
                myLight.enabled = !myLight.enabled;
                flashlightTimer = 0;
                startFlashlightTimer = false;

            }
        }
        
        if (myLight.enabled == true && checkLight())
        {
            if (currentBattery.GetComponent<BatteryController>().getBatteryFullness() <= 0f)
            {
                currentBattery.GetComponent<BatteryController>().setIsActive(false);
                myLight.enabled = false;
                changeBattery();
            }
            else
            {
                setCurrentBatteryFullness();
                changeLightIntensity(currentBattery.GetComponent<BatteryController>().getBatteryFullness() / 50);
            }


        }
    }
}
