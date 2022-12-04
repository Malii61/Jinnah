using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{   
    private float animTime = 1f;
    public GameObject Lamp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animTime += Time.deltaTime;
        if (animTime >= createRandomNumber(0,1))
        {
            Lamp.GetComponent<Light>().enabled = !Lamp.GetComponent<Light>().enabled;
            animTime = 0f;
        }
        
    }

    float createRandomNumber(float min, float max)
    {
        return Random.Range(min, max);
    }
}
