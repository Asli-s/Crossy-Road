using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    // Start is called before the first frame update
    float lerpTime;
    float currentLerpTime;
   public float percentage = 1;

    Vector3 startPos;
    Vector3 endPos;

    bool firstInput;
    public bool justJump= false;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (percentage == 1)
            {
                lerpTime = 1;
                currentLerpTime = 0;
                firstInput = true;
                justJump = true;
            }
        }
        startPos = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.RightArrow) && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
        }
        if(firstInput == true)
        {

        currentLerpTime += Time.deltaTime * 5.5f;
        percentage = currentLerpTime / lerpTime;
        gameObject.transform.position = Vector3.Lerp(startPos, endPos, percentage);

            if(percentage > 0.8f)
            {
                percentage = 1;
            }
            if (Mathf.Round(percentage) == 1)
            {
                justJump = false;
            }


        }
    }
}

