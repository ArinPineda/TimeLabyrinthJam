using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject instructionsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("FirstLevel");
    }


    public void ExitGame()
    {
        Application.Quit();
    }


    public void OpenInstructions()
    {
        instructionsPanel.SetActive(true);
    }

   public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);

    }


}
