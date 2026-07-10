using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject gameOverPop;
    [SerializeField] GameObject reStagePop;
    [SerializeField] TextMeshProUGUI heartloosText;
    [SerializeField] TextMeshProUGUI heartReGamePopText;
    float score;

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
        score = 0;
        scoreText.text = "score : ";
    }

    public void GetScore()
    {

        score++;//변경 해야함 
        scoreText.text = $"now score {score}";
    }

    public void ReGameHeartPop() //왜있는거지?
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
