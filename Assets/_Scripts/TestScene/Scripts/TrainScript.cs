using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject trafficLightObject;
    GameObject redLight;
    GameObject greenLight;

    void Start()
    {

        trafficLightObject = Instantiate( this.gameObject.GetComponentInParent<FloorData>().trafficLightObject, Vector3.zero, Quaternion.identity);
        trafficLightObject.transform.SetParent(this.gameObject.transform);
        trafficLightObject.transform.localPosition = new Vector3(0.001f,0.3f, -.2f);
        trafficLightObject.transform.localScale = new Vector3(0.5f,0.625f,0.4f);

        redLight = trafficLightObject.transform.GetChild(0).transform.GetChild(0).gameObject;
        greenLight = trafficLightObject.transform.GetChild(1).transform.GetChild(0).gameObject;

        redLight.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
