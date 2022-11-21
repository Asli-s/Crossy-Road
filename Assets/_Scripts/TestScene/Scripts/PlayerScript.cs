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
    bool onWater = false;
    bool dieAnim = false;
    int factor = 1;
    int raftPlayerPos;

    public GameObject RiverDeathPrefab;


    private void Start()
    {
        // TODO 

        //DIE zoom


        //BIRD
        //SOUND
     
        //make 3 raft

        //ANIMATIONS  -pattel, raft


        //boundaries -8, 5
        //-riveranim boundaries + 
        
        //-plantobjects boundaries
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

                if (percentage == 1 && died == false)
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


            if (Input.GetKeyDown(KeyCode.UpArrow) && clickOnce == false &&died ==false)
            {
                endPos = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z) + steps);
                validPosition = checkValidJump(endPos);
                clickOnce = true;
                moveUp = true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && clickOnce == false && died == false)
            {
                endPos = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z) - steps);

                validPosition = checkValidJump(endPos);
                clickOnce = true;
                moveUp = false;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && clickOnce == false && died == false)

            {
                endPos = new Vector3(Mathf.Round(transform.position.x) + steps, Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));

                validPosition = checkValidJump(endPos);
                clickOnce = true;
                moveUp = false;

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && clickOnce == false && died == false)
            {
                endPos = new Vector3(Mathf.Round(transform.position.x) - steps, Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));


                validPosition = checkValidJump(endPos);
                clickOnce = true;
                moveUp = false;
            }


            if (firstInput == true)
            {
                currentLerpTime += Time.deltaTime * 5.5f;
                percentage = currentLerpTime / lerpTime;

                if (nextIsRaft == false && validPosition )
                {
                   

                        if (moveUp == true)
                        {
                            floorData.nextFloor();
                            moveUp = false;
                        }
                  
                        onRaft = false;
                        if (nextIsPattel == true)
                        {

                            if (setPos == false)
                            {
                                setPos = true;
                                transform.position = (pattelPos);
                            }


                        }else
                    {

                        transform.position = Vector3.Lerp(startPos, endPos, percentage);
                        if (onWater == true && dieAnim == false)
                        {
                            dieAnim = true;
                            Die();
                        }
                    }
                        

                    
    
                }
               
                else if(nextIsRaft == true || validPosition ==false && onRaft ==true )
                {
                  
                    if (setPos == false && nextIsRaft ==true)
                    {
                        setPos = true;
                        transform.position = (raftPos);
                    }
                    if (moveUp == true)
                    {
                        floorData.nextFloor();
                        moveUp = false;
                    }
                    if (transform.position.x <= 5+raftPlayerPos &&transform.position.x >=-8 -raftPlayerPos)
                    transform.position += new Vector3(factor*moveSpeed, 0, 0) * Time.deltaTime;
                   else if (transform.position.x > 5+raftPlayerPos|| transform.position.x< -8 -raftPlayerPos)
                    {
                        died = true;
                   transform.position += new Vector3(factor * moveSpeed, 0, 0) * Time.deltaTime*10;

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
                    moveUp = false;
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
                                raftPlayerPos = i;
                                print(raftPlayerPos);

                                print("yes");
                                factor = 1;
                                    
                                 moveSpeed=   riverScript.moveSpeed;
                                raftPos = new Vector3(raft.transform.GetChild(i).transform.position.x, this.gameObject.transform.position.y, nextPosition.z);
                                nextIsRaft = true;
                                onRaft = true;
                                onWater = false;
                            }
                            else
                            {
                                // died = true;
                                print("no");
                                onWater = true;
                             
                            }

                        }


                        else if(riverScript.leftToRight==false)
                        {
                            if (nextPosition.x == Mathf.Round(raft.transform.GetChild(i).transform.position.x))
                            {
                                raftPlayerPos = i;
                                print(raftPlayerPos);
                                print("yes1");
                                factor = (-1);  
                               moveSpeed=     riverScript.moveSpeed;
                                nextIsRaft = true;
                                onRaft = true;
                                onWater = false;

                                raftPos = new Vector3(raft.transform.GetChild(i).transform.position.x, this.gameObject.transform.position.y, nextPosition.z);
                            }
                            else
                            {
                                // died = true;
                                print("no1");
                                onWater = true;

                                }


                        }

                    }

                }
                else if (riverScript.pattel == true)
                {
                    GameObject pattel = floorData.floorRows[currentZ].gameObject.transform.GetChild(j).gameObject;
                     if (nextPosition.x >= Mathf.Round(pattel.transform.position.x) && nextPosition.x <= (Mathf.Round(pattel.transform.position.x ) +0.3f))
                    {
                        onWater = false;
                        print("pattel" + pattel.transform.position);
                    
                        nextIsPattel = true;
                        pattelPos = new Vector3(pattel.transform.position.x +0.3f, this.gameObject.transform.position.y, nextPosition.z);
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
