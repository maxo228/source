using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDestroyer : MonoBehaviour
{
void OnTriggerEnter2D(Collider2D other) {
    if(other.tag=="SpikeEnemy"){
        Destroy(other.gameObject);
    }
    
}
}
