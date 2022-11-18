using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorData : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject riverCell;
    public GameObject streetCell;
    public GameObject grassCell;
    public GameObject trainCell;
    public GameObject floorParent;

    public GameObject plantBarrierParent;
    public GameObject raftObject;
    public GameObject[] carObjects;
    public GameObject[] plantObjects;
    public GameObject trafficLightObject;
    public GameObject trainObject;
    public GameObject pattelObject;
    public GameObject LeftRiverBorder;
    public GameObject RightRiverBorder;
    public GameObject WaterAnimParent;

    GameObject currentFloor;



    int floorWidth = 30;
    public int rowNum = 0;

    int levelCount = 20;
    int minZ = -8;
    int randomNum;
    
    string floorName = "";
    public bool firstFloor = false;

    float adjustZPosition = 0.5f;

    public Dictionary<int, GameObject> floorRows = new Dictionary<int, GameObject>();
    Dictionary<string, GameObject> floorType = new Dictionary<string, GameObject>();


    float row;


    void Start()
    {

        //   Propability grass 35%
        //   Propability river 30%
        //   Propability street 30%
        //   Propability train 5%





        floorType.Add("River", riverCell);
        floorType.Add("Street", streetCell);
        floorType.Add("Grass", grassCell);
        floorType.Add("Train", trainCell);


        rowNum = minZ;

        FirstFloor();
       



        for (int j = minZ; j < levelCount; j++)
        {

            int randomProbability = Random.Range(0, 100);
            if (randomProbability <= 4)
            {
                floorName = "Train";
            }
            else if (randomProbability > 4 && randomProbability <= 34)
            {
                floorName = "Street";
            }
            else if (randomProbability > 34 && randomProbability <= 64)
            {
                floorName = "River";
            }
            else if (randomProbability > 64 && randomProbability <= 99)
            {
                floorName = "Grass";
            }




            if (j == 0 || j == 1)
            {
                floorName = "Grass";
            }




            currentFloor = Instantiate(floorType[floorName], new Vector3(15 - floorWidth / 2, -1, rowNum + adjustZPosition), Quaternion.identity);
            currentFloor.name = floorName;
            currentFloor.transform.SetParent(this.gameObject.transform);


            if (currentFloor.name == "River")
            {
                currentFloor.AddComponent<RiverScript>();
                floorRows.Add(rowNum, currentFloor);

            }
            else if (currentFloor.name == "Grass")
            {
                currentFloor.AddComponent<GrassScript>();
                floorRows.Add(rowNum, currentFloor);

            }
            else if (currentFloor.name == "Street")
            {
                //  floorRows.Add(rowNum, currentFloor);
                print(rowNum);
                currentFloor.AddComponent<StreetScript>();
                /*       rowNum ++;
                       print(rowNum);
       */
                floorRows.Add(rowNum, currentFloor);

            }

            else if (currentFloor.name == "Train")
            {
                currentFloor.AddComponent<TrainScript>();
                floorRows.Add(rowNum, currentFloor);

            }


            rowNum++;
        }




    }





    public void nextFloor()
    {

    }

    void FirstFloor()
    {
        currentFloor = Instantiate(floorType["Grass"], new Vector3(15 - floorWidth / 2, -1, minZ - 1 + adjustZPosition), Quaternion.identity);
        currentFloor.name = floorName;
        currentFloor.transform.SetParent(this.gameObject.transform);
       

        //instantiate Plants
        int plantAmount = 50;
        for (int i = -plantAmount / 2; i < plantAmount; i++)
        {
            GameObject plant = Instantiate(plantObjects[0], new Vector3(i,-.5f, minZ - 1 + adjustZPosition), Quaternion.identity);
            plant.name = plantObjects[0].name;
            plant.transform.SetParent(plantBarrierParent.transform);

        }




    }
}
