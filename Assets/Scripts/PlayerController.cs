using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //movement
    Rigidbody2D playerRb;
    float horizontal;
    float vertical;
    [SerializeField] float speed = 3.0f;

    // health
    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    int currentHealth;

    // invincible
    [SerializeField] float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isInvincible) {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0) {
                isInvincible = false;
            }
        }
    }

    void FixedUpdate() {
        Vector2 position = playerRb.position;
        position.x += speed * horizontal * Time.deltaTime;
        position.y += speed * vertical * Time.deltaTime;
        playerRb.MovePosition(position);
    }

    public void ChangeHealth(int amount) {
        if (amount < 0) {
            if (isInvincible) {
                return;
            }
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}
