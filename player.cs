using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    Rigidbody2D rb;
    public float speed;


     void Awake(){
        rb=GetComponent<Rigidbody2D>();
    }


    void Start(){
        
    }

   
    void Update(){
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal")* speed,0));
        
    }
}
