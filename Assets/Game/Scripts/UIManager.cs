using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Invector.vCharacterController;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Text keysText;
    public GameObject panelDie;
    public GameObject panelWin;
    public GameObject menuPanel;
    public AudioSource audioSourcePlayer;

    public bool openMenuBool;
    public bool playMusicBool;

    private void Awake()
    {
        openMenuBool = true;
        playMusicBool = true;
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(this);
        }

    }


    public void SetKeysText()
    {
        
        keysText.text = ": " + GameManager.instance.numKeys;
    }


    public void OpenCloseMenu()
    {
        if (openMenuBool)
        {
            menuPanel.SetActive(true);
            GameManager.instance.player.GetComponent<Animator>().enabled = false;
          //  GameManager.instance.player.GetComponent<vThirdPersonInput>().enabled = false;
            GameManager.instance.player.GetComponent<Rigidbody>().isKinematic = true;
            Timer.instance.timerIsRunning = false;
            openMenuBool = false;
        }
        else
        {
           
            GameManager.instance.player.GetComponent<Animator>().enabled = true;
            //GameManager.instance.player.GetComponent<vThirdPersonInput>().enabled = true;
            GameManager.instance.player.GetComponent<Rigidbody>().isKinematic = false;
            menuPanel.SetActive(false);

            Timer.instance.timerIsRunning = true;
            openMenuBool = true;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PauseMusic()
    {
        if (playMusicBool)
        {
            playMusicBool = false;
            audioSourcePlayer.Stop();
        }
        else
        {
            playMusicBool = true;
            audioSourcePlayer.Play();
        }
    }

    
    public IEnumerator WinerPanel()
    {
        panelWin.SetActive(true);
        yield return new WaitForSeconds(3f);
        panelWin.SetActive(false);
        SceneManager.LoadScene("Menu");

    }



}
