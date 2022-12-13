
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    float lerpTime;
    float currentLerpTime;
    public float percentage = 1;
    Vector3 startPos;
    Vector3 endPos;
   public bool firstInput;
    public bool justJump = false;
    public float steps = 1f;

    public GameObject Player;
    public GameObject Alert;
    public GameObject barrierObjects;
    public GameObject Cam;

    bool checkRaft = false;

    bool validPosition;
    public bool moved = false;

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

    public bool onRaft;
  public bool moveUp = false;
    bool moveDown = false;
    public int downCount = 0;
    public int upCount = 0;
    bool onWater = false;
    bool dieAnim = false;
    int factor = 1;
    int raftPlayerPos;

    public GameObject RiverDeathPrefab;

    int streetCount = 0;
    int maxStreetCount = 0;
    public TMPro.TextMeshProUGUI streetCountText;
    bool updated = false;


    public bool riverDeath = false;
    bool raftDeath = false;
    PlayerFollow camScript;
    bool deathReset = false;

    int randomQuack;
    int stepCount = 0;
    bool didQuack = false;
    public bool birdDeath = false;

    Vector3 startTouchPos;
    Vector3 endTouchPos;
    bool touched = false;

    bool androidMoveUp = false;
    bool androidMoveDown = false;
    bool androidMoveLeft = false;
    bool androidMoveRight = false;






