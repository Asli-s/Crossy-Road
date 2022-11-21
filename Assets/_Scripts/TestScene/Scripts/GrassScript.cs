using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassScript : MonoBehaviour
{
    GameObject plant;
    int plantAmount;
    int randomPlant;
    int randomPlace;
    int leftMin = -17;
    int leftMax = -7;

    int rightMax = 25;
    int rightMin = 5;

    FloorData floorScript;
    void Start()
    {
        floorScript = this.gameObject.GetComponentInParent<FloorData>();

        plantAmount = Random.Range(1, 4);
        for (int i = 0; i < plantAmount; i++)
        {
            randomPlant = Random.Range(0, 3);
            randomPlace = Random.Range(-6, 7);


            if (randomPlace != 0)
            {
                plant = Instantiate(floorScript.plantObjects[randomPlant], new Vector3(randomPlace, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z - 0.4f), Quaternion.identity);
                plant.name = floorScript.plantObjects[randomPlant].name;
                plant.transform.SetParent(floorScript.plantBarrierParent.transform);

            }

        }
        for (int i = leftMin; i < leftMax; i++)
        {
            randomPlant = Random.Range(0, 2);
            plant = Instantiate(floorScript.plantObjects[randomPlant], new Vector3(i, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z - 0.4f), Quaternion.identity);
            plant.name = floorScript.plantObjects[randomPlant].name;
            plant.transform.SetParent(floorScript.plantBarrierParent.transform);


        }
        for (int i = rightMin; i < rightMax; i++)
        {
            randomPlant = Random.Range(0, 2);
            plant = Instantiate(this.gameObject.transform.parent.GetComponent<FloorData>().plantObjects[randomPlant], new Vector3(i, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z - 0.4f), Quaternion.identity);
            plant.name = floorScript.plantObjects[randomPlant].name;
            plant.transform.SetParent(floorScript.plantBarrierParent.transform);


        }

    }

}
