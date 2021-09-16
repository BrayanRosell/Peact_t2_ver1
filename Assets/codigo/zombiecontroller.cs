using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiecontroller : MonoBehaviour
{
   private SpriteRenderer sr;
    private Rigidbody2D rb2d;
    private float speed = 1;
    private bool limiteInicio = true;
    private bool limiteFin = false;
    // Start is called before the first frame update
    void Start()
    {
         sr= GetComponent<SpriteRenderer>();;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if(limiteInicio){
             sr.flipX = true;
            rb2d.velocity = new Vector2(-speed,rb2d.velocity.y);  
        }
        if(limiteFin){
            sr.flipX = false;
            rb2d.velocity = new Vector2(speed,rb2d.velocity.y);
        } 
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.layer == 6){
                limiteInicio = false;
                limiteFin = true;
        }
        if(other.gameObject.layer == 7){
                 
                limiteFin = false;
                limiteInicio = true;
        }
         if(other.gameObject.tag == "monedas"){//el zombie come a las monedas 
         Destroy(other.gameObject);  
        }
        
    }
}
 