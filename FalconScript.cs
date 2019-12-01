using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// script da Falcon 
public class FalconScript : MonoBehaviour {

    int Delay = 0;
    GameObject a,b;
    public GameObject big, Boom;
    Rigidbody2D rb;
    public float speed;
    int health = 3;


    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
        b = transform.Find("b").gameObject;
       
    }

    void Start() {
        PlayerPrefs.SetInt("Health", health);
    }

    void Update() {

        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));
        if (Input.GetKey(KeyCode.Space) && Delay > 10)
            Shoot();
        Delay++;
       
    }

    public void Damage() {
        health--;
        PlayerPrefs.SetInt("Health", health);
        StartCoroutine(Blink());
        if (health == 0){ 
            Instantiate(Boom, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);


        }
        if(health == 0){
          
                SceneManager.LoadScene(2);
        }
      
    }


    IEnumerator Blink(){
        GetComponent<SpriteRenderer>().color = new Color(1,0,0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }
    
    void Shoot(){
        Delay = 0;
        Instantiate(big,a.transform.position, Quaternion.identity);
        Instantiate(big,b.transform.position, Quaternion.identity);

        


    }

    public void Addhealth()
    {
        health++;
        PlayerPrefs.SetInt("Health", health);
    }


}
