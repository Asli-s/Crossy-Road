using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    Bounds playerScript;
    Road roadScript;
    private int carSpeed = 4;

    private void Start()
    {
        playerScript = FindObjectOfType<Bounds>();
        roadScript= transform.parent.gameObject.GetComponent<Road>();
        if (roadScript.left == true)
        {
            gameObject.transform.Rotate(0, 180,0);
        }
    }

    void Update()
    {
        if (playerScript.died == false)
        {
            if (roadScript.left == false)
            {
                this.gameObject.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * carSpeed;
                if (this.gameObject.transform.position.x < -15)
                {
                    Destroy(this.gameObject);
                }
            }
            else
            {

                this.gameObject.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * carSpeed;
                if (this.gameObject.transform.position.x >25)
                {
                    Destroy(this.gameObject);
                }

            }
        }
    }
}
