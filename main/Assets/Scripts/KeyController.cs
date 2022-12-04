using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{   
    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool keyControl()
    {
        if (!key.activeSelf)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        keyControl();
    }
}
