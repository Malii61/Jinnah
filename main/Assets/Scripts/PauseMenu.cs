using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class PauseMenu : MonoBehaviour
{
    public Button ContinueButton;
    public Button menuButton;
    public Button optionsButton;
    public Button backButton;
    public IMGUIContainer menuContainer;
    public IMGUIContainer optionsContainer;
    public Slider sensitivitySlider;
    public Slider volumeSlider;
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject UIDocument;
    private MouseLook Sensitivity;
    public List <AudioSource> sounds;
    private float volume;
    public AudioMixer masterMixer;
    private bool isVolumeChanged;
    public AudioMixerGroup audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sounds.Count; i++)
        {
            sounds[i].GetComponent<AudioSource>().outputAudioMixerGroup = audioMixer;
        }
        Sensitivity = transform.Find("PlayerEyes").GetComponent<MouseLook>();

    }
    void Update()
    {
        
        try
        {
            var root = UIDocument.GetComponent<UIDocument>().rootVisualElement;

            menuContainer = root.Q<IMGUIContainer>("MenuContainer");
            optionsContainer = root.Q<IMGUIContainer>("OptionsContainer");
            ContinueButton = root.Q<Button>("start_button");
            menuButton = root.Q<Button>("exit_button");
            optionsButton = root.Q<Button>("options_button");
            backButton = root.Q<Button>("back_button");
            sensitivitySlider = root.Q<Slider>("SensitivitySlider");
            volumeSlider = root.Q<Slider>("VolumeSlider");


            ContinueButton.clicked += ContinueButtonPressed;
            menuButton.clicked += MenuButtonPressed;
            optionsButton.clicked += OptionsButtonPressed;
            backButton.clicked += BackButtonPressed;


        }
        catch
        {

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameIsPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
        void OptionsButtonPressed()
        {
            isVolumeChanged = true;
            menuContainer.style.display = DisplayStyle.None;
            optionsContainer.style.display = DisplayStyle.Flex;
            sensitivitySlider.value = (Sensitivity.mouseSensitivity-15)/5;
            volumeSlider.value = volume;
        }

        void BackButtonPressed()
        {
            menuContainer.style.display = DisplayStyle.Flex;
            optionsContainer.style.display = DisplayStyle.None;

        }
        void ContinueButtonPressed()
        {
            Resume();
        }
        void MenuButtonPressed()
        {
            SceneManager.LoadScene("MenuScene");
        }
        void Pause()
        {
            PlayerMovement.StopMusic = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;

        }

        void Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
            Sensitivity.mouseSensitivity = sensitivitySlider.value * 5 + 15f;
            if (isVolumeChanged) { 
                masterMixer.SetFloat("volume", volumeSlider.value);
                isVolumeChanged = false;
            }
            volume = volumeSlider.value;
        }
    }
}
