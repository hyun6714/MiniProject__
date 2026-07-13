using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{

    public static MonsterSpawn instance;

    float MinX;
    float MinY;
    float MaxX;
    float MaxY;

    [SerializeField] private GameObject[] enemyPrefaps;

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
        if(spawnCount < spawnMax) //고쳐야함 몬스터 5마리 까지만 소환하기로 
        {
            float x = Random.Range(MinX, MaxX);
            float y = Random.Range(MinY, MaxY);
            randommon = Random.Range(0, enemyPrefaps.Length);

            Instantiate(enemyPrefaps[randommon], new Vector3(x, y, 0), Quaternion.identity);
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
    }
}
