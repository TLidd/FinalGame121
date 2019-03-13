using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button StartButton, ControlsButton;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(ToGame);
        ControlsButton.onClick.AddListener(ToControls);
    }

    private void ToGame()
    {
        Debug.Log("To Game!");
        SceneManager.LoadScene("PlayScene");
    }

    private void ToControls()
    {
        Debug.Log("ToControls");
        SceneManager.LoadScene("Controls");
    }
}
