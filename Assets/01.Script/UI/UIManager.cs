using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    int totalScore;
    int currentScore;

    [SerializeField] GameObject gameOverPop;
    [SerializeField] GameObject reStagePop;
    [SerializeField] GameObject hurryUpPop;
    [SerializeField] GameObject clearPop;

    [SerializeField] TextMeshProUGUI heartReGamePopText;
    [SerializeField] TextMeshProUGUI totalScoreText;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        int hearts = GameManager.instance.heart;
        heartReGamePopText.text = $" ♥  x {hearts}";

        totalScore = 0;
        scoreText.text = "Score : 0";
        totalScoreText.text = $"Total Score 0";
    }

    public void GetScore(int sc)
    {
        currentScore += sc;
        scoreText.text = $"Now Score {currentScore}";
    }

    public void ScoreRe()
    {
        currentScore = 0;
        scoreText.text = $"Now Score {0}";
    }

    public void TotalScroe()
    {
        totalScore += currentScore;
        totalScoreText.text = $"Total Score {totalScore}";
    }

    public void ReGameHeartPop()
    {
        int hearts = GameManager.instance.heart;
        heartReGamePopText.text = $" ♥  x {hearts}";
    }

    public void GameClearPop()
    {
        if(clearPop != null)
        {
            clearPop.SetActive(true);
        }
    }

    public void GameClearPopClose()
    {
        if(clearPop != null)
        {
            clearPop.SetActive(false);
        }
    }

    public void GameOverPop()
    {
        if (gameOverPop != null)
        {
            gameOverPop.SetActive(true);
        }
    }
    public void GameOverPopClose()
    {
        if(gameOverPop != null)
        {
            gameOverPop.SetActive(false);
        }
    }
    public void StageF()//스테이지 실패 팝업 열기
    {
        if (reStagePop != null)
        {
            reStagePop.SetActive(true);
            ReGameHeartPop();
        }
    }
    public void StageFClose() // 스테이지 실패 팝업 닫기
    {
        if(reStagePop != null)
        {
            reStagePop.SetActive(false);
        }
    }

    public void HurryPop()
    {
        if(hurryUpPop !=null)
        {
            StopCoroutine(HurryUpRoutine());
            StartCoroutine(HurryUpRoutine());
        }
    }

    IEnumerator HurryUpRoutine()
    {
        hurryUpPop.SetActive(true);

        yield return new WaitForSeconds(2f);

        hurryUpPop.SetActive(false);
    }

    public void UICloseAllPop() //게임시작 함수를 만들고 거기에 넣기 + 메인씬으로 가기전에 다 꺼버리기 
    {
        StageFClose();
        GameOverPopClose();
        GameClearPopClose();
    }
}
