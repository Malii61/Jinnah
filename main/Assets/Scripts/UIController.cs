using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        startButton = root.Q<Button>("start_button");
        exitButton = root.Q<Button>("exit_button");

        startButton.clicked += StartButtonPressed;
        exitButton.clicked += ExitButtonPressed;


    }

    // Update is called once per frame
    void StartButtonPressed()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }
    void ExitButtonPressed()
    {
        Application.Quit();
    }
}
