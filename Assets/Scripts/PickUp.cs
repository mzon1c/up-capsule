using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    

    private bool control = false;
    private bool inspace = false;
    private bool holdingObject = false;
    private GameObject pickup;

    void Update()
    {
        control = Input.GetButtonDown("Fire1");
        if(control && inspace == true && holdingObject == false)
        {
            pickup.transform.parent = this.transform;
            pickup.GetComponent<Rigidbody>().useGravity = false;
            pickup.GetComponent<Rigidbody>().isKinematic = true;
            holdingObject = true;

        }else if(control && holdingObject == true)
        {
            pickup.transform.parent = null;
            holdingObject = false;
            pickup.GetComponent<Rigidbody>().useGravity = true;
            pickup.GetComponent<Rigidbody>().isKinematic = false;
        }
        
        //Debug.Log("Contorl");
    }
    
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Pick Up")
        {
            inspace = true;
            //pickup = other.transform.parent.gameObject;
            pickup = other.transform.gameObject;
            //pickup = other.transform.GetChild(0).gameObject;
            Debug.Log("Collision has happened with "+pickup.name);
          
            
           // pickup.transform.parent = this.transform;
          
        }
    }

    void OnTriggerExit(Collider other) {
        inspace = false;

        

    }
}
