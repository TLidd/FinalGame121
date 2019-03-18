using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndCanvas : MonoBehaviour
{
    public Text textOutput;
    public Button MainMenu, PlayAgain;
    public static string text = "0 seconds";

    private void Start()
    {
        textOutput.text = "You Lasted " + text;
        PlayAgain.onClick.AddListener(Play);
        MainMenu.onClick.AddListener(Menu);
    }

    private void Play()
    {
        Player.PlayerAlive = true;
        SceneManager.LoadScene("PlayScene");
    }

    private void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
