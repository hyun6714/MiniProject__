using UnityEngine;

public class Bubble : MonoBehaviour
{
    float bubbleLifetime;
    float attackDmg;
    float bubbleSpeed;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        bubbleLifetime = 10f;
        attackDmg = 10;
        bubbleSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = Vector2.up * bubbleSpeed;

        DeactivateBubble();
    }

    private void OnEnable()
    {
        bubbleLifetime = 10f;
    }

    void DeactivateBubble()
    {
        bubbleLifetime -= Time.deltaTime;
        if(bubbleLifetime <= 0)
        {
            bubbleLifetime = 0;
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
