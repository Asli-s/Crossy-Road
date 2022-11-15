using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodAnim : MonoBehaviour
{
    Animator anim;
 
    private void Start()
    {
        anim = GetComponent<Animator>();

    }
    private void OnTriggerEnter(Collider other)
    {
      
        if(other.tag == "Player" )
        {
            print("woodTrigger");
            if(anim.GetBool("onWood") == false)
            {
            anim.SetBool("onWood", true);
            }

           
        }

    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            print("leave wood");
            anim.SetBool("onWood", false);
       
        }
    }
  
}
