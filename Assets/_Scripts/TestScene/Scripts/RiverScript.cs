using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverScript : MonoBehaviour
{
    GameObject Raft;
    GameObject instantiatedRaft;
    Vector3 startPos = new Vector3(30, 0, 0);
    Vector3 moveVector = new Vector3(-1, 0, 0);
    public List<GameObject> raftObjects = new List<GameObject>();
    GameObject raftParent;
    int randomPos;
    Vector3 position;
   public bool leftToRight
        = false;

    int randomDirection;
    bool alreadyMadeRaft =false;


    void Start()

    {
        randomDirection = Random.Range(0, 2);
        if(randomDirection == 0)
        {
        randomPos = Random.Range(-2, 9);
            leftToRight = false;
        }
        else
        {
            randomPos = Random.Range(-9, 2);

            leftToRight = true;
        }
        position = new Vector3(randomPos, 0, this.gameObject.transform.position.z);
        Raft = this.gameObject.transform.parent.GetComponent<FloorData>().raftObject;
        raftParent = new GameObject();
        raftParent.name = "raftParent";
       
         raftParent.gameObject.transform.position = new Vector3(randomPos/10, -.8f, this.gameObject.transform.position.z);
        raftParent.transform.SetParent(this.gameObject.transform);
        instantiatedRaft = Instantiate(Raft, new Vector3(0, -.5f, this.gameObject.transform.position.z) , Quaternion.identity);
        instantiatedRaft.transform.SetParent(raftParent.transform);
        instantiatedRaft = Instantiate(Raft, new Vector3(1, -.5f, this.gameObject.transform.position.z) , Quaternion.identity);
        instantiatedRaft.transform.SetParent(raftParent.transform);
        raftObjects.Add(raftParent);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.childCount ==1)
        {
            if(raftParent != null )
            {

//        raftParent.transform.position += moveVector * Time.deltaTime;
            }
 if( alreadyMadeRaft ==false)
            {

            MakeNewRaft(this.gameObject.transform.GetChild(0).gameObject.transform.position);
                alreadyMadeRaft = true;
            }



        }
        if(this.gameObject.transform.childCount == 2)
        {
            if (alreadyMadeRaft == false)
            {

                MakeNewRaft(this.gameObject.transform.GetChild(1).gameObject.transform.position);
                alreadyMadeRaft = true;
            }

        }
    }

void MakeNewRaft(Vector3 pos)
    {

        if (leftToRight == false)
        {
            randomPos = Random.Range((int)pos.x + 4, (int)pos.x + 8);
        }
        else
        {
            randomPos = Random.Range((int)pos.x - 4, (int)pos.x - 8);

        }
        position = new Vector3(randomPos, 0, this.gameObject.transform.position.z);

        raftParent = new GameObject();
        raftParent.name = "raftParent";

        raftParent.gameObject.transform.position = new Vector3(randomPos/10, -.8f, this.gameObject.transform.position.z);
        raftParent.transform.SetParent(this.gameObject.transform);
        instantiatedRaft = Instantiate(Raft, new Vector3(0, -.5f, this.gameObject.transform.position.z), Quaternion.identity);
        instantiatedRaft.transform.SetParent(raftParent.transform);
        instantiatedRaft = Instantiate(Raft, new Vector3(1, -.5f, this.gameObject.transform.position.z), Quaternion.identity);
        instantiatedRaft.transform.SetParent(raftParent.transform);
        raftObjects.Add(raftParent);
        alreadyMadeRaft = false;
    }

}
