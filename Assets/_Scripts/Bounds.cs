using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class Bounds : MonoBehaviour
{
    float lerpTime;
    float currentLerpTime;
    public float percentage = 1;
    Vector3 startPos;
    Vector3 endPos;
    bool firstInput;
    public bool justJump = false;

    public float steps = 2f;
    public GameObject Player;

    public Tilemap objectTileMap;
    Vector3Int nextPosition;
    bool validPosition;

    bool clickOnce = false;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (percentage == 1)
            {
                lerpTime = 1;
                currentLerpTime = 0;
                justJump = true;
                firstInput = true;
                print("jumped" + justJump);

            }
        }


        /* Exact movement on grid */
        /*
                if((int)gameObject.transform.position.x % 2 == 0)
                {
                    Mathf.Floor(gameObject.transform.position.x);
                }
                else
                {
                    Mathf.Ceil(gameObject.transform.position.x);
                }
                if ((int) gameObject.transform.position.z % 2 == 0)
                {
                    Mathf.Floor(gameObject.transform.position.z);
                }
                else
                {
                    Mathf.Ceil(gameObject.transform.position.z);
                }
                startPos = gameObject.transform.position;*/

        /**/
        startPos = gameObject.transform.position; 


        if (Input.GetKeyDown(KeyCode.RightArrow) && clickOnce ==false)

        {
            endPos =  ExactPos(   new Vector3(transform.position.x + steps, transform.position.y, transform.position.z));

            nextPosition = objectTileMap.WorldToCell((Vector3)endPos);
            validPosition = checkValidJump(nextPosition);
            clickOnce = true;

        }
        if
            (Input.GetKeyDown(KeyCode.LeftArrow) && clickOnce == false)
        {
              endPos =  ExactPos( new Vector3(transform.position.x - steps, transform.position.y, transform.position.z));

            nextPosition = objectTileMap.WorldToCell((Vector3)endPos);

            validPosition = checkValidJump(nextPosition);

            clickOnce = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && clickOnce == false)
        {
            endPos = ExactPos( new Vector3(transform.position.x, transform.position.y, transform.position.z + steps));
            nextPosition = objectTileMap.WorldToCell((Vector3)endPos);
            validPosition = checkValidJump(nextPosition);

            clickOnce = true;

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && clickOnce == false)
        {
          endPos = ExactPos( new Vector3(transform.position.x, transform.position.y, transform.position.z - steps));
            nextPosition = objectTileMap.WorldToCell((Vector3)endPos);
            validPosition = checkValidJump(nextPosition);
            clickOnce = true;

        }
        if (firstInput == true)
        {
            currentLerpTime += Time.deltaTime * 5.5f;
            percentage = currentLerpTime / lerpTime;
            print(validPosition);

            if (validPosition == true)
            {
                print("move");

                gameObject.transform.position = Vector3.Lerp(startPos, endPos, percentage);
                

            }
            if (percentage > 0.8f)
            {
                percentage = 1;
            }
            if (Mathf.Round(percentage) == 1)
            {
                justJump = false;


            }
            //either moved or invalid position
            if( startPos== endPos || validPosition == false)
            {

                clickOnce = false;

            }

        }
    }

    bool checkValidJump(Vector3Int nextPosition)
    {




        if (objectTileMap.HasTile(nextPosition) == true)
        {
          

            return false;
        }


        return true;
    }

    Vector3 ExactPos(Vector3 position)
    {
        if ((int)position.x % 2 == 0)
        {
            position.x = Mathf.Floor(position.x);
        }
        else
        {
            position.x = Mathf.Ceil(position.x);
        }
        if ((int)position.z % 2 == 0)
        {
            position.z = Mathf.Floor(position.z);
        }
        else
        {
            position.z = Mathf.Ceil(position.z);
        }


        return position;
    }




    /* private void aUpdate()
     {

         if (Input.GetKeyDown(KeyCode.RightArrow))
         {
             startPos = Player.transform.position;


             endPos = new Vector3(transform.position.x + steps, jumpForce, transform.position.z);
                rb.velocity = endPos;
         *//*    Player.transform.position += endPos;
             if (playOnce == false)
             {

                 justJump = true;
                 playOnce = true;
             }
             print(justJump);

             print(startPos + "." + endPos);
             moved = true;*//*
             clickedOnce = true;
         }
         if (Input.GetKeyDown(KeyCode.LeftArrow))
         {
             startPos = Player.transform.position;


             endPos = new Vector3(transform.position.x - steps, jumpForce, transform.position.z);
              rb.velocity = endPos;

    *//*
                Player.transform.position += endPos;
                if (playOnce == false)
                {

                    justJump = true;
                    playOnce = true;
                }
                print(justJump);

                print(startPos + "." + endPos);
                moved = true;*//*
                clickedOnce = true;

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                startPos = Player.transform.position;




                endPos = new Vector3(transform.position.x, jumpForce, transform.position.z + steps);
                rb.velocity = endPos;
             *//*   Player.transform.position += endPos;
                if (playOnce == false)
                {

                    justJump = true;
                    playOnce = true;
                }
                print(justJump);

                print(startPos + "." + endPos);
                moved = true;
    *//*

                clickedOnce = true;

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                startPos = Player.transform.position;
                endPos = new Vector3(transform.position.x, jumpForce, transform.position.z - steps);
              *//*  Player.transform.position += endPos;
                if (playOnce == false)
                {

                    justJump = true;
                    playOnce = true;
                }
                print(justJump);

                print(startPos + "." + endPos);
                moved = true;*//*

                  rb.velocity = endPos;

              //  rb.velocity = endPos;



                clickedOnce = true;

            }
           if(startPos== (startPos + endPos) && moved ==true)
            {
                print(startPos + endPos);
                moved = false;
                print("gleich-- stopp");
                playOnce = false;

                justJump = false;

            }

        }

    */

    private void FixedUpdate()
    {



        /*if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            endPos = new Vector3(transform.position.x + steps, transform.position.y, transform.position.z);
                Player.transform.position += endPos * speed * Time.deltaTime;
            clickedOnce = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            endPos = new Vector3(transform.position.x - steps, transform.position.y, transform.position.z);
            Player.transform.position += endPos * speed * Time.deltaTime;
           clickedOnce = true;

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + steps);
                    Player.transform.position += endPos * speed * Time.deltaTime;
            clickedOnce = true;

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - steps);
             Player.transform.position += endPos * speed *Time.deltaTime;
            clickedOnce = true;

        }*/


    }
}

