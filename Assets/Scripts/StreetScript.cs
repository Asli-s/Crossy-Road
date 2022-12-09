using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetScript : MonoBehaviour
{
    GameObject Car;
    GameObject instantiatedCar;

    Vector3 moveVector = new Vector3(-1, 0, 0);
    int randomPosition;
    int randomCar;
    float zAdjust = 0.5f;
    bool madeCar = false;
    public bool leftToRight = false;

    int randomDirection;
    FloorData floorDataScrript;

    public int moveSpeed;

    void Start()
    {


        moveSpeed = Random.Range(1, 5);

        randomDirection = Random.Range(0, 2);
        if (randomDirection == 0)
        {
            leftToRight = false;

        }
        else
        {

            leftToRight = true;
        }

        if (leftToRight == false)
        {
            randomPosition = Random.Range(10, 14);
        }
        else
        {
            randomPosition = Random.Range(-6, -10);
        }
        randomCar = Random.Range(0, 3);
        floorDataScrript = this.gameObject.transform.parent.GetComponent<FloorData>();

        MakeCar(randomPosition);

        MakeCoin();
    }

    void MakeCoin()
    {

        int randomCoinNum = Random.Range(0, 15);
        if (randomCoinNum == 2)
        {
            GameObject Coin = floorDataScrript.CoinObject;
         
               int randomPlace = Random.Range(-6, 6);

                    Instantiate(Coin, new Vector3(randomPlace, this.gameObject.transform.position.y + 0f, this.gameObject.transform.position.z - 0.24f), Quaternion.Euler(0, 0, 0));
                }
            
        
    }



    public void MakeCar(int randomPosition)
    {

        Car = floorDataScrript.carObjects[randomCar];
        instantiatedCar = Instantiate(Car, new Vector3(randomPosition, this.gameObject.transform.position.y + 1.5f, this.gameObject.transform.position.z - zAdjust), Quaternion.identity);
        instantiatedCar.transform.SetParent(this.gameObject.transform);
        instantiatedCar.AddComponent<Car>();
        madeCar = false;
    }
}

