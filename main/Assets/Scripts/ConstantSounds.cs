using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSounds : MonoBehaviour
{
    private AudioSource audioSource;
    public List<AudioClip> audioClips;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying) ;
        else audioSource.Play();

    }
}
