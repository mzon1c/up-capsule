using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceLevel : MonoBehaviour
{
    
    void OnCollisionEnter(Collision other) {

    if(other.gameObject.tag == "Pick Up")
    {
        Debug.Log("coin inserted!");
    }

    }
}