/**/


    private void Start()
    {

        streetCount = 0;
        maxStreetCount = 0;

        camScript = Cam.GetComponent<PlayerFollow>();
        Quack();

    }


    private void Update()
    {
        if (died == true && alertShow == false)
        {
            alertShow = true;
            Die();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            string currentSene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSene);
        }

        if (camScript.birdCatch == true && deathReset == false)
        {
            transform.position += new Vector3(0, 0, -1) * Time.deltaTime * 40;
        }

        else if (camScript.birdCatch == false && camScript.birdDeath == false)
        {
            if (died == false)
            {

                GetInput();

                startPos = gameObject.transform.position;

              

                if (firstInput == true)
                {


                    currentLerpTime += Time.deltaTime * 3.5f;
                    percentage = currentLerpTime / lerpTime;

                    MovePlayer();

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
    }

    void GetInput()
    {

        if (Application.platform == RuntimePlatform.Android && died==false)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPos = Input.GetTouch(0).position;
              
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPos = Input.GetTouch(0).position;


                if (startTouchPos.y - 5 <= endTouchPos.y && Mathf.Abs(endTouchPos.y - startTouchPos.y) >= Mathf.Abs(endTouchPos.x - startTouchPos.x - 5) &&touched == false|| Input.touchCount == 0)
                {
                    touched = true;
                    
                    androidMoveUp = true;
                }
                else if (startTouchPos.x < endTouchPos.x && Mathf.Abs(endTouchPos.y - startTouchPos.y) < Mathf.Abs(endTouchPos.x - startTouchPos.x) && touched == false)
                {
                    touched = true;
                    androidMoveRight = true;
                }
                else if (startTouchPos.x > endTouchPos.x && Mathf.Abs(endTouchPos.y - startTouchPos.y) < Mathf.Abs(endTouchPos.x - startTouchPos.x) && touched == false)
                {
                    touched = true;
                    androidMoveLeft = true;

                }
                else if (startTouchPos.y - 5 > endTouchPos.y && Mathf.Abs(endTouchPos.y - startTouchPos.y) >= Mathf.Abs(endTouchPos.x - startTouchPos.x) && touched == false)
                {
                    touched = true;
                    androidMoveDown = true;

                }
                else
                {
                    touched = true;
                    androidMoveUp = true;
                }


                if (touched = true && transform.position.x > -8 && transform.position.x < 7)
                {
                    touched = false;

                    if (firstInput == false)
                    {
                        PlayQuackSound();
                    }

                    if (percentage == 1 && died == false && camScript.birdDeath == false)
                    {

                        lerpTime = 1;
                        currentLerpTime = 0;
                        justJump = true;
                        nextIsRaft = false;
                        checkRaft = false;
                        nextIsPattel = false;
                        firstInput = true;
                        setPos = false;
                        onWater = false;
                        moveDown = false;
                        moveUp = false;
                        updated = false;
                        moved = false;
                        stepCount++;
                        if (stepCount == randomQuack && didQuack == false)
                        {
                            didQuack = true;
                            PlayQuackSound();
                            Quack();
                        }
                    }
                    HandleInput();
                }

            }
           

        }

        else
        {

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x > -8 && transform.position.x < 7)
            {

                if (firstInput == false)
                {
                    PlayQuackSound();
                }

                if (percentage == 1 && died == false && camScript.birdDeath == false)
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
                    moved = false;
                    stepCount++;
                    if (stepCount == randomQuack && didQuack == false)
                    {
                        didQuack = true;
                        PlayQuackSound();
                        Quack();
                    }
                }
                HandleInput();
            }


        }



    }


    void HandleInput()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) && clickOnce == false && died == false || (androidMoveUp == true && clickOnce == false && died == false))
        {
            endPos = new Vector3(Mathf.Round(transform.position.x), 0, Mathf.Round(transform.position.z) + steps);
            validPosition = checkValidJump(endPos);
            clickOnce = true;
            moveUp = true;
          
            downCount = 0;
            ResetAndroidInput();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && clickOnce == false && died == false || (androidMoveDown == true && clickOnce == false && died == false))
        {
            endPos = new Vector3(Mathf.Round(transform.position.x), 0, Mathf.Round(transform.position.z) - steps);
            upCount =0;
            
            validPosition = checkValidJump(endPos);
            clickOnce = true;
            moveDown = true;
            downCount++;
            if (downCount == 3 && validPosition)
            {

                Cam.GetComponent<PlayerFollow>().BirdDeath();
            }
            ResetAndroidInput();

        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && clickOnce == false && died == false || (androidMoveRight == true && clickOnce == false && died == false))

        {
            upCount = 0;

            endPos = new Vector3(Mathf.Round(transform.position.x) + steps, 0, Mathf.Round(transform.position.z));

            validPosition = checkValidJump(endPos);
            clickOnce = true;
            ResetAndroidInput();


        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && clickOnce == false && died == false || (androidMoveLeft == true && clickOnce == false && died == false))
        {
            endPos = new Vector3(Mathf.Round(transform.position.x) - steps, 0, Mathf.Round(transform.position.z));
            upCount = 0;
            validPosition = checkValidJump(endPos);
            clickOnce = true;
            ResetAndroidInput();

        }

    }




    bool checkValidJump(Vector3 nextPosition)
    {
        onWater = false;
        int currentZ = (int)nextPosition.z;
        string nextName = floorData?.floorRows[currentZ]?.name;
        if (nextName == "River")
        {

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

                            if (nextPosition.x == Mathf.Round(raft.transform.GetChild(i).transform.position.x + 0.22f) && checkRaft == false)
                            {
                                checkRaft = true;
                                raftPlayerPos = i;
                                factor = 1;
                                moveSpeed = riverScript.moveSpeed;
                                nextIsRaft = true;
                                onRaft = true;
                                onWater = false;
                                raftPos = new Vector3(raft.transform.GetChild(raftPlayerPos).transform.position.x + 0.15f, Mathf.Round(transform.position.y), nextPosition.z + 0.1f);


                                for (int k = 0; k < childNum; k++)
                                {

                                    Animator anim = raft.transform.GetChild(k).GetChild(0).gameObject.GetComponent<Animator>();

                                    anim.SetBool("onRaft", true);
                                }
                            }
                            else if (nextPosition.x != Mathf.Round(raft.transform.GetChild(i).transform.position.x + 0.2f) && checkRaft == false)
                            {

                                onWater = true;

                            }

                        }


                        else if (riverScript.leftToRight == false)
                        {
                            if (nextPosition.x == Mathf.Round(raft.transform.GetChild(i).transform.position.x + 0.2f) && checkRaft == false)
                            {
                                checkRaft = true;
                                raftPlayerPos = i;
                                factor = (-1);
                                moveSpeed = riverScript.moveSpeed;
                                nextIsRaft = true;
                                onWater = false;

                                for (int k = 0; k < raft.transform.childCount; k++)
                                {
                                    Animator anim = raft.transform.GetChild(k).GetChild(0).gameObject.GetComponent<Animator>();

                                    anim.SetBool("onRaft", true);
                                }

                                raftPos = new Vector3(raft.transform.GetChild(raftPlayerPos).transform.position.x + 0.19f, Mathf.Round(transform.position.y), nextPosition.z + 0.1f);

                                onRaft = true;
                            }
                            else if (nextPosition.x != Mathf.Round(raft.transform.GetChild(i).transform.position.x + 0.2f) && checkRaft == false)
                            {


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

                        Animator anim = pattel.transform.GetChild(0).gameObject.GetComponent<Animator>();

                        anim.SetBool("onPattel", true);
                        nextIsPattel = true;
                        pattelPos = new Vector3(pattel.transform.position.x + 0.3f, Mathf.Round(pattel.transform.position.y), nextPosition.z + 0.3f);

                    }
                    else
                    {

                        onWater = true;

                    }

                }
            }

        }
