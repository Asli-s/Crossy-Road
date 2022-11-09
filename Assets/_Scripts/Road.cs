using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject CarPrefab;
    private GameObject instantiatedCar;

    int randomPos;

    void Start()
    {
        randomPos = Random.Range(15, 26);
        instantiatedCar = Instantiate(CarPrefab, new Vector3(gameObject.transform.position.x + randomPos, gameObject.transform.position.y + 1.5f, gameObject.transform.position.z), Quaternion.identity);

        instantiatedCar.transform.parent = this.gameObject.transform;
    }


    void Update()
    {
        if (this.gameObject.transform.childCount < 2 && this.gameObject.transform.GetChild(0).transform.position.x < 5)
        {
            randomPos = Random.Range(15, 26);

            instantiatedCar = Instantiate(CarPrefab, new Vector3(gameObject.transform.position.x + randomPos, gameObject.transform.position.y + 1.5f, gameObject.transform.position.z), Quaternion.identity);

            instantiatedCar.transform.parent = this.gameObject.transform;


        }

    }
}
