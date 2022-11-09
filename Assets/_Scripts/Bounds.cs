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
        startPos = gameObject.transform.position;


        if (Input.GetKeyDown(KeyCode.RightArrow))

        {
            endPos = new Vector3(transform.position.x + steps, transform.position.y, transform.position.z);
            nextPosition = objectTileMap.WorldToCell((Vector3)endPos);
            validPosition = checkValidJump(nextPosition);


        }
        if
            (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            endPos = new Vector3(transform.position.x - steps, transform.position.y, transform.position.z);
            nextPosition = objectTileMap.WorldToCell((Vector3)endPos);
            validPosition = checkValidJump(nextPosition);


        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + steps);
            nextPosition = objectTileMap.WorldToCell((Vector3)endPos);
            validPosition = checkValidJump(nextPosition);


        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - steps);
            nextPosition = objectTileMap.WorldToCell((Vector3)endPos);
            validPosition = checkValidJump(nextPosition);

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

