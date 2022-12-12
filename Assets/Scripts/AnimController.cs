using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{


    Animator anim;
    public GameObject Player;
    PlayerScript playerScript;

    Vector3 startTouchPos;
    Vector3 endTouchPos;
    bool touched = false;

    bool androidMoveUp = false;
    bool androidMoveDown = false;
    bool androidMoveLeft = false;
    bool androidMoveRight = false;


    void Start()
    {

        anim = gameObject.GetComponent<Animator>();
        playerScript = Player.GetComponent<PlayerScript>();

    }

    // Update is called once per frame
    void Update()
    {

        if (playerScript.justJump == true)
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);

        }

        if (Application.platform == RuntimePlatform.Android)
        {


            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPos = Input.GetTouch(0).position;
                touched = false;
                androidMoveUp = false;
                androidMoveDown = false;
                androidMoveLeft = false;
                androidMoveRight = false;
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPos = Input.GetTouch(0).position;


                if (startTouchPos.y <= endTouchPos.y && Mathf.Abs(endTouchPos.y - startTouchPos.y) >= Mathf.Abs(endTouchPos.x - startTouchPos.x) || Input.touchCount == 0)
                {
                    touched = true;
                    androidMoveUp = true;
                }
                else if (startTouchPos.x < endTouchPos.x && Mathf.Abs(endTouchPos.y - startTouchPos.y) < Mathf.Abs(endTouchPos.x - startTouchPos.x))
                {
                    touched = true;
                    androidMoveRight = true;
                }
                else if (startTouchPos.x > endTouchPos.x && Mathf.Abs(endTouchPos.y - startTouchPos.y) < Mathf.Abs(endTouchPos.x - startTouchPos.x))
                {
                    touched = true;
                    androidMoveLeft = true;

                }
                else if (startTouchPos.y > endTouchPos.y && Mathf.Abs(endTouchPos.y - startTouchPos.y) >= Mathf.Abs(endTouchPos.x - startTouchPos.x))
                {
                    touched = true;
                    androidMoveDown = true;

                }
            }
        }
        if (playerScript.died == false)
        {

            if (Input.GetKeyDown(KeyCode.RightArrow) || androidMoveRight == true)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                androidMoveRight = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || androidMoveLeft == true)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
                androidMoveLeft = false;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || androidMoveUp == true)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                androidMoveUp = false;

            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || androidMoveDown == true)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                androidMoveDown = false;

            }
        }


    }
}