using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTV : MonoBehaviour
{
    public List<GameObject> lights;
    private bool action = false;
    public GameObject key;
    public AudioClip TVOffSound;
    public AudioSource audioSource;
    private bool playSound = true;

    void Start()
    {
        audioSource = audioSource.GetComponent<AudioSource>();

    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Player" && key.activeSelf)
        {
            action = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = 20f;

        if (!audioSource.isPlaying && !action)
        {
            audioSource.Play();
        }
        else
        {

        }
        if (action)
        {
            if (playSound)
            {
                audioSource.PlayOneShot(TVOffSound, 15.9f);
                playSound = false;
            }
            foreach (var light in lights)
            {

                light.GetComponent<Light>().enabled = false;

            }


        }
    }
}
