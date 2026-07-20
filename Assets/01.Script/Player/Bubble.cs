using System.Collections;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    float bubbleLifetime;
    public static int attackDmg = 10;
    float bubbleSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bubbleLifetime = 10f;
        bubbleSpeed = 2f;
    }

    // Update is called once per frame
    void Update() 
    {
        transform.position += Vector3.up * bubbleSpeed * Time.deltaTime;

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
        Debug.Log("Ãæµ¹"+collision.gameObject.name);
        if (collision.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            gameObject.SetActive(false);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("BossMonster"))
        {
            gameObject.SetActive(false);
        }
    }

}
