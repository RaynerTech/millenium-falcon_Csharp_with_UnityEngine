using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour{

    Rigidbody2D rb;

    public GameObject big, Boom, espolio;

    public Color Bigcolor;

    public float speedx;
    public float speedy;
    public int score;

    public bool shoot;
    public float fire;
    public float health;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();  
    }


   
    void Start(){
        if (!shoot) return;
        fire = fire + (Random.Range(fire / -2, fire / 2));
            InvokeRepeating("shot", fire, fire);
    }




    void Update(){
        rb.velocity= new Vector2(speedx,speedy * - 1);
    }

     void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "player"){
            collision.gameObject.GetComponent<FalconScript>().Damage();
            Die();           

        }


    }

   

    void Die(){
        if ((int)Random.Range(0,3) == 0)
        Instantiate(espolio, transform.position, Quaternion.identity);
        Instantiate(Boom, transform.position, Quaternion.identity);
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+ score);
        Destroy(gameObject);
        
    }

   


    public void Damage(){
        health--;
        if (health == 0)
            Die();
       
    }

  





    void shot(){
        GameObject temp = (GameObject)Instantiate(big,transform.position, Quaternion.identity);
        temp.GetComponent<Big>().MudarDirecao();
        temp.GetComponent<Big>().MudarCor(Bigcolor);
        
    }

    

}

