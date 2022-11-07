using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject Player;
    Vector3 newPos;

    void Update()
    {
        newPos = Vector3.Lerp(gameObject.transform.position,Player.transform.position,Time.deltaTime);
        gameObject.transform.position = new Vector3(newPos.x,5,newPos.z);
    }
}
