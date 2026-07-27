using UnityEngine;
using UnityEngine.UI;

public class TImeUI : MonoBehaviour
{
    public static TImeUI instance;
    [SerializeField] private Image timerImage;
    float timeLimit = 60f;
    float timer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        timer = timeLimit;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerImage.fillAmount = timer / timeLimit; 
        }
    }

    public void ResetTimer()
    {
        timeLimit = 60f;
        timer = timeLimit;
    }
}
