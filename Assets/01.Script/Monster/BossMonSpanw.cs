using UnityEngine;

public class BossMonSpanw : MonoBehaviour
{
    public static BossMonSpanw instance;
    [SerializeField] private GameObject BossPrefab;

    int SpawnCount;
    int SpawnMax;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
            Destroy(gameObject);
    }

    void Start()
    {
        SpawnCount = 0;
        SpawnMax = 1;
    }

    public void BossSpawn()
    {
        if(SpawnCount<SpawnMax)
        {
            Instantiate(BossPrefab, new Vector3(7, -4, 0), Quaternion.identity);
            SpawnCount++;
        }
    }

}
