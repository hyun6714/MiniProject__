using UnityEngine;
using UnityEngine.UI;

public class TImeUI : MonoBehaviour
{
    public static TImeUI instance;
    public Image timerImage;
    public float timeLimit = 60f;
    private float timer;

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
