using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private int carSpeed = 2;
    void Update()
    {
        this.gameObject.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * carSpeed;
        if (this.gameObject.transform.position.x < -10)
        {
            Destroy(this.gameObject);
        }
    }
}
