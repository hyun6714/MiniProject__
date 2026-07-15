using UnityEngine;
using UnityEngine.UI;

public class TImeUI : MonoBehaviour
{
    public Image timerImage;
    public float timeLimit = 60f;
    private float timer;

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
}
