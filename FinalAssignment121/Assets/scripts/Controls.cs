using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour
{
    public Button BackButton;
    // Start is called before the first frame update
    void Start()
    {
        BackButton.onClick.AddListener(ToMenu);
    }

    private void ToMenu()
    {
        Debug.Log("ToMenu");
        SceneManager.LoadScene("Menu");
    }
}
