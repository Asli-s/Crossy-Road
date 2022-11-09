using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Bounds playerScript;

    private void Start()
    {
        playerScript = FindObjectOfType<Bounds>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Water")
        {

        print(other.tag);
        }
        if(other.tag == "Enemy")
        {
            print(other.tag);
            playerScript.died = true;
            Destroy(other.gameObject);

        }
    }
}
