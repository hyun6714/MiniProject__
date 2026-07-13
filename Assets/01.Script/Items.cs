using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] GameObject[] items;
    [SerializeField] int itemScore; // 각각 다른 점수들 만들기 

    int itemMax;
    int itemtatal;

    int random;
    float itemtimer;
    float itemLifetime;

    //1. 아이템== 보석 점수 정하기 
    //2. 맵에서 랜덤으로 생성 및 닿을 시 점수 증가 
    //3. 일정 시간 지나면 비활성화 
    //4. 어떻게 구현을 할까 고민 프리팹마다 점수 따로 정하기 

    private void Start()
    {
        itemMax = 5;
        itemtatal = 0;
        itemLifetime = 10f;
        itemtimer = 20f;

        InvokeRepeating("SummonEnemy", 1f, itemtimer);

    }

    private void Update()
    {
        ItemDeactivation();
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


    void ItemDeactivation()
    {
        itemLifetime -= Time.deltaTime;
        if(itemLifetime == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
