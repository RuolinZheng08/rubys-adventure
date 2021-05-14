using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other) {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null) {
            player.ChangeHealth(-1);
        }
    }
}
