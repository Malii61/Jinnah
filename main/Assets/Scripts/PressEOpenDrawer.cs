using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressEOpenDrawer : MonoBehaviour
{
    public GameObject Instruction;
    public bool Action = false;
    private bool opened;
    public Animator anim;
    private float animTime = 0f;

    // Start is called before the first frame update
    public void beginScript()
    {
        Action = true;
    }
    // Update is called once per frame
    void Update()
    {
        animTime += Time.deltaTime;

        if (Action == true)
        {

            Instruction.SetActive(false);
            if (animTime >= 1f)
            {
                GetComponent<Animator>().Play("DrawerAnim");
                anim.SetBool("Opened", !opened);

                opened = !opened;
                animTime = 0f;
            }
            Action = false;



        }
    }
}
