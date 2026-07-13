using UnityEngine;
using System.Collections.Generic;

public class MonsterSpawn : MonoBehaviour
{

    public static MonsterSpawn instance;

    float MinX;
    float MinY;
    float MaxX;
    float MaxY;

    [SerializeField] private GameObject[] enemyPrefaps;
    public List<GameObject> monPool = new List<GameObject>();

    int spawnCount;
    int spawnMax;

    int randommon;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        spawnCount = 0;
        spawnMax = 5;

        MinX = -9;
        MinY = -8.5f;
        MaxX = 9;
        MaxY = 5;

        InvokeRepeating("SummonEnemy", 1f, 1f);
    }

    void SummonEnemy()
    {

        GameObject mons = monPool.Find(m => !m.activeInHierarchy);
   
        if(spawnCount < spawnMax)
        {
            randommon = Random.Range(0, enemyPrefaps.Length);
            GameObject newMon = Instantiate(enemyPrefaps[randommon], new Vector3(x, y, 0), Quaternion.identity);
            spawnCount++;
        }
        else
        {
            CancelInvoke("SummonEnemy");
        }
    }

    public void StopSpawning()
    {
        CancelInvoke("SummonEnemy");
        Monster[] mon = FindObjectsByType<Monster>(FindObjectsSortMode.None);
        foreach (Monster monster in mon)
        {
            Destroy(monster.gameObject);
        }
        spawnCount = 0;
    }
}
