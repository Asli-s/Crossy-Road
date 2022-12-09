using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PattelCollision : MonoBehaviour
{
   public void StopPattel()
    {
        gameObject.GetComponent<Animator>().SetBool("onPattel", false);
    }
}
