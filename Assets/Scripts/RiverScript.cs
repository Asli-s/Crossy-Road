using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverScript : MonoBehaviour
{
    GameObject Raft;
    GameObject instantiatedRaft;
    GameObject Pattel;
    GameObject instantiatedPattel;

    GameObject RiverBorder;
 
    GameObject instantiatedBorder;


    public List<GameObject> raftObjects = new List<GameObject>();
    FloorData floorScript;
    GameObject raftParent;
    int randomPos;
    public bool leftToRight = false;

    int randomDirection;
  
    float zAdjust = -0.165f;
    float xAdjust = 0.2f;

    int raftSize = 3;



    public bool pattel = false;
    int randomRiverType;


    public int moveSpeed = 1;

    void Start()

    {
        floorScript = this.gameObject.GetComponentInParent<FloorData>();

     


        randomRiverType = Random.Range(0, 3);

        if (randomRiverType == 0)
        {
            pattel = true;
            MakePattel();
        }
        else if (randomRiverType == 1 || randomRiverType == 2)
        {
            MakeRiverBorder();


            moveSpeed = Random.Range(1, 5);

            raftSize = Random.Range(3, 5);
            pattel = false;

      

            MakeFirstRaft();
        }
    }


    public void choseDirection(int riverNum)
    {
      
        if (riverNum % 2 == 0)
        {
            leftToRight = false;

        }
        else
        {
            leftToRight = true;

        }

    }


    void MakeRiverBorder()
    {
        RiverBorder = floorScript.RightRiverBorder;
        instantiatedBorder = Instantiate(RiverBorder, new Vector3(5, -.65f, transform.position.z), Quaternion.identity);
        instantiatedBorder.transform.SetParent(transform);
        instantiatedBorder.transform.localScale = new Vector3(instantiatedBorder.transform.localScale.x, instantiatedBorder.transform.localScale.y, 0.01f);


        RiverBorder = floorScript.LeftRiverBorder;
        instantiatedBorder = Instantiate(RiverBorder, new Vector3(-8, -.65f, transform.position.z), Quaternion.identity);
        instantiatedBorder.transform.SetParent(transform);
        instantiatedBorder.transform.localScale = new Vector3(instantiatedBorder.transform.localScale.x, instantiatedBorder.transform.localScale.y, 0.01f);

    }

    void MakePattel()
    {
        int RandomPattelAmount = Random.Range(3, 7);
        int RandomPattelPlace;

        List<int> PattelsXPos = new List<int>();

        for (int i = 0; i < RandomPattelAmount; i++)
        {
            RandomPattelPlace = Random.Range(-5, 8);
            Pattel = floorScript.pattelObject;


            instantiatedPattel = Instantiate(Pattel, new Vector3(RandomPattelPlace - .3f, transform.position.y + 0.6f, transform.position.z +0.2f), Quaternion.identity);
            instantiatedPattel.transform.SetParent(this.gameObject.transform);
            PattelsXPos.Add(RandomPattelPlace);
            if (!PattelsXPos.Contains(0))
            {
                instantiatedPattel = Instantiate(Pattel, new Vector3(0 - .3f, transform.position.y + 0.6f, transform.position.z +0.2f), Quaternion.identity);
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
        Raft = floorScript.raftObject;

        for (int i = 0; i < raftSize; i++)
        {

        instantiatedRaft = Instantiate(Raft, new Vector3(i, -.5f, this.gameObject.transform.localPosition.z), Quaternion.identity);
        instantiatedRaft.transform.SetParent(raftParent.transform);
        instantiatedRaft.transform.localPosition = new Vector3(i + xAdjust, 0.3f, 0);
        }



      /*  instantiatedRaft = Instantiate(Raft, new Vector3(1, -.5f, this.gameObject.transform.localPosition.z), Quaternion.identity);
        instantiatedRaft.transform.SetParent(raftParent.transform);
        instantiatedRaft.transform.localPosition = new Vector3(1 + xAdjust, 0.3f, 0);*/


        raftObjects.Add(raftParent);



    }



    public void MakeNewRaft(int randomPos)
    {




        raftParent = new GameObject();
        raftParent.name = "raftParent";
        raftParent.transform.SetParent(this.gameObject.transform);

        raftParent.gameObject.transform.position += new Vector3(randomPos, -.8f, this.gameObject.transform.position.z + zAdjust);
        raftParent.AddComponent<Raft>();


        for (int i = 0; i < raftSize; i++)
        {

            instantiatedRaft = Instantiate(Raft, new Vector3(i, -.5f, this.gameObject.transform.localPosition.z), Quaternion.identity);
            instantiatedRaft.transform.SetParent(raftParent.transform);
            instantiatedRaft.transform.localPosition = new Vector3(i + xAdjust, 0.3f, 0);
        }
       
        raftObjects.Add(raftParent);
      
    }


 

}
