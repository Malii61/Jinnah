using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPicker : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject key;
    public GameObject pickedKey;
    public AudioClip pickingKeySound;
    private bool Action = false;
    // Start is called before the first frame update
    public void beginScript()
    {
        Action = true;
    }


    // Update is called once per frame
    void Update()
    {

        if (Action)
        {
            pickedKey.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(pickingKeySound);

            key.GetComponent<MeshRenderer>().enabled = false;
            key.GetComponent<CapsuleCollider>().enabled = false;
            Action = false;
        }

    }
}
