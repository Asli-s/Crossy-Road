
using UnityEngine;
using UnityEngine.SceneManagement;

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

    bool checkRaft = false;

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
    int moveSpeed = 0;
    public FloorData floorData;
    bool setPos = false;

    bool onRaft;
    bool moveUp = false;
    bool moveDown = false;
    bool onWater = false;
    bool dieAnim = false;
    int factor = 1;
    int raftPlayerPos;

    public GameObject RiverDeathPrefab;

    int streetCount = 0;
    int maxStreetCount = 0;
    public TMPro.TextMeshProUGUI streetCountText;
    bool updated = false;


    private void Start()
    {


        //DIE zoom


        //BIRD // camera move
        //coins
        //SOUND

        // nextfloor //delete floor

        //ANIMATIONS  -pattel, raft


        //boundaries -8, 5
        streetCount = 0;
        maxStreetCount = 0;

    }


    private void Update()
    {
        /* if (died == true && alertShow == false)
         {


         }*/


        if (Input.GetKeyDown(KeyCode.Space))
        {
            string currentSene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSene);
        }


        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            print(
       gameObject.transform.position);

            if (percentage == 1 && died == false)
            {

                lerpTime = 1;
                currentLerpTime = 0;
                justJump = true;
                nextIsRaft = false;
                checkRaft = false;
                nextIsPattel = false;
                firstInput = true;
                setPos = false;
                moveDown = false;
                moveUp = false;
                updated = false;

            }

        }
        startPos = gameObject.transform.position;


        if (Input.GetKeyDown(KeyCode.UpArrow) && clickOnce == false && died == false)
        {
            endPos = new Vector3(Mathf.Round(transform.position.x), 0, Mathf.Round(transform.position.z) + steps);
            validPosition = checkValidJump(endPos);
            clickOnce = true;
            moveUp = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && clickOnce == false && died == false)
        {
            endPos = new Vector3(Mathf.Round(transform.position.x), 0, Mathf.Round(transform.position.z) - steps);

            validPosition = checkValidJump(endPos);
            clickOnce = true;
            moveDown = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && clickOnce == false && died == false)

        {
            endPos = new Vector3(Mathf.Round(transform.position.x) + steps, 0, Mathf.Round(transform.position.z));

            validPosition = checkValidJump(endPos);
            clickOnce = true;

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && clickOnce == false && died == false)
        {
            endPos = new Vector3(Mathf.Round(transform.position.x) - steps, 0, Mathf.Round(transform.position.z));


            validPosition = checkValidJump(endPos);
            clickOnce = true;
        }


        if (firstInput == true)
        {
            currentLerpTime += Time.deltaTime * 5.5f;
            percentage = currentLerpTime / lerpTime;

            if (nextIsRaft == false && validPosition == true || nextIsPattel == true)
            {

                onRaft = false;
                if (nextIsPattel == true)
                {
                    if (setPos == false)
                    {
                        setPos = true;
                        transform.position = pattelPos;
                        print("player pos on pattel " + transform.position + " pattelpos " + pattelPos
                            );

                    }
                }
                else if (nextIsPattel == false)
                {
                    transform.position = Vector3.Lerp(startPos, endPos, percentage);

                  

                    if (onWater == true && dieAnim == false)
                    {
                        dieAnim = true;
                        Die();
                    }
                }

                if (validPosition == true && updated == false)
                {
                    updated = true;
                 
                    UpdateStreetCount();
                }


            }

            else if (nextIsRaft == true && nextIsPattel == false || validPosition == false && onRaft == true && nextIsPattel == false)
            {

                if (setPos == false && nextIsRaft == true)
                {
                    setPos = true;
                    transform.position = (raftPos);
                    print("on raft + " + raftPos);
                }

                if (transform.position.x <= 5 + raftPlayerPos && transform.position.x >= -8 - raftPlayerPos)
                {


                    transform.position += new Vector3(factor * moveSpeed, 0, 0) * Time.deltaTime;
                }
                else if (transform.position.x > 5 + raftPlayerPos || transform.position.x < -8 - raftPlayerPos)
                {
                    died = true;
                    transform.position += new Vector3(factor * moveSpeed, 0, 0) * Time.deltaTime * 10;

                }
                if ( validPosition == true && updated == false)
                {
                    updated = true;
                  
                    UpdateStreetCount();
                }

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

    void Die
        ()
    {
        Instantiate(RiverDeathPrefab, new Vector3(this.gameObject.transform.position.x, 1, this.gameObject.transform.position.z + 1), Quaternion.identity);
        this.gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    bool checkValidJump(Vector3 nextPosition)
    {
        onWater = false;
        int currentZ = (int)nextPosition.z;
        string nextName = floorData?.floorRows[currentZ]?.name;
        if (nextName == "River")
        {
            //check raft
            RiverScript riverScript = floorData.floorRows[currentZ].GetComponent<RiverScript>();


            for (int j = 0; j < floorData.floorRows[currentZ].gameObject.transform.childCount; j++)
            {


                if (riverScript.pattel == false)  //raft -not pattel
                {
                    GameObject raft = floorData.floorRows[currentZ].gameObject.transform.GetChild(j).gameObject;
                    int childNum = raft.transform.childCount;
                    for (int i = 0; i < childNum; i++)
                    {
                        if (riverScript.leftToRight == true)
                        {

                            if (nextPosition.x == Mathf.Round(raft.transform.GetChild(i).transform.position.x+0.2f) &&checkRaft ==false)
                            {
                                /**/
                                checkRaft = true;
                                raftPlayerPos = i;
                                print("raftplayer position" + raftPlayerPos);


                                factor = 1;

                                moveSpeed = riverScript.moveSpeed;
                                nextIsRaft = true;
                                onRaft = true;
                                onWater = false;
                                raftPos = new Vector3(raft.transform.GetChild(raftPlayerPos).transform.position.x+0.2f , Mathf.Round(transform.position.y), nextPosition.z + 0.1f);
                                print("yes - raft-pos " + raftPos);
                            }
                            else
                            {
                                // died ;
                                /* print("no");*/
                                onWater = true;

                            }

                        }


                        else if (riverScript.leftToRight == false)
                        {
                            if (nextPosition.x == Mathf.Round(raft.transform.GetChild(i).transform.position.x+0.2f))
                            {
                                raftPlayerPos = i; //big raft - multiple small rafts 
                                print("raftplayer position"+raftPlayerPos);
                                factor = (-1);
                                moveSpeed = riverScript.moveSpeed;
                                nextIsRaft = true;
                                onWater = false;
                           
                                raftPos = new Vector3(raft.transform.GetChild(raftPlayerPos).transform.position.x+0.2f, Mathf.Round(transform.position.y), nextPosition.z + 0.1f);
                                // }
                                onRaft = true;
                                print("yes1- raft-pos " + raftPos);
                            }
                            else
                            {

                                /*    print("no1");*/
                                onWater = true;

                            }


                        }

                    }

                }
                else if (riverScript.pattel == true)
                {
                    GameObject pattel = floorData.floorRows[currentZ].gameObject.transform.GetChild(j).gameObject;
                    if (nextPosition.x >= Mathf.Round(pattel.transform.position.x) && nextPosition.x <= (Mathf.Round(pattel.transform.position.x) + 0.3f))
                    {
                        onWater = false;
                        print("pattel  " + pattel.transform.position);

                        nextIsPattel = true;
                        pattelPos = new Vector3(pattel.transform.position.x + 0.3f, Mathf.Round(pattel.transform.position.y), nextPosition.z + 0.3f);
                    }
                    else
                    {
                        //die
                        onWater = true;
                        print("no1 pattel");

                    }

                }
            }

        }

        if (barrierObjects.transform.childCount != 0)
        {
            for (int i = 0; i < barrierObjects.transform.childCount; i++)
            {


                if (nextPosition.x == Mathf.Round(barrierObjects.transform.GetChild(i).transform.position.x))
                {

                    if (nextPosition.z == Mathf.Round(barrierObjects.transform.GetChild(i).transform.position.z))
                    {
                        print("onraft" + onRaft);
                        print("barrier");
                        return false;
                    }
                }

            }
        }



        return true;
    }




    void UpdateStreetCount()
    {

       
        if(moveDown == true)
        {
            streetCount--;
        }
        else if(moveUp ==true)
        {
            floorData.nextFloor();
            streetCount++;

        }
        if(streetCount> maxStreetCount)
        {
            maxStreetCount = streetCount;
        streetCountText.text = maxStreetCount.ToString();
        }

    }
}