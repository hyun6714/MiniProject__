using UnityEngine;
using System.Linq;
using System;
enum GameState
{
    StageClear, StageFail, GameOver, GameClear
}

public class GameManager : MonoBehaviour
{
    private GameState gameState;

    public static float monSpeed;
    public float timeLimit = 60f;
    private bool isHurryUp;


    public int maxheart = 1;
    public int heart = 1;
    public int currentScore = 0;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        ResetHeart();
    }

    private void Start()
    {
        monSpeed = 1.5f;
        isHurryUp = false;
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

    public void ResetHeart()
    {
        heart = maxheart;
    }

    public void ResetScore()
    {
        currentScore = 0;
        if(UIManager.instance != null)
        {
            UIManager.instance.ScoreRe();
        }
    }

    public void StageFail()
    {
        gameState = GameState.StageFail;
        Time.timeScale = 0;
        MonsterSpawn.instance.StopSpawning();
        ResetScore();

        heart--;
        UIManager.instance.StageF(); 
        if(heart <=0)
        {
            heart = 0;
            GameOver();
        }
    }

    public void GameOver()
    {
        UIManager.instance.StageFClose();

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
        UIManager.instance.TotalScroe();
        MonsterSpawn.instance.StopSpawning();
    }

    public void CheckClear()
    {
        GameObject[] allmon = GameObject.FindGameObjectsWithTag("Monster");
        if(allmon.Count(m => m.activeInHierarchy) == 0)
        {
            Debug.Log("체크 호출");
            StageClear();
            StageManager.instance.StageClear();
        }
    }

    public void TimeUp()
    {
        isHurryUp =true;
       
        TimeoutSpeedUp();

    }

    public void ResetTimer()
    {
        timeLimit = 60;
        isHurryUp = false;
    }

    public void TimeoutSpeedUp()
    {
        if(isHurryUp)
        {
            return;
        }
        monSpeed *= 2;
        Debug.Log($"현재 몬스터 속도 {monSpeed}");
    }
}
