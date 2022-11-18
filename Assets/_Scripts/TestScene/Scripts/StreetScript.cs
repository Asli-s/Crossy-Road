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
    float zAdjust = 0.3f;
    bool madeCar = false;
    public bool leftToRight = false;

    int randomDirection;
    FloorData floorDataScrript;

 public   int moveSpeed;

    void Start()

    {



        moveSpeed = Random.Range(1, 4);


      
        randomDirection = Random.Range(0, 2);
        if (randomDirection == 0)
        {
            leftToRight = false;

         

        }
        else
        {
           


            leftToRight = true;
        }
        randomPosition = Random.Range(-5, 17);
        randomCar = Random.Range(0, 2);
        floorDataScrript = this.gameObject.transform.parent.GetComponent<FloorData>();
       
        MakeCar();




      
     
    }

    void Update()
    {
        if (this.gameObject.transform.childCount == 1)
        {

            if (madeCar == false)
            {

                madeCar = true;
                MakeCar();
            }

        }
        if (this.gameObject.transform.childCount == 2)
        {


            if (madeCar == false)
            {

                madeCar = true;
                MakeCar();
            }

        }
        if (this.gameObject.transform.childCount == 3)
        {


            if (madeCar == false)
            {

                madeCar = true;
                MakeCar();
            }

        }
    }

    void MakeCar()
    {
        if (leftToRight == false)
        {
            randomPosition = Random.Range(randomPosition + 6, randomPosition + 8);

        }
        else
        {

            randomPosition = Random.Range(randomPosition - 6, randomPosition - 8);
        }

        Car = floorDataScrript.carObjects[randomCar];
        instantiatedCar = Instantiate(Car, new Vector3(randomPosition, this.gameObject.transform.position.y + 1.5f, this.gameObject.transform.position.z - zAdjust), Quaternion.identity);
        instantiatedCar.transform.SetParent(this.gameObject.transform);
        instantiatedCar.AddComponent<Car>();
        madeCar = false;
    }
}

