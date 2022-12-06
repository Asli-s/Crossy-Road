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
        MakeCoin();
    }

    void MakeCoin()
    {

        int randomCoinNum = Random.Range(0, 8);
        if (randomCoinNum == 0) //probability = 1/8
        {
            GameObject Coin = GetComponentInParent<RiverScript>().GetComponentInParent<FloorData>().CoinObject;

            int raftCoinPlace = Random.Range(0, this.gameObject.transform.childCount);

            GameObject coinObject = Instantiate(Coin, new Vector3(this.gameObject.transform.GetChild(raftCoinPlace).transform.position.x, this.gameObject.transform.position.y + 0f, this.gameObject.transform.position.z - 0.3f), Quaternion.Euler(0, 0, 0));

            coinObject.transform.SetParent(this.gameObject.transform.GetChild(raftCoinPlace).transform);

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

