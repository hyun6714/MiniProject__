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
        }

        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SpawnCount = 0;
        SpawnMax = 1;
    }

    public void ResetSpawnCount()
    {
        SpawnCount=0;
    }

    public void BossSpawn()
    {
        if(SpawnCount<SpawnMax)
        {
            GameObject bossobj = Instantiate(BossPrefab, new Vector3(7, -4, 0), Quaternion.identity);
            SpawnCount++;

            BossMonster bossSc = bossobj.GetComponent<BossMonster>();
            if (bossSc != null)
            {
                bossSc.bossHpbar = BossHpBarUI.instance;

                bossSc.ResetBossHp();
            }
        }
    }

}
