using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private GameObject[] items;

    int itemMax;
    int itemtatal;

    int random;
    float itemtimer;

    private void Start()
    {
        itemMax = 5;
        itemtatal = 0;
        itemtimer = 20f;

        InvokeRepeating("SpawnItem", 1f, itemtimer);//이거 스테이지 시작하고 소환하기+ 플레이어 충돌시 추가 필요

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
        else
        {
            CancelInvoke("SpawnItem");
        }
    }
}
