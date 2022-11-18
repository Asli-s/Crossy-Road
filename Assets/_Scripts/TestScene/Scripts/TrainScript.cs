using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject trafficLightObject;
    GameObject redLight;
    GameObject greenLight;
    int timespanSeconds = 10;
    FloorData floorScript;
    GameObject Train;
    GameObject instantiatedTrain;

    IEnumerator trainSpawn;
    IEnumerator trafficLight;
    bool trainIsNext = false;
    bool trainReady =false;
    bool timerStarted = false;
    bool destroyed = false;

    void Start()
    {
        floorScript = this.gameObject.GetComponentInParent<FloorData>();
        trafficLightObject = Instantiate( floorScript.trafficLightObject, Vector3.zero, Quaternion.identity);
        trafficLightObject.transform.SetParent(this.gameObject.transform);
        trafficLightObject.transform.localPosition = new Vector3(0.001f,0.3f, -.2f);
        trafficLightObject.transform.localScale = new Vector3(0.5f,0.625f,0.4f);

        redLight = trafficLightObject.transform.GetChild(0).transform.GetChild(0).gameObject;
        greenLight = trafficLightObject.transform.GetChild(1).transform.GetChild(0).gameObject;

        redLight.SetActive(false);

        StartTimer();

    }

 
    void Update()
    {
        if(trainReady == true && instantiatedTrain != null)
        {
            instantiatedTrain.transform.position +=  new Vector3(-1, 0, 0) * 30 * Time.deltaTime;
            if(instantiatedTrain.transform.localPosition.x <= -1 && destroyed == false)
            {
                destroyed = true;
                redLight.SetActive(false);
                greenLight.SetActive(true);
                trainReady = false;
                timerStarted = false;
                Destroy(instantiatedTrain);
            }
        }
        if (timerStarted == false  && destroyed == true)
        {
            print("startcoroutine update");
            timerStarted = true;
            StartTimer();


        }

    }

    void StartTimer()
    {
        trainSpawn = TrainSpawn();
        trafficLight = TrafficLight();
        int randomDelay = Random.Range(8, 15);
        timespanSeconds = randomDelay;
        StartCoroutine(trainSpawn);
    }


    IEnumerator TrainSpawn()
    {

        destroyed = false;
        timerStarted = true;
        while (timespanSeconds > 0)
        {
            print(timespanSeconds);
            timespanSeconds--;
            yield return new WaitForSeconds(1);
        }
        if (timespanSeconds == 0)
        {
          
            StartCoroutine(trafficLight);
        }

    }
    IEnumerator TrafficLight()
    {

        greenLight.SetActive(false);
        redLight.SetActive(true);
        yield return new WaitForSeconds(2);
        trainIsNext = true;
        print(" train next"+trainIsNext);
        MakeTrain();

    }

    void MakeTrain()
    {
       Train=  floorScript.trainObject;
        instantiatedTrain = Instantiate(Train, new Vector3(20,0, this.transform.position.z), Quaternion.identity);
        instantiatedTrain.transform.SetParent(transform);
        trainReady = true;

    }
}
