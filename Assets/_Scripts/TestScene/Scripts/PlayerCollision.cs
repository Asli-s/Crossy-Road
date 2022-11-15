using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    PlayerScript playerScript;
    
    private void Start()
    {
        playerScript = this.gameObject.transform.parent.GetComponent<PlayerScript>();
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            print("enemy");
            playerScript.died = true;
            playerScript.justJump = false;
        }
    }


}
