using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playercontroller : MonoBehaviour
{
     private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb2d;
    private float speed = 8;
    private bool muere = false;

    public Text scoreText;

    private int scoreAmarillo = 0;
    private int scoreRojo = 0;
    private int scorePlomo = 0;
    // Start is called before the first frame update
    void Start()
    {
        sr= GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "AMARILLO: "+scoreAmarillo +"     " +"ROJO: " +scoreRojo+"     "+"PLOMO: "+ scorePlomo;
         rb2d.gravityScale = 25;
         if(muere!=true){//si esta vivo
         quieto();
        if(Input.GetKey(KeyCode.Space))
            {  
                saltar();          
            saltarF();
            
            }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            correr();
            
            rb2d.velocity = new Vector2(speed,rb2d.velocity.y);
            if(Input.GetKey(KeyCode.Space))
            { 
            saltar();           
            saltarF();
            
            }
           
            if(Input.GetKey(KeyCode.Z))
            {
            deslizar();
            }
             
        }else if(Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            correr();
            rb2d.velocity = new Vector2(-speed,rb2d.velocity.y);
            if(Input.GetKey(KeyCode.Space))
            {
                saltar();
               saltarF();
             
           
            }
            
             if(Input.GetKey(KeyCode.Z))
            {
            deslizar();
            }
        }
         }else
        {
          
        }
    }
    void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.layer == 10){//rojo  
         Destroy(other.gameObject);  
         scoreRojo++;
        }
        if(other.gameObject.layer == 11){// amarillo 
         Destroy(other.gameObject);  
         scoreAmarillo++;
        }
        if(other.gameObject.layer == 12){//plomo  
         Destroy(other.gameObject);  
         scorePlomo++;
        }
        if(other.gameObject.layer == 8){//zombie (el player muere)
             Destroy(this.gameObject);
            
             muere = true; 
          
        }
    }
       public void saltarF(){
        var upSpeed = 80f;
        rb2d.velocity = Vector2.up * upSpeed;
        saltar();
    }
    public void quieto(){
        animator.SetInteger("Estado", 0);        
    }
     public void saltar(){
        animator.SetInteger("Estado", 1);        
    }
     public void deslizar(){
        animator.SetInteger("Estado", 2);        
    }
    public void correr(){
        animator.SetInteger("Estado", 3);        
    }
}
