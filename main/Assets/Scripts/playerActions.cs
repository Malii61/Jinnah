using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerActions : MonoBehaviour
{
    public Transform cam;
    public float playerActivateDistence;
    bool active = false;
        //All interactions and info texts//
    public GameObject cursor;
    public GameObject InteractionText;
    private TextMesh IntTxt;
        //Reading names of interactions //
    public GameObject interactionName;
    private TextMesh IText;
    private bool TextVisibility = false;
    private float TextVisibilityTimer = 0f;
        //Win screen//
    public GameObject winDisplay;
    public Animator winDpAnim;
    private float animTimer = 0f;
    private bool startTimer = false;

    // Update is called once per frame
    void Start()
    {
        IntTxt = InteractionText.GetComponent<TextMesh>();
        IText = interactionName.GetComponent<TextMesh>();

    }

    private void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivateDistence);

        if (TextVisibility)
        {
            InteractionText.SetActive(true);
            TextVisibilityTimer += Time.deltaTime;
            if (TextVisibilityTimer > 1.5f)
            {
                InteractionText.SetActive(false);
                TextVisibilityTimer = 0f;
                TextVisibility = false;
            }   
        }
        if (startTimer)
        {
            animTimer += Time.unscaledDeltaTime;
            if (animTimer > 5f)
            {
                UnityEngine.Cursor.lockState = CursorLockMode.None;

                SceneManager.LoadScene(0);
            }
        }
        if (active)
        {
            if (hit.transform.tag == "Flashlight")
            {
                cursor.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<flashlightPickupTrigger>().beginScript();
                    TextVisibility = true;
                    IntTxt.text = "El feneri alýndý";

                }

            }
            else if (hit.transform.tag == "Battery")
            {
                cursor.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<batteryPicker>().beginScript();
                    TextVisibility = true;
                    IntTxt.text = "1 batarya alýndý";

                }
            }
            else if(hit.transform.tag == "Drawer")
            {
                cursor.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<PressEOpenDrawer>().beginScript();


                }
            }
            else if (hit.transform.tag == "Cabinet")
            {
                cursor.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<OpenCabinet>().beginScript();

                }
            }
            else if (hit.transform.tag == "Door")
            {
                cursor.SetActive(true);
                interactionName.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(IText.text== "Ana Kapý" && hit.transform.GetComponent<PressKeyOpenDoor>().doIHaveKey)
                    {
                        winDisplay.SetActive(true);
                        winDpAnim.Play("WinDisplayLight");
                        Time.timeScale = 0f;
                        startTimer = true;
                        
                    }
                    hit.transform.GetComponent<PressKeyOpenDoor>().beginScript();
                    
                }
                IText.text = hit.collider.gameObject.name;
                

            }
            else if (hit.transform.tag == "Key")
            {
                cursor.SetActive(true);
                interactionName.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<KeyPicker>().beginScript();
                    TextVisibility = true;
                    IntTxt.text = "Bir anahtar buldun!";

                }
                IText.text = hit.collider.gameObject.name;

            }
            else if (hit.transform.tag == "Lamp")
            {
                cursor.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<LightEnable>().beginScript();

                }
              
            }
            else
            {
                cursor.SetActive(false);
                interactionName.SetActive(false);
            }
        }
        else
        {
            interactionName.SetActive(false);

            cursor.SetActive(false);
        }

    }


}