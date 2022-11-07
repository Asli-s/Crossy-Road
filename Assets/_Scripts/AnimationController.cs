using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator anim;
    public GameObject Player;
    Bounds playerScript;


    void Start()
    {
        
        anim = gameObject.GetComponent<Animator>();
        playerScript =Player.GetComponent<Bounds>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.justJump == true)
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);

        }
        if (Input.GetKeyDown(KeyCode.RightArrow) )
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) )
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
