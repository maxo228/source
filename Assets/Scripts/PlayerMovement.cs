using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;//храним вектор движения
    Rigidbody2D myRigidbody;
    Animator myAnimator;//Animator)
    CapsuleCollider2D myBodyCollider;//body
    BoxCollider2D myFeetCollider;//feet
    float gravityScaleAtStart;
    [SerializeField] float climbSpeed=5f;
    [SerializeField] float jumpSpeed = 75f;// visota/skorosti prijka
    [SerializeField] float runSpeed=7.5f;
    [SerializeField] Vector2 deathKick = new Vector2(4f,10f);
    [SerializeField] GameObject bullet;

    //[SerializeField] GameObject gun;
    public bool isAlive = true;
    
    


    void Start()
    {
        myFeetCollider=GetComponent<BoxCollider2D>();
        myBodyCollider=GetComponent<CapsuleCollider2D>();
        myAnimator = GetComponent<Animator>();
        myRigidbody=GetComponent<Rigidbody2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;//startovaya gravity
    }
    void OnMove(InputValue value)//method otslijivanya dvijenya
    {
        moveInput = value.Get<Vector2>();
        //Debug.Log("value: "+moveInput);
    }

    void Update()
    {
        if(!isAlive){return;}
        Run();
        MirrorSprite();
        ClimbLadder();
        Die();
        
        //8

    }
    void MirrorSprite(){
        bool inHorizontalMovement = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;//maximum blizok k nuliu 
        if(inHorizontalMovement){
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x),1f);// усли минус то = -1 , если + то +1
        }
    }
    void Run(){
        Vector2 playerVelocity = new Vector2(moveInput.x*runSpeed,myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool inHorizontalMovement = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if(inHorizontalMovement){
            myAnimator.SetBool("isRunning",true);//myAnimator.SetBool("isRunning",inHorizontal)
        }
        else{
            myAnimator.SetBool("isRunning",false);
        }
    }
    void OnJump(InputValue value){

        if(value.isPressed&&myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            myRigidbody.velocity=myRigidbody.velocity + new Vector2(0f,jumpSpeed);
             
        }

    }
    void ClimbLadder(){
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ladders")))
            {
                
                myRigidbody.gravityScale=gravityScaleAtStart;
                return;
            } 
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x,moveInput.y*climbSpeed);
        myRigidbody.velocity = climbVelocity;
        myRigidbody.gravityScale=0f;
        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y)>Mathf.Epsilon;
        //тут анимация должна быть 
        //idle поменять!!
    }
    void Die(){
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("enemy","Spikes"))){

        isAlive = false;
        myAnimator.SetTrigger("Dying");
        myRigidbody.velocity= deathKick;
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
            //StartCoroutine(DyingTime());          
        }
    }

    void OnFire(InputValue value){
        if(!isAlive){return;}
        Instantiate(bullet,transform.position,transform.rotation);//появление пули 
    }

    

        
    }

