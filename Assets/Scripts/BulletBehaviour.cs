using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
bool toStatic=false;
Rigidbody2D myRigidbody;
[SerializeField] float bulletSpeed = 10f;
PlayerMovement player;
float xSpeed=0f;
CapsuleCollider2D bulletCollider;
    void Start()
    {
        bulletCollider = GetComponent<CapsuleCollider2D>();
        player = FindObjectOfType<PlayerMovement>();
        myRigidbody=GetComponent<Rigidbody2D>();
        xSpeed=player.transform.localScale.x*bulletSpeed;
        if(xSpeed<0){
            transform.localScale=new Vector2(-1f,1f);
        }
    }

    void Update()
    {
        if(toStatic)return;
        myRigidbody.velocity = new Vector2(xSpeed,0f);     
    }
     void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Enemy"){          
            Destroy(other.gameObject);
        }
        Destroy(gameObject);   
    }
    IEnumerator Destroyer(){
        yield return new WaitForSecondsRealtime(20f);
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other) {
        toStatic=true;
        myRigidbody.bodyType = RigidbodyType2D.Static;
        StartCoroutine(Destroyer());
    }  
}
