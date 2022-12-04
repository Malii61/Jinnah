using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<GameObject> flashlights = new List<GameObject>();
    public GameObject normalFlashlight;
    public GameObject UVFlashlight;
    private GameObject currentFlashlight;
    private bool normalFlashlightIsActive = false;
    private bool UVFlashlightIsActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool isFlashlightInList(GameObject flashlight){
        bool result = false;
        foreach(GameObject flashlightInList in flashlights){
            if(flashlightInList == flashlight){
                result = true;
                break;
            }
        }
        return result;
    }

    public void addFlashlight(GameObject flashlight)
    {
        flashlights.Add(flashlight);
    }
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
           if(isFlashlightInList(normalFlashlight)){
               currentFlashlight = normalFlashlight;
               this.normalFlashlightIsActive = !this.normalFlashlightIsActive;
               normalFlashlight.SetActive(normalFlashlightIsActive);
               if(isFlashlightInList(UVFlashlight)){
                   UVFlashlight.SetActive(false);
               }
           }
           else{
               print("normal flashlight yok");
           }
        }
        else if(Input.GetKeyDown(KeyCode.Y))
        {
            if(isFlashlightInList(UVFlashlight)){
                currentFlashlight = UVFlashlight;
                this.UVFlashlightIsActive = !this.UVFlashlightIsActive;
                UVFlashlight.SetActive(UVFlashlightIsActive);
                if(isFlashlightInList(normalFlashlight)){
                    normalFlashlight.SetActive(false);
                }
            }
            else{
                print("UV flashlight yok");
            }
        }
        
    }
}
/* public void changeFlashlightTo(string type){
        if(type == "normal"){
            if(!normalFlashlightIsActive){
                UVFlashlight.GetComponent<UVFlashlightAction>().
                normalFlashlightIsActive = true;
                UVFlashlightIsActive = false;
            }
        }
        else if(type == "UV"){
            if(!UVFlashlightIsActive){
                UVFlashlightIsActive = true;
                normalFlashlightIsActive = false;
            }
        }
    }

    public void setNormalFlashlightIsActive(bool on)
    {
        this.normalFlashlightIsActive = on;
    }
    
    public void setUVFlashlightIsActive(bool on)
    {
        this.UVFlashlightIsActive = on;
    }

    public bool getNormalFlashlightIsActive()
    {
        return this.normalFlashlightIsActive;
    }

    public bool getUVFlashlightIsActive()
    {
        return this.UVFlashlightIsActive;
    }

    public List<GameObject> getFlashlights()
    {
        return flashlights;
    }

    public void addFlashlight(GameObject flashlight)
    {
        flashlights.Add(flashlight);
    }

    public void changeCurrentFlashlight(GameObject flashlight)
    {
        if(currentFlashlight != null){
            currentFlashlight.SetActive(false);
        }
        currentFlashlight = flashlight;
    }

    public GameObject getCurrentFlashlight()
    {
        return currentFlashlight;
    } */

/*
void setCurrentFlashlight()
    {
        if(flashlights != null){
            foreach (GameObject flashlight in flashlights)
            {
                if (flashlight.activeSelf)
                {
                    currentFlashlight = flashlight;
                }
            }
        }
        else{
            currentFlashlight = null;
        }
    }

    void changeFlashlight(){
        if(currentFlashlight != null){
            currentFlashlight.SetActive(false);
        }
        foreach (GameObject flashlight in flashlights)
        {
            if (flashlight.activeSelf)
            {
                currentFlashlight = flashlight;
            }
        }
        currentFlashlight.SetActive(true);
    }

    int activeFlashlights(){
        int count = 0;
        
            foreach (GameObject flashlight in flashlights)
            {
                if (flashlight.activeSelf)
                {
                    count++;
                }
            }
        
       
        return count;
    }
*/