/**/
        else
        {
            onWater = false;
        }
/**/
        if (nextName == "Street")
        {
            FindObjectOfType<TrafficSound>().PlayCarHornSound();
        }
        if (barrierObjects.transform.childCount != 0)
        {
            for (int i = 0; i < barrierObjects.transform.childCount; i++)
            {


                if (nextPosition.x == Mathf.Round(barrierObjects.transform.GetChild(i).transform.position.x))
                {

                    if (nextPosition.z == Mathf.Round(barrierObjects.transform.GetChild(i).transform.position.z))
                    {

                        return false;
                    }
                }

            }
        }
        if (nextPosition.x < -7 || nextPosition.x > 5)
        {
            return false;

        }

        return true;
    }



    void MovePlayer()
    {
        if (nextIsRaft == true && nextIsPattel == false || validPosition == false && onRaft == true && nextIsPattel == false)
        {

            if (setPos == false && nextIsRaft == true)
            {
                setPos = true;
                transform.position = (raftPos);

                FindObjectOfType<AudioManager>().Play("Raft");

            }

            if (transform.position.x <= 5 + raftPlayerPos && transform.position.x >= -8 - raftPlayerPos)
            {


                transform.position += new Vector3(factor * moveSpeed, 0, 0) * Time.deltaTime;
            }
            else if (transform.position.x > 5 + raftPlayerPos || transform.position.x < -8 - raftPlayerPos)
            {
                died = true;
                raftDeath = true;
                transform.position += new Vector3(factor * moveSpeed, 0, 0) * Time.deltaTime * 10;

            }
            if (validPosition == true && updated == false)
            {
                updated = true;
                moved = true;
                Cam.GetComponent<PlayerFollow>().alreadyCalled = false;
                UpdateStreetCount();
            }
        }

        else if (nextIsRaft == false && validPosition == true || nextIsPattel == true)
        {

            onRaft = false;
            if (nextIsPattel == true)
            {
                if (setPos == false)
                {
                    setPos = true;
                    transform.position = pattelPos;


                    FindObjectOfType<AudioManager>().Play("Raft");

                }
            }
            else if (nextIsPattel == false)
            {
                transform.position = Vector3.Lerp(startPos, endPos, percentage);


                if (onWater == true && dieAnim == false)
                {
                    dieAnim = true;
                    riverDeath = true;
                    Die();
                }
            }
            if (validPosition == true && updated == false)
            {
                updated = true;
                moved = true;
                Cam.GetComponent<PlayerFollow>().alreadyCalled = false;
                UpdateStreetCount();
            }

        }



    }




    void Die()
    {
        if (riverDeath == true )
        {
            died = true;
            FindObjectOfType<AudioManager>().Play("Water");
            
            Instantiate(RiverDeathPrefab, new Vector3(this.gameObject.transform.position.x, 1, this.gameObject.transform.position.z + 1), Quaternion.identity);
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
        if (raftDeath)
        {
            FindObjectOfType<AudioManager>().Play("WaterSlide");
            StopPlayerMovement();

        }
        Invoke("ActivateRestartAlert", 0.4f);
    }


    void ResetAndroidInput()
    {
        touched = false;
        androidMoveUp = false;
        androidMoveDown = false;
        androidMoveLeft = false;
        androidMoveRight = false;
    }



   

    void Quack()
    {
        stepCount = 0;
        didQuack = false;
        randomQuack = Random.Range(1, 6);



    }



    void PlayQuackSound()
    {
        FindObjectOfType<AudioManager>().Play("Quack");

    }




    void ActivateRestartAlert()
    {
        Alert.SetActive(true);
        if (camScript.birdDeath == true)
        {

            Invoke("StopPlayerMovement", 0.2f);
        }
       
    }




    void StopPlayerMovement()
    {
        deathReset = true;
        camScript.birdDeath = false;
        transform.position = new Vector3(0, 0, -100);
    }






    void UpdateStreetCount()
    {


        if (moveDown == true)
        {
            streetCount--;
        }
        else if (moveUp == true)
        {
            upCount++;
            streetCount++;


        }
        if (streetCount > maxStreetCount)
        {
            floorData.nextFloor(streetCount);
            maxStreetCount = streetCount;
            streetCountText.text = maxStreetCount.ToString();
        }


    }



}
    