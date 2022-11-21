using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : MonoBehaviour
{
    // Start is called before the first frame update
    bool leftToRight;
    int moveSpeed;
    Vector3 moveVector;
    bool calledOnce = false;
    int randomPosition;
    RiverScript riverScript;
    bool adjustSpeed = false;


    void Start()
    {
        riverScript = GetComponentInParent<RiverScript>();
        leftToRight = riverScript.leftToRight;
        moveSpeed = riverScript.moveSpeed;
        moveVector = new Vector3(moveSpeed, 0, 0);
        if (leftToRight == false)
        {
            transform.rotation *= Quaternion.Euler(0, 180, 0);
        }
    }

    void Update()
    {
        if (leftToRight == true)
        {
            this.gameObject.transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
            if (this.gameObject.transform.position.x > -2 && calledOnce == false)
            {
                calledOnce = true;
                randomPosition = Random.Range(-11, -18);
                riverScript.MakeNewRaft(randomPosition);


            }
            if (this.gameObject.transform.GetChild(0).gameObject.transform.position.x > 5 && adjustSpeed == false)
            {
                moveSpeed *= 10;
                adjustSpeed = true;
            }
            if (this.gameObject.transform.position.x > 17)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (this.gameObject.transform.position.x < 5 && calledOnce == false)
            {
                calledOnce = true;
                randomPosition = Random.Range(9, 16);

                riverScript.MakeNewRaft(randomPosition);



            }


            if (this.gameObject.transform.GetChild(0).gameObject.transform.position.x < -8 && adjustSpeed == false)
            {
                moveSpeed *= 10;
                adjustSpeed = true;
            }

            if (this.gameObject.transform.position.x < -17)
            {
                Destroy(this.gameObject);
            }
            this.gameObject.transform.position -= new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        }

    }

}

