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
    public float moveSpeed = 1f;
    float maxMoveSpeed = 2.2f;
    bool callBirdDeath = false;

    private void Start()
    {
        playerScript = Player.GetComponent<PlayerScript>();
        secondsToWait = 3;
    }


    void Update()
    {

        if (playerScript.firstInput && playerScript.died == false && birdCatch == false)
        {

            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * moveSpeed;

            if (Mathf.Round((gameObject.transform.position.z - playerScript.transform.position.z))-1.5 == 0.5f && callBirdDeath == false)
            {
                BirdDeath();
                callBirdDeath = true;
            }

            else if (Mathf.Abs(gameObject.transform.position.z - playerScript.transform.position.z) <= 1.5)
            {

                if (moveSpeed > 0.5f)
                {
                    moveSpeed -= Time.deltaTime * 3;

                 

                }
                else
                {
                    moveSpeed = .5f;
                }

            }
            else if ((Mathf.Abs(gameObject.transform.position.z - playerScript.transform.position.z) > 1.5) && (Mathf.Abs(gameObject.transform.position.z - playerScript.transform.position.z) <= 3))
            {
                if (moveSpeed > 0.65f)
                {
                    moveSpeed -= Time.deltaTime * 3;


                }
                else
                {
                    moveSpeed = .65f;
                }
            }


            else if ((Mathf.Abs(gameObject.transform.position.z - playerScript.transform.position.z) > 3) && (Mathf.Abs(gameObject.transform.position.z - playerScript.transform.position.z) <= 6))
            {

                if (moveSpeed > 1.1f)
                {
                    moveSpeed -= Time.deltaTime * 3;


                }
                else
                {
                    moveSpeed = 1.1f;
                }
            }
            else if ((Mathf.Abs(gameObject.transform.position.z - playerScript.transform.position.z) > 7))
            {

                if (moveSpeed > 2.1f)
                {
                    moveSpeed -= Time.deltaTime * 3;


                }
                else
                {
                    moveSpeed = 2.1f;
                }
            }
        }







        if (playerScript.firstInput && playerScript.died == false && Player.transform.position.x < 9 && Player.transform.position.x > -8 && birdDeath == false && birdCatch == false && playerScript.moved == true)
        {

            newPos = new Vector3(Mathf.Lerp(transform.localPosition.x, Player.transform.localPosition.x + 1, Time.deltaTime * 3), transform.localPosition.y, transform.localPosition.z);


            transform.position = newPos;

        }

        if (playerScript.moved == true && alreadyCalled == false && playerScript.died == false && playerScript.moveUp == true)
        {

            alreadyCalled = true;


            moveSpeed = maxMoveSpeed;
            if (gameObject.transform.position.z - playerScript.transform.position.z >= 7)
            {
                moveSpeed += 1f;
            }
        }


      
        if (birdDeath == true)
        {


            instantiatedObject.transform.position += new Vector3(0, 0, -1) * Time.deltaTime * 40;

            if (birdCatch == false)

            {
                
                newPos = new Vector3(transform.localPosition.x, transform.localPosition.y,Mathf.Lerp(transform.localPosition.z, Player.transform.localPosition.z -4, Time.deltaTime * 3));


                transform.position = newPos;
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
        if (playerScript.riverDeath == false && playerScript.died == false)
        {

            StopCoroutine(CountDown(secondsToWait));
            FindObjectOfType<AudioManager>().Play("Eagle");
            if (Player.transform.position.x > -8 && Player.transform.position.x < 7)
            {

                birdDeath = true;
                playerScript.birdDeath = true;
                instantiatedObject = Instantiate(DeathBird, new Vector3(Player.transform.position.x + 0.2f, 2, Player.transform.position.z + 15), Quaternion.identity);
                Invoke("Death", 0.6f);
            }
        }
    }
    void Death()
    {
        playerScript.died = true;
    }
}
