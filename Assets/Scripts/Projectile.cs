using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D projectileRb;

    void Awake() {
        projectileRb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        EnemyController enemy = other.collider.GetComponent<EnemyController>();
        if (enemy != null) {
            enemy.FixBroken();
            Destroy(gameObject);
        }
    }

    void Update() {
        if (transform.position.magnitude > 1000.0f) {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force) {
        projectileRb.AddForce(direction * force);
    }
}
