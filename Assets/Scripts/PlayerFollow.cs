using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject Player;
    PlayerScript playerScript;
    Vector3 newPos;

    int secondsToWait;
    bool startAgain = false;
    public bool alreadyCalled = false;
    bool countDownActive = false;
    float multiplier = 3f;

    public GameObject DeathBird;
    GameObject instantiatedObject;
    public bool birdDeath = false;
    public bool birdCatch = false;

    int resetSeconds = 5;
      
    
    private void Start()
    {
        playerScript = Player.GetComponent<PlayerScript>();
        secondsToWait = 3;
    }


    void Update()
    {
     

        if (playerScript.died == false && Player.transform.position.x < 9 && Player.transform.position.x > -8 && birdDeath == false && birdCatch ==false )
        {
            if (playerScript.downCount > 1)
            {
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(Player.transform.position.x-4.5f, newPos.y, newPos.z), Time.deltaTime * 2f);


            }
            else
            {
                

                newPos = new Vector3(Player.transform.position.x-2.5f, Player.transform.position.y, Player.transform.position.z + 7);
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,newPos, Time.deltaTime *multiplier );

            }

        }

  

        if (playerScript.moved == true && alreadyCalled == false && playerScript.died == false)
         {
          
            alreadyCalled = true;

            ActivateCoundown();
            multiplier = 3f;





        }
        if (birdDeath == true)
        {
          
              
            instantiatedObject.transform.position += new Vector3(0, 0, -1) * Time.deltaTime * 40;
            
            if (birdCatch ==false)
                
                {
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3 (Player.transform.position.x, Player.transform.position.y, Player.transform.position.z) , Time.deltaTime * .5f);
            }
            if (instantiatedObject.transform.position.z <= Player.transform.position.z)

            {
                birdCatch = true;

            }
        }
    }


    void ActivateCoundown()
    {
       


        if (countDownActive == false)
        {
            secondsToWait = resetSeconds;
            startAgain = false;

            StartCoroutine(CountDown(secondsToWait));


        }
        else
        {
            secondsToWait = resetSeconds;
            StopCoroutine(CountDown(secondsToWait));
            startAgain = true;


        }

    }
    void ActivateNewCountDown()
    {
        secondsToWait = resetSeconds;
        if (playerScript.onRaft)
        {
            secondsToWait += 1;
        }
        StartCoroutine(CountDown(secondsToWait));

    }


    IEnumerator CountDown(int secondsToWait)
    {
        countDownActive = true;

        while (secondsToWait > 0)
        {
         
            multiplier -= 0.3f;
            secondsToWait--;
            if (secondsToWait == 0)
            {
                BirdDeath();

            }
            yield return new WaitForSeconds(1);
            if (startAgain == true)
            {
                break;
            }
        }
        countDownActive = false;
        startAgain = false;
      
        if (secondsToWait != 0)
        {


            ActivateNewCountDown();
        }

    }

    public void BirdDeath()
    {
        if (playerScript.riverDeath == false && playerScript.died ==false)
        {

            StopCoroutine(CountDown(secondsToWait));
            FindObjectOfType<AudioManager>().Play("Eagle");
            if(Player.transform.position.x > -8 && Player.transform.position.x < 7)
            {

            birdDeath = true;
                playerScript.birdDeath = true;
            instantiatedObject = Instantiate(DeathBird, new Vector3(Player.transform.position.x+0.2f, 2, Player.transform.position.z + 15), Quaternion.identity);
            Invoke("Death", 0.6f);
            }
        }
    }
    void Death()
    {
        playerScript.died = true;
    }
}
