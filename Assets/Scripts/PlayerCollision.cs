using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    PlayerScript playerScript;
    TMPro.TextMeshProUGUI coinCountText;
    int coinCount;
    public AudioSource Quack;

    private void Start()
    {
        playerScript = this.gameObject.transform.parent.GetComponent<PlayerScript>();
        coinCount = playerScript.coinCount;
        coinCountText = playerScript.coinCountText;
        coinCountText.text = coinCount.ToString();



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if(playerScript.died == false && playerScript.birdDeath ==false)
            {

            FindObjectOfType<AudioManager>().Play("DieEnemy");
                Quack.Play();
            }


            playerScript.died = true;
            this.gameObject.transform.parent.gameObject.transform.localScale = new Vector3(this.gameObject.transform.parent.gameObject.transform.localScale.x,0.01f, this.gameObject.transform.parent.gameObject.transform.localScale.z);
            playerScript.justJump = false;
        }
        if(other.tag == "Coin")
        {
            FindObjectOfType<AudioManager>().Play("Coin");


            coinCount++;
            coinCountText.text = coinCount.ToString(); 

        }
    }


}
