using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : MonoBehaviour
{
    // Start is called before the first frame update
    bool leftToRight;
    int moveSpeed;
    Vector3 moveVector;

    void Start()
    {
        RiverScript riverScript = GetComponentInParent<RiverScript>();
        leftToRight = riverScript.leftToRight;
        moveSpeed = riverScript.moveSpeed;
        moveVector   = new Vector3(moveSpeed, 0, 0);
        if (leftToRight == false)
        {
            transform.rotation *= Quaternion.Euler(0, 180, 0);
        }
    }

    void Update()
    {
        if(leftToRight == true)
        {
            this.gameObject.transform.position += moveVector * Time.deltaTime;
            if(this.gameObject.transform.position.x > 17)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (this.gameObject.transform.position.x <-17)
            {
                Destroy(this.gameObject);
            }
            this.gameObject.transform.position -= moveVector * Time.deltaTime;
        }
        
    }
}
