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
    float multiplier = 1.5f;

    public GameObject DeathBird;
    GameObject instantiatedObject;
    public bool birdDeath = false;
    public bool birdCatch = false;

    private void Start()
    {
        playerScript = Player.GetComponent<PlayerScript>();
        secondsToWait = 3;
    }


    void Update()
    {


        if (playerScript.died == false && Player.transform.position.x < 6 && Player.transform.position.x > -6 && birdDeath == false && birdCatch ==false)
        {
            newPos = Vector3.Lerp(gameObject.transform.position, Player.transform.position, Time.deltaTime * multiplier);
            gameObject.transform.position = new Vector3(newPos.x, 7f, newPos.z);

        }



        if (playerScript.moved == true && alreadyCalled == false)
        {
            alreadyCalled = true;

            ActivateCoundown();
            multiplier = 1.5f;





        }
        if (birdDeath == true)
        {
          
              
            instantiatedObject.transform.position += new Vector3(0, 0, -1) * Time.deltaTime * 20;
            
            if (birdCatch ==false)
                
                {
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3 (Player.transform.position.x, Player.transform.position.y, Player.transform.position.z-3) , Time.deltaTime * .3f);
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
            secondsToWait = 3;
            startAgain = false;

            StartCoroutine(CountDown(secondsToWait));


        }
        else
        {
            secondsToWait = 3;
            StopCoroutine(CountDown(secondsToWait));
            startAgain = true;


        }

    }
    void ActivateNewCountDown()
    {
        secondsToWait = 3;

        StartCoroutine(CountDown(secondsToWait));

    }


    IEnumerator CountDown(int secondsToWait)
    {
        countDownActive = true;

        while (secondsToWait > 0)
        {
            print(secondsToWait + "" + startAgain);

            multiplier -= 0.4f;
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
        print("end");
        print("seconds" + secondsToWait);
        if (secondsToWait != 0)
        {


            ActivateNewCountDown();
        }

    }

    public void BirdDeath()
    {
        if (playerScript.riverDeath == false || playerScript.died ==false)
        {

            StopCoroutine(CountDown(secondsToWait));

            birdDeath = true;
            instantiatedObject = Instantiate(DeathBird, new Vector3(Player.transform.position.x, 2, Player.transform.position.z + 15), Quaternion.identity);
            Invoke("Death", 0.6f);
        }
    }
    void Death()
    {
        playerScript.died = true;
    }
}
