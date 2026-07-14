using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
public class BubbleManager : MonoBehaviour
{
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject[] bubblePool;
    [SerializeField] private int poolSize;

    float bubbleLifetime;
    float bubbleSpeed;

    float attackDmg;

    public void Start()
    {
        poolSize = 10;

        bubbleLifetime = 10f;
        bubbleSpeed = 2f;

        attackDmg = 10;

        bubblePool = new GameObject[poolSize];
        for(int i=0; i<poolSize; i++)
        {
            bubblePool[i] = Instantiate(bubblePrefab);
            bubblePool[i].SetActive(false);
        }
    }

    private void Update()
    {
        transform.position += Vector3.up * bubbleSpeed * Time.deltaTime;
    }

    void BubleSummon()
    {
        if(Keyboard.current.enterKey.wasPressedThisFrame)
        {
            for (int i = 0; i < bubblePool.Length; i++)
            {
                if (!bubblePool[i].activeSelf)
                {
                    bubblePool[i].transform.position = target.position + new Vector3(1.5f, 0, 0);
                    bubblePool[i].SetActive(true);
                }
            }
        }
    }

}
