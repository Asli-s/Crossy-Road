using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverScript : MonoBehaviour
{
    GameObject Raft;
    GameObject instantiatedRaft; 
    GameObject Pattel;
    GameObject instantiatedPattel;

    GameObject LeftRiverBorder;
    GameObject RightRiverBorder;

    public List<GameObject> raftObjects = new List<GameObject>();
    GameObject raftParent;
    int randomPos;
    public bool leftToRight = false;

    int randomDirection;
    bool alreadyMadeRaft1 = false;
    bool alreadyMadeRaft2 = false;
    bool alreadyMadeRaft3 = false;

    float zAdjust = -0.1f;
    float xAdjust = 0.2f;

   public bool pattel = false;
    int randomRiverType;

   
   public int moveSpeed =1;

    void Start()

    {



    
        randomRiverType = Random.Range(0, 3);

        if (randomRiverType == 0 )
        {
            pattel = true;
            MakePattel();
        }
        else if (randomRiverType == 1 || randomRiverType == 2)
        {
            moveSpeed = Random.Range(1, 4); 


            pattel = false;
            randomDirection = Random.Range(0, 2);
            if (randomDirection == 0)
            {
                leftToRight = false;

                LeftRiverBorder = this.gameObject.GetComponentInParent<FloorData>().LeftRiverBorder;
                Instantiate(LeftRiverBorder, new Vector3(-8, -.52f, transform.position.z), Quaternion.identity);
            }
            else
            {
                RightRiverBorder = this.gameObject.GetComponentInParent<FloorData>().RightRiverBorder;
                Instantiate(RightRiverBorder, new Vector3(6, -.52f, transform.position.z), Quaternion.identity);


                leftToRight = true;
            }
            MakeFirstRaft();
        }
    }

    void Update()
    {
        if (pattel == false)
        {
            if (this.gameObject.transform.childCount == 1)
            {

                if (alreadyMadeRaft1 == false)
                {

                    alreadyMadeRaft1 = true;
                    MakeNewRaft(this.gameObject.transform.GetChild(0).gameObject.transform.position);
                }

            }
            if (this.gameObject.transform.childCount == 2)
            {


                if (alreadyMadeRaft2 == false)
                {

                    alreadyMadeRaft2 = true;
                    MakeNewRaft(this.gameObject.transform.GetChild(1).gameObject.transform.position);
                }

            }
            if (this.gameObject.transform.childCount == 3)
            {


                if (alreadyMadeRaft3 == false)
                {

                    alreadyMadeRaft3 = true;
                    MakeNewRaft(this.gameObject.transform.GetChild(2).gameObject.transform.position);
                }

            }
        }
    }

    void MakePattel()
    {
        int RandomPattelAmount = Random.Range(3,7);
        int RandomPattelPlace;

        List<int> PattelsXPos = new List<int>();

        for (int i = 0; i < RandomPattelAmount; i++)
        {
           RandomPattelPlace  = Random.Range(-5, 8);
            Pattel = this.gameObject.transform.parent.GetComponent<FloorData>().pattelObject;

            
        instantiatedPattel = Instantiate(Pattel, new Vector3(RandomPattelPlace-.3f,transform.position.y+0.6f ,transform.position.z+0.4f), Quaternion.identity);
            instantiatedPattel.transform.SetParent(this.gameObject.transform);
            PattelsXPos.Add(RandomPattelPlace);
            if (!PattelsXPos.Contains(0))
            {
                instantiatedPattel = Instantiate(Pattel, new Vector3(0 - .3f, transform.position.y + 0.6f, transform.position.z + 0.4f), Quaternion.identity);
                instantiatedPattel.transform.SetParent(this.gameObject.transform);
                PattelsXPos.Add(RandomPattelPlace);
            }
            
          
        }

    }


    void MakeFirstRaft()
    {
            

        randomPos = Random.Range(-5, 10);
        raftParent = new GameObject();
        raftParent.name = "raftParent";

        raftParent.gameObject.transform.position += new Vector3(randomPos, -.8f, this.gameObject.transform.position.z + zAdjust);
        raftParent.transform.SetParent(this.gameObject.transform);
        raftParent.AddComponent<Raft>();
        Raft = this.gameObject.transform.parent.GetComponent<FloorData>().raftObject;

        instantiatedRaft = Instantiate(Raft, new Vector3(0, -.5f, this.gameObject.transform.localPosition.z), Quaternion.identity);
        instantiatedRaft.transform.SetParent(raftParent.transform);
        instantiatedRaft.transform.localPosition = new Vector3(0 + xAdjust, 0.3f, 0);


        instantiatedRaft = Instantiate(Raft, new Vector3(1, -.5f, this.gameObject.transform.localPosition.z), Quaternion.identity);
        instantiatedRaft.transform.SetParent(raftParent.transform);
        instantiatedRaft.transform.localPosition = new Vector3(1 + xAdjust, 0.3f, 0);


        raftObjects.Add(raftParent);



    }



    void MakeNewRaft(Vector3 pos)
    {

        if (leftToRight == false)
        {
            randomPos = Random.Range(randomPos + 6, randomPos + 8);

        }
        else
        {

            randomPos = Random.Range(randomPos - 6, randomPos - 8);
        }
     

        raftParent = new GameObject();
        raftParent.name = "raftParent";
        raftParent.transform.SetParent(this.gameObject.transform);

        raftParent.gameObject.transform.position += new Vector3(randomPos, -.8f, this.gameObject.transform.position.z + zAdjust);
        raftParent.AddComponent<Raft>();
        instantiatedRaft = Instantiate(Raft, new Vector3(0, -.5f, this.gameObject.transform.localPosition.z), Quaternion.identity);
        instantiatedRaft.transform.SetParent(raftParent.transform);
        instantiatedRaft.transform.localPosition = new Vector3(0 + xAdjust, 0.3f, 0);


        instantiatedRaft = Instantiate(Raft, new Vector3(1, -.5f, this.gameObject.transform.localPosition.z), Quaternion.identity);
        instantiatedRaft.transform.SetParent(raftParent.transform);
        instantiatedRaft.transform.localPosition = new Vector3(1 + xAdjust, 0.3f, 0);

        raftObjects.Add(raftParent);
        alreadyMadeRaft1 = false;
        alreadyMadeRaft2 = false;
        alreadyMadeRaft3 = false;
    }
}
