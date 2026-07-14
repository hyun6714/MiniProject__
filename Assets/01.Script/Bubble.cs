using UnityEngine;

public class Bubble : MonoBehaviour
{
    float bubbleLifetime;
    float attackDmg;
    float bubbleSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bubbleLifetime = 10f;
        attackDmg = 10;
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
}
