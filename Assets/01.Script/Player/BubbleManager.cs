using UnityEngine;
using UnityEngine.InputSystem;
public class BubbleManager : MonoBehaviour
{
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject[] bubblePool;
    [SerializeField] private int poolSize;
    SpriteRenderer targetsr;

    void Start()
    {
        if(target != null)
        {
            targetsr = target.GetComponent<SpriteRenderer>();
        }
        
        poolSize = 10;
        bubblePool = new GameObject[poolSize];
        for(int i=0; i<poolSize; i++)
        {
            bubblePool[i] = Instantiate(bubblePrefab);
            bubblePool[i].SetActive(false);
        }
    }

    void Update()
    {
        BubleSummon();  
    }

    public void BubleSummon()
    {
        if(Keyboard.current.enterKey.wasPressedThisFrame)
        {
            for (int i = 0; i < bubblePool.Length; i++)
            {
                if (!bubblePool[i].activeSelf)
                {
                    float direction = targetsr.flipX ? -1.5f : 1.5f; 

                    bubblePool[i].transform.position = target.position + new Vector3(direction,0,0);
                    bubblePool[i].SetActive(true);
                    break;
                }
            }
        }
    }

}
