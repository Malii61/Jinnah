using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLamp : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject lamp;
    private bool Action = false;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        Instruction.GetComponent<MeshRenderer>().enabled = true;
        Instruction.SetActive(false);
    }
    void OnTriggerEnter(Collider collison)
    {
        if (collison.transform.tag == "Player")
        {
            Action = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            if(Action){
                lamp.GetComponent<Light>().enabled = !isOpen;
                isOpen = !isOpen;
            }
            Action = false;
        }
    }
}
