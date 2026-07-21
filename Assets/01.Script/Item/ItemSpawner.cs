using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    public static ItemSpawner instance;

    public int itemMax;
    public int itemTotal;

    int random;
    float itemtimer;

    float limitTime = 60f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        itemMax = 5;
        itemTotal = 0;
        itemtimer = 20f;

        InvokeRepeating("SpawnItem", 1f, itemtimer);

    }

    void Update()
    {
        limitTime -= Time.deltaTime;
    }

    public void SpawnItem()
    {
        float randomX = Random.Range(-9f, 9f);
        float randomY = Random.Range(-8.5f, 5f);

        if (itemTotal < itemMax)
        {
            Vector3 spawnP = new Vector3(randomX, randomY, 0);
            random = Random.Range(0, items.Length);

            Instantiate(items[random], spawnP, Quaternion.identity);
            itemTotal++;
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

    

    public void ItemSpawnStop()
    {
        CancelInvoke("SpawnItem");
        ItemScore[] itemInScene = FindObjectsByType<ItemScore>(FindObjectsSortMode.None);
        foreach(ItemScore item in itemInScene )
        {
            item.gameObject.SetActive(false);
        }

        itemTotal = 0;
        limitTime = 60f;
    }

    public void ClearItem()
    {
        ItemScore[] itemInScene = FindObjectsByType<ItemScore>(FindObjectsSortMode.None);
        foreach (ItemScore item in itemInScene)
        {
            item.gameObject.SetActive(false);
        }
    }
}
