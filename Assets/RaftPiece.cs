using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftPiece : MonoBehaviour
{
    public void StopRaft()
    {
        gameObject.GetComponent<Animator>().SetBool("onRaft", false);
    }
}
