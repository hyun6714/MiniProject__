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
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        BackGoundChage();
        SpawnStage(0);
    }


    public void SpawnStage(int index)
    {
        if(currenStage != null)
        {
            Destroy(currenStage);
        }

        if(index >= 0 && index < stagePrefabs.Length)
        {
            currenStage = Instantiate(stagePrefabs[index], Vector3.zero, Quaternion.identity);
        }
    }

    public void StageClear() // 이거는 몬스터가 맵에 없을 때 발동해아하니 나중에 몬스터 만들 때 사용 
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
        if (cStage < stagePrefabs.Length)
        {
            cStage++;
            BackGoundChage();
            SpawnStage(cStage);

        }
    }

    public void ReStage()
    {
        if(currenStage != null)
        {
            Destroy(currenStage);
        }

        SpawnStage(cStage);
        Time.timeScale = 1;
        UIManager.instance.StageFClose();
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