using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMovement : MonoBehaviour
{
    Rigidbody2D cloudsRB;
    Vector2 startPosition;
    void Start()
    {
        cloudsRB = GetComponent<Rigidbody2D>();
        startPosition = cloudsRB.transform.position;

    }

    
    void Update()
    {
        cloudsRB.velocity = new Vector2 (0.5f,0f);
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "EndOfMap"){
            cloudsRB.transform.position = startPosition;
        }

        
    }
}
