using UnityEngine;
using System.Linq;
enum GameState
{
    StageClear, StageFail, GameOver, GameClear
}

public class GameManager : MonoBehaviour
{
    private GameState gameState;

    public float timeLimit = 60f;
    private bool isHurryUp;

    public int heart;

    public static GameManager instance;

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
        isHurryUp = false;
        heart = 3;
    }

    private void Update()
    {
        if(timeLimit > 0)
        {
            timeLimit -= Time.deltaTime;

            if (timeLimit <= 0)
            {
                timeLimit = 0;
                TimeUp();
            }
        }
    }

    public void StageFail()//점수 초기화하는데 그스테이지에 얻은 점수 초기화 + 버블 삭제 
    {
        gameState = GameState.StageFail;
        Time.timeScale = 0;
        MonsterSpawn.instance.StopSpawning();

        heart--;
        UIManager.instance.HeartLoss();
        UIManager.instance.StageF(); 
        if(heart <=0)
        {
            heart = 0;
            GameOver();
        }
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
        Time.timeScale = 0;
        MonsterSpawn.instance.StopSpawning();
        UIManager.instance.GameOverPop();
    }

    public void GameClear()
    {
        gameState = GameState.GameClear;
        MonsterSpawn.instance.StopSpawning();
    }

    public void StageClear()
    {
        gameState = GameState.StageClear;
        MonsterSpawn.instance.StopSpawning();
    }

    public void CheckClear()
    {
        GameObject[] allmon = GameObject.FindGameObjectsWithTag("Monster");
        if(allmon.Count(m => m.activeInHierarchy) == 0)
        {
            StageClear();
            StageManager.instance.StageClear();
        }
    }

    public void TimeUp()
    {
        isHurryUp =true;
       
       //여기에 시간초과시 들어갈 몬스터 속도증가 및 UI추가 
    }

    public void ResetTimer()
    {
        timeLimit = 60;
        isHurryUp = false;
    }
}
