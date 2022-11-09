using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject CarPrefab;
    private GameObject instantiatedCar;

    int randomPos;
    int randomDirection = 1;
   int minRangeXPos = 15;
    int maxRangeXPos = 30;
    public bool left;


    void Start()
    {
        randomDirection =
         Random.Range(0, 2);
        if (randomDirection == 0)
        {
            //right to left movement
            left = false;
            minRangeXPos = 15;
            maxRangeXPos = 30;

        }
        else if (randomDirection == 1)
        {
            //left to right movement

            left = true;
            minRangeXPos = -15;
            maxRangeXPos = -30;

        }
        randomPos = Random.Range(minRangeXPos, maxRangeXPos);
        instantiatedCar = Instantiate(CarPrefab, new Vector3(gameObject.transform.position.x + randomPos, gameObject.transform.position.y + 2f, gameObject.transform.position.z), Quaternion.identity);
        instantiatedCar.transform.parent = this.gameObject.transform;
    }


    void Update()
    {
        if (this.gameObject.transform.childCount!=0)
        {

            if (this.gameObject.transform.childCount < 2 && this.gameObject.transform.GetChild(0).transform.position.x < 5 && randomDirection == 0)
            {
                minRangeXPos = 15;
                maxRangeXPos = 30;
                randomPos = Random.Range(minRangeXPos, maxRangeXPos);
                instantiatedCar = Instantiate(CarPrefab, new Vector3(gameObject.transform.position.x + randomPos, gameObject.transform.position.y + 2f, gameObject.transform.position.z), Quaternion.identity);
                instantiatedCar.transform.parent = this.gameObject.transform;
            }
            else if (this.gameObject.transform.childCount < 2 && this.gameObject.transform.GetChild(0).transform.position.x > 15 && randomDirection == 1)
            {
                minRangeXPos = -15;
                maxRangeXPos = -30;
                randomPos = Random.Range(minRangeXPos, maxRangeXPos);
                instantiatedCar = Instantiate(CarPrefab, new Vector3(gameObject.transform.position.x + randomPos, gameObject.transform.position.y + 2f, gameObject.transform.position.z), Quaternion.identity);
                instantiatedCar.transform.parent = this.gameObject.transform;
            }
        }
    }
}
