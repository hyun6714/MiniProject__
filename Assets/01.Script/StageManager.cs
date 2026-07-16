using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public Transform[] portalSpawnPoints;
    public int cStage;

    [SerializeField] private GameObject backGrounA;
    [SerializeField] private GameObject backGrounB;
    [SerializeField] private GameObject backGrounC;

    public GameObject[] stagePrefabs;
    public GameObject currenStage;

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

    private void Start()
    {
        BackGoundChage();
        SpawnStage(cStage);

        SpawnBossMon();//체크용 삭제필요
    }

    public void SpawnBossMon()
    {
        if(cStage == 4)
        {
            MonsterSpawn.instance.StopSpawning();
            BossMonSpanw.instance.BossSpawn();
        }
    }

    public void SpawnStage(int index)
    {
        if(currenStage != null)
        {
            Destroy(currenStage);
            currenStage = null;
        }

        if(index >= 0 && index < stagePrefabs.Length)
        {
            currenStage = Instantiate(stagePrefabs[index], Vector3.zero, Quaternion.identity);
        }
    }

    public void StageClear()
    {
        GameManager.instance.StageClear();
        if (cStage < portalSpawnPoints.Length)
        {
            Vector3 targetPos = portalSpawnPoints[cStage].position;
            PotalManager.instance.SpawnPotal(targetPos);
            GameManager.instance.ResetTimer();
        }
    }

    public void NextStage()
    {
        Monster.currentMonCount = 5;
        cStage++;
        if (cStage < stagePrefabs.Length)
        {
            BackGoundChage();
            SpawnStage(cStage);

            ItemSpawner.instance.SpawnItem();
            GameManager.instance.ResetTimer();

            SpawnBossMon();
            MonsterSpawn.instance.InvokeRepeating("SummonEnemy", 1f, 1f);
        }
    }


    public void ReStage()
    {
        if(currenStage != null)
        {
            Destroy(currenStage);
            currenStage = null;
        }

        Monster.currentMonCount = 5;
        SpawnStage(cStage);
        Time.timeScale = 1;

        UIManager.instance.StageFClose();
        GameManager.instance.ResetTimer();
        ItemSpawner.instance.SpawnItem();

        MonsterSpawn.instance.InvokeRepeating("SummonEnemy", 1f, 1f);

    }

    public void BackGoundChage() //뒷배경 변경 
    {
        backGrounA.SetActive(false);
        backGrounB.SetActive(false);
        backGrounC.SetActive(false);
        if (cStage <= 2)
        {
            backGrounA.transform.position = new Vector3(0, 0, 0);
            backGrounB.SetActive(false);
            backGrounC.SetActive(false);
            backGrounA.SetActive(true);
        }
        else if (cStage == 5)
        {
            backGrounC.transform.position = new Vector3(0, 0, 0);
            backGrounA.SetActive(false);
            backGrounB.SetActive(false);
            backGrounC.SetActive(true);
        }
        else
        {
            backGrounB.transform.position = new Vector3(0, 0, 0);
            backGrounA.SetActive(false);
            backGrounC.SetActive(false);
            backGrounB.SetActive(true);
        }
    }
}