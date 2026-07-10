using UnityEngine;
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

    public void StageFail()
    {
        gameState = GameState.StageFail;
        Time.timeScale = 0;

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
        UIManager.instance.GameOverPop();
    }

    public void GameClear()
    {
        gameState = GameState.GameClear;
        //게임클리어시 최종점수+ 메인 화면 가는 버튼 생성 
    }

    public void StageClear()
    {
        gameState = GameState.StageClear;
        //여기에 스테이지 클리어 시 나오는 UI추가 필요 
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
