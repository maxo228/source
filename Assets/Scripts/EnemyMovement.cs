using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    [SerializeField] float moveSpeed;
    //TileMapCollider2D myCollider;
    void Start()
    {
        //myCollider= GetComponent<TileMapCollider2D>();
        myRigidbody=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidbody.velocity=new Vector2(-moveSpeed,0f);
        
    }
    void OnTriggerExit2D(Collider2D other) {
        moveSpeed = -moveSpeed;
        //if(myCollider.IsTouchingLayers(LayerMask.GetMask("Player"))){return;}
        if(gameObject.tag=="Enemy")FlipSprite();
    }
    void FlipSprite(){
        transform.localScale= new Vector2(Mathf.Sign(myRigidbody.velocity.x),1f);
    }
}
