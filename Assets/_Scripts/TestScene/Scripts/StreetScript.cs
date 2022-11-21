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

 public   int moveSpeed;

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

           randomPosition = Random.Range( - 6,  -10);
       }
        randomCar = Random.Range(0, 3);
        floorDataScrript = this.gameObject.transform.parent.GetComponent<FloorData>();
       
        MakeCar(randomPosition);


     
    }

   

    public void MakeCar(int randomPosition)
    {
      
        Car = floorDataScrript.carObjects[randomCar];
        instantiatedCar = Instantiate(Car, new Vector3(randomPosition, this.gameObject.transform.position.y + 1.5f, this.gameObject.transform.position.z - zAdjust), Quaternion.identity);
        print(instantiatedCar.transform.localPosition);
        instantiatedCar.transform.SetParent(this.gameObject.transform);
        instantiatedCar.AddComponent<Car>();
        madeCar = false;
    }
}

