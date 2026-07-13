using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] TextMeshProUGUI scoreText;
    int totalScore;

    [SerializeField] GameObject gameOverPop;
    [SerializeField] GameObject reStagePop;
    [SerializeField] TextMeshProUGUI heartloosText;
    [SerializeField] TextMeshProUGUI heartReGamePopText;

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
        totalScore = 0;
        scoreText.text = "score : ";
    }

    public void GetScore(int sc)
    {
        totalScore += sc;
        scoreText.text = $"now score {totalScore}";
    }

    public void ReGameHeartPop()
    {
        int hearts = GameManager.instance.heart;
        heartReGamePopText.text = $" ♥  x {hearts}";
    }

    public void HeartLoss()
    {
        int hearts = GameManager.instance.heart;
        heartloosText.text = $" ♥  x  {hearts}";
    }

    public void GameOverPop()
    {
        gameOverPop.SetActive(true);
    }
    public void GameOverPopClose()
    {
        gameOverPop.SetActive(false);
    }
    public void StageF()//스테이지 실패 팝업 열기
    {
        reStagePop.SetActive(true);
        ReGameHeartPop();
    }
    public void StageFClose() // 스테이지 실패 팝업 닫기
    {
        reStagePop.SetActive(false);
    }
}
