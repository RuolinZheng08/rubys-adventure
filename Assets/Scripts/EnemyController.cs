using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D enemyRb;
    [SerializeField] float speed = 3.0f;
    [SerializeField] float changeDirectionTime = 3.0f;
    bool vertical = true;
    float timer;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        timer -= Time.deltaTime;
        if (timer < 0) { // time to change direction
            vertical = !vertical;
            direction = -direction;
            timer = changeDirectionTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = enemyRb.position;
        if (vertical) {
            position.y += speed * direction * Time.deltaTime;
        } else {
            position.x += speed * direction * Time.deltaTime;
        }
        enemyRb.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other) {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null) {
            player.ChangeHealth(-1);
        }
    }
}
