using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollition : MonoBehaviour
{
    public GameObject bodyDiePrefab;

    public GameObject corpse;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Key") && GameManager.instance.numKeys < 5)
        {
            GameManager.instance.numKeys += 1;
            UIManager.instance.SetKeysText();
            StartCoroutine(PlaySoundObject(other.gameObject));
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Door") && GameManager.instance.numKeys > 0)
        {
            GameManager.instance.numKeys -= 1;
            UIManager.instance.SetKeysText();

            collision.gameObject.GetComponent<Animator>().enabled = true;
            collision.gameObject.tag = "Untagged";
            collision.gameObject.GetComponent<AudioSource>().Play();


        }
        else if (collision.collider.CompareTag("BadObject"))
        {

            print("Toco un objeto maloooooo!!!!!!");
          GameObject bodyDieNew =  Instantiate(bodyDiePrefab, transform.position,bodyDiePrefab.transform.rotation);
            bodyDieNew.transform.SetParent(corpse.transform);
            GameManager.instance.touchBadObjectBool = true;
            GameManager.instance.FreezePlayer();
            gameObject.GetComponent<AudioSource>().Play();
        }else if (collision.collider.CompareTag("Goal"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Timer.instance.timerIsRunning = false;
            StartCoroutine(UIManager.instance.WinerPanel());
        }

    }

    IEnumerator PlaySoundObject(GameObject ObjectPlaySound)
    {
        ObjectPlaySound.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        ObjectPlaySound.gameObject.SetActive(false);
    }



}
