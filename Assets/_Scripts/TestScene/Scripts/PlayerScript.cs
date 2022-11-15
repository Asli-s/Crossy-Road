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
    Vector3 raftPos;
    int moveFactor = 0;
    public FloorData floorData;
    bool setPos = false;





    private void Start()
    {

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
                    firstInput = true;
                    setPos = false;

                }

            }
            startPos = gameObject.transform.position;


            if (Input.GetKeyDown(KeyCode.UpArrow) && clickOnce == false)
            {
                endPos = ExactPos(new Vector3(transform.position.x, transform.position.y, transform.position.z + steps));
                validPosition = checkValidJump(endPos);
                clickOnce = true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && clickOnce == false)
            {
                endPos = ExactPos(new Vector3(transform.position.x, transform.position.y, transform.position.z - steps));
                validPosition = checkValidJump(endPos);
                clickOnce = true;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && clickOnce == false)

            {
                endPos = ExactPos(new Vector3(transform.position.x + steps, transform.position.y, transform.position.z));
                validPosition = checkValidJump(endPos);
                clickOnce = true;

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && clickOnce == false)
            {
                endPos = ExactPos(new Vector3(transform.position.x - steps, transform.position.y, transform.position.z));
                validPosition = checkValidJump(endPos);
                clickOnce = true;
            }

            if (firstInput == true)
            {
                currentLerpTime += Time.deltaTime * 5.5f;
                percentage = currentLerpTime / lerpTime;

                if (nextIsRaft == false)
                {
                    if (validPosition)
                    {
                        transform.position = Vector3.Lerp(startPos, endPos, percentage);

                    }
                }
                else
                {
                    if (setPos == false)
                    {
                        setPos = true;
                        transform.position = (raftPos);
                    }
                    //check left/ right movement
                    transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
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
        string nextName = floorData.floorRows[currentZ].name;
        if (nextName == "River")
        {
            //check raft
            GameObject raft = floorData.floorRows[currentZ].gameObject.transform.GetChild(0).gameObject;
            int childNum = raft.transform.childCount;
            for (int i = 0; i < childNum; i++)
            {

                if (nextPosition.x == Mathf.Round(raft.transform.GetChild(i).transform.position.x))
                {
                    print("yes");
                    moveFactor = 0;
                    raftPos = new Vector3(raft.transform.GetChild(i).transform.position.x, this.gameObject.transform.position.y, nextPosition.z);
                    nextIsRaft = true;
                }
                else
                {
                    // died = true;
                }

            }

        }
        print(nextPosition.x);
        print(nextPosition.z);
        if (barrierObjects.transform.childCount != 0)
        {
            for (int i = 0; i < barrierObjects.transform.childCount; i++)
            {
                /* if(barrierObjects.transform. GetChild(j).childCount != 0) {
                     for (int i = 0; i < barrierObjects.transform.GetChild(j).childCount; i++)
                     {*/

                if (nextPosition.x == Mathf.Round(barrierObjects.transform.GetChild(i).transform.position.x))
                {

                    if (nextPosition.z == Mathf.Round(barrierObjects.transform.GetChild(i).transform.position.z))
                    {
                        return false;
                    }
                }
                // }
                //  }
            }
        }

        print("nextRow name  " + nextName);

        return true;
    }





    Vector3 ExactPos(Vector3 position)
    {
        position.x = Mathf.Round(position.x);
        position.z = Mathf.Round(position.z);

        return position;
    }
}