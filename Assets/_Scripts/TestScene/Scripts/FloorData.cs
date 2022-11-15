using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorData : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject riverCell;
    public GameObject streetCell;
    public GameObject grassCell;
    public GameObject floorParent;

  public  GameObject plantBarrierParent;
    public GameObject raftObject;
    public GameObject[] carObjects;
    public GameObject[] plantObjects;


    GameObject currentFloor;
  
   

    int floorWidth = 30;
    public int rowNum = 0;

    int levelCount = 20;
    int minZ = -8;
    int randomNum;
    string[] FloorTiles = { "River", "Street", "Grass" };
    string floorName = "";

    float adjustZPosition = 0.5f;

    public Dictionary<int, GameObject> floorRows = new Dictionary<int, GameObject>();
    Dictionary<string, GameObject> floorType = new Dictionary<string, GameObject>();


    float row;


    void Start()
    {


        floorType.Add("River", riverCell);
        floorType.Add("Street", streetCell);
        floorType.Add("Grass", grassCell);


        rowNum = minZ;

        for (int j =minZ; j < levelCount; j++)
        {
            randomNum = Random.Range(0, floorType.Count);
       
            floorName = FloorTiles[randomNum];

            if (j == 0 || j==1)
            {
                floorName = "Grass";
            }


            /*
                        if (j == 0)
                        {
                            floorName = "Grass";
                        }
                        if (floorName == "River")
                        {
                            rowNum++;
                            row = rowNum;
                        }
                        else if (floorName == "Grass")
                        {
                            rowNum++;
                            row = rowNum;

                        }
                        else if (floorName == "Street")
                        {
                            rowNum++;


                            row = rowNum+0.5f;
                        }
            */


            //  currentFloor = Instantiate(floorType[floorName], new Vector3(0 - floorWidth / 2, -1, row + adjustZPosition), Quaternion.identity);


            currentFloor = Instantiate(floorType[floorName], new Vector3(5 - floorWidth / 2, -1, rowNum + adjustZPosition), Quaternion.identity);
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
            else if(currentFloor.name == "Street")
            {
          //  floorRows.Add(rowNum, currentFloor);
                print(rowNum);
                currentFloor.AddComponent<StreetScript>();
         /*       rowNum ++;
                print(rowNum);
*/
                floorRows.Add(rowNum, currentFloor);

            }


            rowNum++;
        }



       
    }



    public void nextFloor()
    {

    }




}
