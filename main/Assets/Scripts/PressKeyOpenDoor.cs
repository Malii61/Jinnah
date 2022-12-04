using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PressKeyOpenDoor : MonoBehaviour
{
    public GameObject AnimeObject;
    public bool Action = false;
    public bool opened = false;
    public Animator anim;
    private float animTime = 1f;
    public bool doIHaveKey = true;
    public AudioClip lockedDoorSound;
    public AudioClip DoorCreakSound;
    private float nextSoundTimer = 0f;
    private bool soundPlayed = false;
    public AudioClip closeDoorSound;

    public bool locked;

    public void beginScript()
    {
        Action = true;
    }

    public void Pressed()
    {
        AnimeObject.GetComponent<Animator>().Play("DoorOpen");
        opened = !opened;
        anim.SetBool("Opened", !opened);
        if (opened)
        {
            AnimeObject.GetComponent<AudioSource>().PlayOneShot(DoorCreakSound,0.5f);
        }
        else
        {
            AnimeObject.GetComponent<AudioSource>().PlayOneShot(DoorCreakSound,0.5f);
            soundPlayed = true;


        }
    }
    public bool canEnemyOpenDoor()
    {
        if (!opened && !locked)
            return true;
        else
        {
            return false;
        }
    }

    void checkKey()
    {
        try
        {
            doIHaveKey = AnimeObject.GetComponent<KeyController>().keyControl();
        }
        catch
        {
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!locked)
        {
            GetComponent<NavMeshObstacle>().enabled = false;
        }
        else
        {
            GetComponent<NavMeshObstacle>().enabled = true;
        }
        if (soundPlayed)
        {
            nextSoundTimer += Time.deltaTime;
        }
        if (nextSoundTimer >= 0.75f)
        {
            AnimeObject.GetComponent<AudioSource>().PlayOneShot(closeDoorSound,0.7f);
            nextSoundTimer = 0f;
            soundPlayed = false;

        }

        if (this.locked)
        {
            checkKey();
        }
        else
        {
            doIHaveKey = true;
        }

        animTime += Time.deltaTime;


        if (Action == true)
        {
            if (doIHaveKey)
            {
                this.locked = false;
                if (animTime >= 1f)
                {
                    Pressed();
                    animTime = 0f;
                }
                Action = false;
            }
            else
            {
                AnimeObject.GetComponent<AudioSource>().PlayOneShot(lockedDoorSound);
                Action = false;

            }


        }



    }
}
