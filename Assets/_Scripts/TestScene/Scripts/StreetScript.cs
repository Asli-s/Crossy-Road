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
    float zAdjust = 0.4f;
   
    void Start()

    {
        randomPosition = Random.Range(-5, 25);
      
        randomCar = Random.Range(0, 2);
        Car = this.gameObject.transform.parent.GetComponent<FloorData>().carObjects[randomCar];

        instantiatedCar = Instantiate(Car, new Vector3(randomPosition, this.gameObject.transform.position.y +1.5f, this.gameObject.transform.position.z-zAdjust), Quaternion.identity);
        instantiatedCar.transform.SetParent(this.gameObject.transform);
      
     
    }

    // Update is called once per frame
    void Update()
    {
        instantiatedCar.transform.position += moveVector * Time.deltaTime;
    }
}
