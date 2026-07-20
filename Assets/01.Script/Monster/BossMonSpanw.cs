using UnityEngine;

public class BossMonSpanw : MonoBehaviour
{
    public static BossMonSpanw instance;
    [SerializeField] private GameObject BossPrefab;

    int spawnCount;
    int spawnMax;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        spawnCount = 0;
        spawnMax = 1;
    }
    public void ResetSpawnCount()
    {
        spawnCount=0;
    }

    public void BossSpawn()
    {
        Debug.Log("소환 시도");
        if(BossPrefab == null)
        {
            Debug.Log("Boss null");
        }

        if(spawnCount<spawnMax)
        {
            GameObject bossobj = Instantiate(BossPrefab, new Vector3(7, -4, 0), Quaternion.identity);
            Debug.Log("소환완료");
            spawnCount++;

            BossMonster bossSc = bossobj.GetComponent<BossMonster>();
            if (bossSc != null)
            {
                bossSc.bossHpbar = BossHpBarUI.instance;
                bossSc.ResetBossHp();

                BossHpBarUI.instance.OnSlider();
            }
        }
        else
        {
            Debug.Log($"소환 실패 카운트 {spawnCount}");
        }
    }

}
