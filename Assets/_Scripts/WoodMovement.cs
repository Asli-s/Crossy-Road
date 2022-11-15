using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodMovement : MonoBehaviour
{
    Bounds playerScript;
    River riverScript;
     int woodSpeed = 3;

    private void Start()
    {
        playerScript = FindObjectOfType<Bounds>();
        riverScript = transform.parent.gameObject.GetComponent<River>();
       if(playerScript != null)
        {
            playerScript.woodSpeed = woodSpeed;
         
        }
    }

    public int GetWoodSpped()
    {
        return woodSpeed;
    }

    void Update()
    {
        if (playerScript.died == false)
        {
            if (riverScript.left == false)
            {
                this.gameObject.transform.position += new Vector3(-2, 0, 0) * Time.deltaTime * woodSpeed;
                if (this.gameObject.transform.position.x < -15)
                {
                    Destroy(this.gameObject);
                }
            }
            else
            {

                this.gameObject.transform.position += new Vector3(2, 0, 0) * Time.deltaTime * woodSpeed;
                if (this.gameObject.transform.position.x > 25)
                {
                    Destroy(this.gameObject);
                }

            }
        }
    }
}
