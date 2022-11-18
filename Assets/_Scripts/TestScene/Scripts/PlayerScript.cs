using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerScript : MonoBehaviour
{
    float lerpTime;
    float currentLerpTime;
    public float percentage = 1;
    Vector3 startPos;
    Vector3 endPos;
    bool firstInput;
    public bool justJump = false;
    public float steps = 1f;

    public GameObject Player;
    public GameObject Alert;
    public GameObject barrierObjects;


    Vector3Int nextPosition;
    bool validPosition;

    bool clickOnce = false;
    public bool died = false;
    bool alertShow = false;
    public bool onWood = false;
    public bool left = false;
    public int woodSpeed = 3;

    bool nextIsRaft = false;
    bool nextIsPattel = false;
    Vector3 pattelPos;
    Vector3 raftPos;
    int moveFactor = 0;
    public FloorData floorData;
    bool setPos = false;

    bool onRaft;



    private void Start()
    {
        // TODO 

        //DIE BORDERSS
        //BIRD
        //SOUND
        //NEXT LEVEL GENERATION
        //ANIMATIONS

    }


    private void Update()
    {
        /* if (died == true && alertShow == false)
         {


         }*/
        if (died == false)
        {

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {

                if (percentage == 1)
                {
                    lerpTime = 1;
                    currentLerpTime = 0;
                    justJump = true;
                    nextIsRaft = false;
                    nextIsPattel = false;
                    firstInput = true;
                    setPos = false;

                }

            }
            startPos = gameObject.transform.position;


            if (Input.GetKeyDown(KeyCode.UpArrow) && clickOnce == false)
            {
                endPos = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z) + steps);
                validPosition = checkValidJump(endPos);
                clickOnce = true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && clickOnce == false)
            {
                endPos = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z) - steps);

                validPosition = checkValidJump(endPos);
                clickOnce = true;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && clickOnce == false)

            {
                endPos = new Vector3(Mathf.Round(transform.position.x) + steps, Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));

                validPosition = checkValidJump(endPos);
                clickOnce = true;

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && clickOnce == false)
            {
                endPos = new Vector3(Mathf.Round(transform.position.x) - steps, Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));


                validPosition = checkValidJump(endPos);
                clickOnce = true;
            }

            if (firstInput == true)
            {
                currentLerpTime += Time.deltaTime * 5.5f;
                percentage = currentLerpTime / lerpTime;

                if (nextIsRaft == false && validPosition )
                {
                   

                     
                        onRaft = false;
                        if (nextIsPattel == true)
                        {

                            if (setPos == false)
                            {
                                setPos = true;
                                transform.position = (pattelPos);
                            }

                        }else

                        transform.position = Vector3.Lerp(startPos, endPos, percentage);
                        

                    
    
                }
               
                else if(nextIsRaft == true || validPosition ==false && onRaft ==true )
                {
                  
                    if (setPos == false && nextIsRaft ==true)
                    {
                        setPos = true;
                        transform.position = (raftPos);
                    }

                    transform.position += new Vector3(moveFactor, 0, 0) * Time.deltaTime;
                }


                if (percentage > 0.8f)
                {
                    percentage = 1;
                    justJump = false;
                    clickOnce = false;
                }
                if (Mathf.Round(percentage) == 1)
                {
                    justJump = false;
                }


                if (startPos == endPos || validPosition == false)
                {
                    clickOnce = false;
                }
            }
        }
    }




    bool checkValidJump(Vector3 nextPosition)
    {

        int currentZ = (int)nextPosition.z;
        string nextName = floorData?.floorRows[currentZ]?.name;
        if (nextName == "River")
        {
            //check raft
            RiverScript riverScript = floorData.floorRows[currentZ].GetComponent<RiverScript>();


            for (int j = 0; j < floorData.floorRows[currentZ].gameObject.transform.childCount; j++)
            {


                if (riverScript.pattel == false)
                {
                    GameObject raft = floorData.floorRows[currentZ].gameObject.transform.GetChild(j).gameObject;
                    int childNum = raft.transform.childCount;
                    for (int i = 0; i < childNum; i++)
                    {
                        if (riverScript.leftToRight == true)
                        {
                            print(nextPosition.x);
                            print(Mathf.Round(raft.transform.GetChild(i).transform.position.x));
                            if (nextPosition.x >= Mathf.Round(raft.transform.GetChild(i).transform.position.x) && nextPosition.x <= (Mathf.Round(raft.transform.GetChild(i).transform.position.x + .9f)))
                            {
                                print("yes");
                                moveFactor = riverScript.moveSpeed;
                                raftPos = new Vector3(raft.transform.GetChild(i).transform.position.x, this.gameObject.transform.position.y, nextPosition.z);
                                nextIsRaft = true;
                                onRaft = true;
                            }
                            else
                            {
                                // died = true;
                            }

                        }


                        else if(riverScript.leftToRight==false)
                        {
                            if (nextPosition.x == Mathf.Round(raft.transform.GetChild(i).transform.position.x))
                            {
                                print("yes1");
                                moveFactor = -  riverScript.moveSpeed;
                                nextIsRaft = true;
                                onRaft = true;

                                raftPos = new Vector3(raft.transform.GetChild(i).transform.position.x, this.gameObject.transform.position.y, nextPosition.z);
                            }
                            else
                            {
                                // died = true;
                            }


                        }

                    }

                }
                else if (riverScript.pattel == true)
                {
                    GameObject pattel = floorData.floorRows[currentZ].gameObject.transform.GetChild(j).gameObject;
                     if (nextPosition.x >= Mathf.Round(pattel.transform.position.x) && nextPosition.x <= (Mathf.Round(pattel.transform.position.x ) +0.3f))
                    {
                        print("pattel" + pattel.transform.position);
                    
                        nextIsPattel = true;
                        pattelPos = new Vector3(pattel.transform.position.x +0.3f, this.gameObject.transform.position.y, nextPosition.z);
                    }
                    else
                    {
                        //die
                    }

                }
            }

        }
        print(nextPosition.x);
        print(nextPosition.z);
        if (barrierObjects.transform.childCount != 0)
        {
            for (int i = 0; i < barrierObjects.transform.childCount; i++)
            {


                if (nextPosition.x == Mathf.Round(barrierObjects.transform.GetChild(i).transform.position.x))
                {

                    if (nextPosition.z == Mathf.Round(barrierObjects.transform.GetChild(i).transform.position.z))
                    {
                        print("onraft"+ onRaft);
                        print("barrier");
                        return false;
                    }
                }

            }
        }

        print("nextRow name  " + nextName);

        return true;
    }



}
