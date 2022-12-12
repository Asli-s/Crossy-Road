using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorData : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject riverCell;
    public GameObject streetCell;
    public GameObject grassCell;
    public GameObject grassCellDark;
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
    public GameObject CoinObject;

    GameObject currentFloor;



    int floorWidth = 30;
    public int rowNum = 0;
    public int riverNum=0;
    int grassNum = 0;

    int levelCount = 20;
    int minZ = -8;
    int randomNum;
    
    string floorName = "";
    public bool firstFloor = false;

    float adjustZPosition = 0.5f;

    public Dictionary<int, GameObject> floorRows = new Dictionary<int, GameObject>();
    Dictionary<string, GameObject> floorType = new Dictionary<string, GameObject>();

    float yPosition =0;


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
        floorType.Add("GrassDark", grassCellDark);
        floorType.Add("Train", trainCell);


        rowNum = minZ;

        FirstFloor();
       



        for (int j = minZ; j < levelCount; j++)
        {

         yPosition =   ChoseFloor();
         


            if (j == 0 || j == 1)
            {
                if (grassNum % 2 == 0)
                {

                floorName = "Grass";
                }
                else
                {
                    floorName = "GrassDark";

                }
             
                yPosition = -0.95f;
            }




            currentFloor = Instantiate(floorType[floorName], new Vector3(15 - floorWidth / 2-1.4f, yPosition, rowNum + adjustZPosition), Quaternion.identity);
            currentFloor.name = floorName;
            currentFloor.transform.SetParent(this.gameObject.transform);


            if (currentFloor.name == "River")
            {
                currentFloor.AddComponent<RiverScript>();
                floorRows.Add(rowNum, currentFloor);
                riverNum++;
                currentFloor.GetComponent<RiverScript>().choseDirection(riverNum);

            }
            else if (currentFloor.name == "Grass" || currentFloor.name == "GrassDark")
            {
                grassNum++;
                currentFloor.AddComponent<GrassScript>();
                floorRows.Add(rowNum, currentFloor);

            }
            else if (currentFloor.name == "Street")
            {
                //  floorRows.Add(rowNum, currentFloor);
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


   float ChoseFloor()
    {
        int randomProbability = Random.Range(0, 100);
        if (randomProbability <= 4)
        {
            floorName = "Train";
         return   yPosition = -1;
        }
        else if (randomProbability > 4 && randomProbability <= 34)
        {
            floorName = "Street";
            return yPosition = -1.01f;

        }
        else if (randomProbability > 34 && randomProbability <= 64)
        {
            floorName = "River";
            return yPosition = -1.05f;

        }
        else if (randomProbability > 64 && randomProbability <= 99)
        {
            if (grassNum % 2 == 0)
            {
                
                floorName = "Grass";
            }
            else
            {
                floorName = "GrassDark";

            }

          
            return yPosition = -.95f;
        }
        else
        {
            return yPosition;
        }

    }



    public void nextFloor(int floorCount)
    {


        yPosition = ChoseFloor();


        currentFloor = Instantiate(floorType[floorName], new Vector3(15 - floorWidth / 2- 1.4f, yPosition, rowNum + adjustZPosition), Quaternion.identity);
        currentFloor.name = floorName;
        currentFloor.transform.SetParent(this.gameObject.transform);


        if (currentFloor.name == "River")
        {
            currentFloor.AddComponent<RiverScript>();
            floorRows.Add(rowNum, currentFloor);
            riverNum++;
            currentFloor.GetComponent<RiverScript>().choseDirection(riverNum);


        }
        else if (currentFloor.name == "Grass" || currentFloor.name == "Grass")
        {
            grassNum++;
            currentFloor.AddComponent<GrassScript>();
            floorRows.Add(rowNum, currentFloor);

        }
        else if (currentFloor.name == "Street")
        {
            //  floorRows.Add(rowNum, currentFloor);
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
        if(floorCount > 10)
        {

        DeleteFloor();
        }

    }

    void DeleteFloor()
    {
        int deleteRowNUm =(int) this.gameObject.transform.GetChild(0).position.z;
        Destroy(this.gameObject.transform.GetChild(0).gameObject);
       int plantObjectNum= plantBarrierParent.transform.childCount;
        for (int i = 0; i < plantObjectNum; i++)
        {
            GameObject deleteObject = plantBarrierParent.transform.GetChild(i).gameObject;
            if((int)deleteObject.transform.position.z == deleteRowNUm)
            {

                Destroy(deleteObject);
            }
        }
    }



    void FirstFloor()
    {
        yPosition = -.95f;
        if (grassNum % 2 == 0)
        {

            floorName = "Grass";
        }
        else
        {
            floorName = "GrassDark";

        }
      

        currentFloor = Instantiate(floorType[floorName], new Vector3(15 - floorWidth / 2 - 1.4f, yPosition, minZ - 1 + adjustZPosition), Quaternion.identity);
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
