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
            this.gameObject.transform.parent.gameObject.transform.localScale = new Vector3(this.gameObject.transform.parent.gameObject.transform.localScale.x,0.01f, this.gameObject.transform.parent.gameObject.transform.localScale.z);
            playerScript.justJump = false;
        }
    }


}
