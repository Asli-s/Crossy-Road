using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGeneration : MonoBehaviour
{
    public GameObject[] FloorTiles;
    int randomInt;
    int distancePlayer = 30; 
    GameObject newFloor;
    int step = 0;
    public GameObject Player;
    Bounds playerScript;



    private void Start()
    {
        playerScript = Player.GetComponent<Bounds>();
        step = 0;
        distancePlayer = 30;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) )//&& Player.transform.position.z%2==0) // percentage is 1 after jump completed
        {
            step++;
        

            randomInt = Random.Range(0, 3);
          

            newFloor = Instantiate(FloorTiles[randomInt], new Vector3(0, -1, distancePlayer), Quaternion.identity);
            newFloor.gameObject.transform.SetParent(gameObject.transform);
            distancePlayer += 2;

            

   


            if (Player.transform.position.z-Mathf.Abs(gameObject.transform.GetChild(0).transform.position.z )>
                40){      
                Destroy(gameObject.transform.GetChild(0).gameObject);
            }
  
        }
    }
}
