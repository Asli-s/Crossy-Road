using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPress : MonoBehaviour
{
   
    void Update()
    {
        if (Input.touchCount > 0 || (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
            {
            gameObject.SetActive(false);
        }
    }
}
