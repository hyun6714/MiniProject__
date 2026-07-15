using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private GameObject[] items;

    int itemMax;
    int itemtatal;

    int random;
    float itemtimer;

    float limitTime = 60f;

    private void Start()
    {
        itemMax = 5;
        itemtatal = 0;
        itemtimer = 20f;

        InvokeRepeating("SpawnItem", 1f, itemtimer);

    }

    void Update()
    {
        limitTime -= Time.deltaTime;
    }

    void SpawnItem()
    {
        float randomX = Random.Range(-9f, 9f);
        float randomY = Random.Range(-8.5f, 5f);

        if (itemtatal < itemMax)
        {
            Vector3 spawnP = new Vector3(randomX, randomY, 0);
            random = Random.Range(0, items.Length);

            Instantiate(items[random], spawnP, Quaternion.identity);
            itemtatal++;
        }
        else if (limitTime <=0)
        {
            CancelInvoke("SpawnItem");
        }
        else
        {
            CancelInvoke("SpawnItem");
        }
    }
}
