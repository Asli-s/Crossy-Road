using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassScript : MonoBehaviour
{
    GameObject plant;
    int plantAmount;
    int randomPlant;
    int randomPlace;
    int leftMin = -15;
    int leftMax = -6;

    int rightMax = 25;
    int rightMin = 8;
    void Start()
    {
       /* GameObject plantParent = new GameObject();
        plantParent.name = "plantParent";
        plantParent.transform.SetParent(this.gameObject.transform);
*/
        plantAmount = Random.Range(1,5);
        for (int i = 0; i < plantAmount; i++)
        {
            randomPlant = Random.Range(0, 2);
            randomPlace = Random.Range(-5, 7);

          if((int)this.gameObject.transform.position.z ==1 || (int)this.gameObject.transform.position.z == 0 )
            {
               if (randomPlace != 0)
                {
            plant = Instantiate(this.gameObject.transform.parent.GetComponent<FloorData>().plantObjects[randomPlant], new Vector3(randomPlace, this.gameObject.transform.position.y+1, this.gameObject.transform.position.z-0.4f), Quaternion.identity );
                    plant.transform.SetParent(this.gameObject.transform.parent.GetComponent<FloorData>().plantBarrierParent.transform);

                }
            }
            else
            {
                plant = Instantiate(this.gameObject.transform.parent.GetComponent<FloorData>().plantObjects[randomPlant], new Vector3(randomPlace, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z-0.4f), Quaternion.identity);
                plant.transform.SetParent(this.gameObject.transform.parent.GetComponent<FloorData>().plantBarrierParent.transform);

            }
        }
        for (int i = leftMin; i < leftMax; i++)
        {
            randomPlant = Random.Range(0, 2);
            plant = Instantiate(this.gameObject.transform.parent.GetComponent<FloorData>().plantObjects[randomPlant], new Vector3(i, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z - 0.4f), Quaternion.identity);
            plant.transform.SetParent(this.gameObject.transform.parent.GetComponent<FloorData>().plantBarrierParent.transform);


        }
        for (int i = rightMin; i < rightMax; i++)
        {
            randomPlant = Random.Range(0, 2);
            plant = Instantiate(this.gameObject.transform.parent.GetComponent<FloorData>().plantObjects[randomPlant], new Vector3(i, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z - 0.4f), Quaternion.identity);
            plant.transform.SetParent(this.gameObject.transform.parent.GetComponent<FloorData>().plantBarrierParent.transform);


        }

    }

}
