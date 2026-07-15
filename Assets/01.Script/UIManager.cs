using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] TextMeshProUGUI scoreText;
    int totalScore;
    int currentScore;
    [SerializeField] private GameObject gameOverPop;
    [SerializeField] private GameObject reStagePop;
    [SerializeField] private GameObject hurryUpPop;
    [SerializeField] private TextMeshProUGUI heartReGamePopText;
    [SerializeField] private TextMeshProUGUI totalScoreText;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);    }

    private void Start()
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
        scoreText.text = $"Now Score {0}";
    }

    public void TotalScroe()
    {
        totalScore += currentScore;
        totalScoreText.text = $"Total Score {totalScoreText}";
    }

    public void ReGameHeartPop()
    {
        int hearts = GameManager.instance.heart;
        heartReGamePopText.text = $" ♥  x {hearts}";
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
            StopAllCoroutines();
            StartCoroutine(HurryUpRoutine());
        }
    }

    IEnumerator HurryUpRoutine()
    {
        hurryUpPop.SetActive(true);

        yield return new WaitForSeconds(2f);

        hurryUpPop.SetActive(false);
    }
}
