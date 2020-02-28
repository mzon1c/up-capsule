using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody rb_capsule;
    public float speed;
    public float jumpforce;
    public int maxjumps;
    private float h_move;
    private float v_move;
    private bool jump = false;
    private int jumpcount;
 
    void Start()
        {
            rb_capsule.GetComponent<Rigidbody>();
            jumpcount = maxjumps;
        }

    
    void Update()
        {
            h_move = Input.GetAxis("Horizontal");
            v_move = Input.GetAxis("Vertical");
            jump = Input.GetButton("Jump");
        }

    private void OnCollisionEnter(Collision other) 
        {
            if(other.gameObject.tag == "Ground")
                {
                    Debug.Log("hit ground");
                    jumpcount = maxjumps;
                }   
        }

    void FixedUpdate() 
        {

        VerticalMove();
        HorizontalMove();
        if(jump && jumpcount >0)
        Jump(); 
        

        }

    void VerticalMove()
        {
            Vector3 movement = transform.right * h_move * speed * Time.deltaTime;
            rb_capsule.MovePosition(rb_capsule.position + movement);
        }

    void HorizontalMove()
        {
            Vector3 movement = transform.forward * v_move * speed * Time.deltaTime;
            rb_capsule.MovePosition(rb_capsule.position + movement);
            //rb_capsule.MovePosition(rb_capsule.position + (new Vector3(1,0,0)*v_move*speed*Time.deltaTime));
        }

    void Jump()
        {
            rb_capsule.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            jumpcount--;
        }




}
