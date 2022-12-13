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
    int leftMax = -8;

    int rightMax = 25;
    int rightMin = 8;

    int luckyNum = 0;
    List<int> randomPlaces = new List<int>();
    bool alreadyInstantiatedCoin = false;

    FloorData floorScript;


    void Start()
    {



        floorScript = this.gameObject.GetComponentInParent<FloorData>();

        MakeMiddlePlants();
        MakeCoin();
        MakeBorderPlants();

    }

    void MakeMiddlePlants()
    {
        plantAmount = Random.Range(1, 4);
        for (int i = 0; i < plantAmount; i++)
        {
            randomPlant = Random.Range(0, 3);
            randomPlace = Random.Range(-6, 7);

            if (randomPlace != 0 && !randomPlaces.Contains(randomPlace))
            {
                plant = Instantiate(floorScript.plantObjects[randomPlant], new Vector3(randomPlace, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z - 0.4f), Quaternion.identity);
                plant.name = floorScript.plantObjects[randomPlant].name;
                plant.transform.SetParent(floorScript.plantBarrierParent.transform);
            randomPlaces.Add(randomPlace);

            }


        }
    }


    void MakeCoin()
    {

        int randomCoinNum = Random.Range(0, 6);
        if (randomCoinNum == luckyNum)
        {
            GameObject Coin = floorScript.CoinObject;
            for (int i = 0; i < randomPlaces.Count; i++)
            {
                randomPlace = Random.Range(-6, 6);

                if (!randomPlaces.Contains(randomPlace) && alreadyInstantiatedCoin == false&& randomPlace != 0)
                {
                  
                    alreadyInstantiatedCoin = true;
                    Instantiate(Coin, new Vector3(randomPlace-0.1f, this.gameObject.transform.position.y + 0f, this.gameObject.transform.position.z-0.1f ), Quaternion.Euler(0, 0, 0));
                }
            }
        }
    }
    void MakeBorderPlants()
    {

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
