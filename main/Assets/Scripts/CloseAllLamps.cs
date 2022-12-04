using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAllLamps : MonoBehaviour
{
    public List<Lights> lights;
    public GameObject key;
    private bool action = false;
    private Material Lamp_OFF;
    public AudioClip lampsOffSound;
    private AudioSource audioSource;
    private bool playSound = true;
    // Start is called before the first frame update
    void Start()
    {
        Lamp_OFF = Resources.Load<Material>("Lamp_OFF");
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Player" && key.activeSelf )
        {
            action = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (action)
        {
            foreach (var light in lights)
            {
                if (playSound)
                {
                    audioSource.PlayOneShot(lampsOffSound, 1.9f);
                    playSound = false;
                }
                Transform[] children = light.transform.GetComponentsInChildren<Transform>(true);
                foreach (Transform child in children)
                {
                    try
                    {
                        MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();
                        meshRenderer.material = Lamp_OFF;
                    }
                    catch { }
                }
                light.GetComponent<Light>().enabled = false;
                light.GetComponent<Lights>().enabled = false;


            }
            action = false;

        }
    }
}
