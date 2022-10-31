using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager instance;

    public GameObject respawnTransform;
    public  GameObject player;
    public bool endTimeBool;
    public int numKeys;
    public bool touchBadObjectBool;


    private void Awake()
    {
        endTimeBool = false;

        if (instance == null)
        {
            instance = this;
        //    DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }     

    }

    private void Start()
    {
        touchBadObjectBool = false;
        numKeys = 0;
       
    }



    public void RespawnCharacter()
    {
        Timer.instance.RestartTimer();
        touchBadObjectBool = false;
        endTimeBool = true;
        UIManager.instance.panelDie.SetActive(false);


    }


    public void FreezePlayer()
    {

        if ((Timer.instance.timeRemaining < 0 && endTimeBool == false) || touchBadObjectBool)
        {
            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<vThirdPersonInput>().enabled = false;
            player.GetComponent<Rigidbody>().isKinematic = true;
            player.transform.position = respawnTransform.transform.position;
            UIManager.instance.panelDie.SetActive(true);
            Invoke("RespawnCharacter", 0.7f);
        }
        else if (endTimeBool || touchBadObjectBool == false)
        {
            player.GetComponent<Animator>().enabled = true;
            player.GetComponent<vThirdPersonInput>().enabled = true;
            player.GetComponent<Rigidbody>().isKinematic = false;
            endTimeBool = false;

        }
       

    }


   









}
