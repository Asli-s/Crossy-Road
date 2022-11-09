using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGeneration : MonoBehaviour
{
    public GameObject[] FloorTiles;
    int randomInt;
    float distancePlayer = 31.5f;
    GameObject newFloor;

    public GameObject Player;
    Bounds playerScript;
    float floorPosZ;

    string car;
    public GameObject CarPrefab;
    public GameObject EnemyParent;
    GameObject instantiatedEnemy;




    private void Start()
    {
        playerScript = Player.GetComponent<Bounds>();
        distancePlayer = 31.5f;

    }

    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            randomInt = Random.Range(0, FloorTiles.Length);
            if(FloorTiles[randomInt].name =="GrassPlane" || FloorTiles[randomInt].name=="GrassPlane2" )
            {

                floorPosZ = -1;
            }


            else if (FloorTiles[randomInt].name== "StreetPlane")
            {             
                //Street Plane

                floorPosZ = -1.2f;
                SpawnObject(car);
            }
           else if (FloorTiles[randomInt].name== "WaterPlane")
            {
                //Water Plane

                floorPosZ = -1.5f;
            }


            newFloor = Instantiate(FloorTiles[randomInt], new Vector3(0,floorPosZ, distancePlayer), Quaternion.identity);
            distancePlayer +=4;

            newFloor.gameObject.transform.SetParent(gameObject.transform);
            if (Player.transform.position.z - Mathf.Abs(gameObject.transform.GetChild(0).transform.position.z) >
                40)
            {
                Destroy(gameObject.transform.GetChild(0).gameObject);
            }

        }*/
    }

    void SpawnObject(string objectName)
    {

        if(objectName == car)
        {
           instantiatedEnemy= Instantiate(CarPrefab, new Vector3(0, 1, distancePlayer), Quaternion.identity);
           instantiatedEnemy.gameObject.transform.SetParent(EnemyParent.transform);

        }

    }
}
