using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;

    void OnTriggerEnter2D(Collider2D other) {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null && player.health < player.maxHealth) {
            player.ChangeHealth(1);
            player.PlaySound(collectedClip);
            Destroy(gameObject);
        }
    }
}
