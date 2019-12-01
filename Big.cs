using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big : MonoBehaviour{

    Rigidbody2D rb;
    int dir = 1;

    

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    public void MudarDirecao(){
        dir *= -1;
       
    }

    public void MudarCor(Color collision){

        GetComponent<SpriteRenderer>().color=collision;
    }


    void Update(){
        rb.velocity = new Vector2(0,12 * dir);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (dir == 1){ 
            if (collision.gameObject.tag == "enemy")
            {
                collision.gameObject.GetComponent<Enemy>().Damage();
                Destroy(gameObject);
            }

        }
        else{ 
             if (collision.gameObject.tag == "player"){
                collision.gameObject.GetComponent<FalconScript>().Damage();
                Destroy(gameObject);
            }
        }
    }

   
}
