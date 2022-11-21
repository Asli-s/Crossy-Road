using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject Player;
    PlayerScript playerScript;
    Vector3 newPos;

    private void Start()
    {
        playerScript = Player.GetComponent<PlayerScript>();
    }


    void Update()
    {
     

        if (playerScript.died == false && Player.transform.position.x < 4 &&  Player.transform.position.x> -6 )
        {
            newPos = Vector3.Lerp(gameObject.transform.position, Player.transform.position, Time.deltaTime * 1.5f);
            gameObject.transform.position = new Vector3(newPos.x, 5, newPos.z);
        
        }
    }
}
