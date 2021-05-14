using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D enemyRb;
    [SerializeField] float speed = 3.0f;
    [SerializeField] float changeDirectionTime = 2.0f;
    float timer = 0;
    bool vertical = true;
    int direction = 1;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        timer -= Time.deltaTime;
        if (timer < 0) { // time to change direction
            vertical = (Random.value < 0.5);
            direction = (Random.value < 0.5 ? 1 : -1);
            timer = changeDirectionTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = enemyRb.position;
        if (vertical) {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
            position.y += speed * direction * Time.deltaTime;
        } else {
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0);
            position.x += speed * direction * Time.deltaTime;
        }
        enemyRb.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other) {
        PlayerController player = other.collider.GetComponent<PlayerController>();
        if (player != null) {
            player.ChangeHealth(-1);
        }
    }
}
