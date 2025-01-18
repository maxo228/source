using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
[SerializeField] AudioClip CoinPickUpSFX;
[SerializeField] int pointsForCoinPickup=10;
bool wasCollected=false;
void OnTriggerEnter2D(Collider2D other){
if(other.tag=="Player"&&!wasCollected){
    wasCollected=true;
    FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
    AudioSource.PlayClipAtPoint(CoinPickUpSFX,other.transform.position);
    Destroy(gameObject);

}
}
}
