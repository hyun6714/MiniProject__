using UnityEngine;
using UnityEngine.UI;

public class BossHpBarUI : MonoBehaviour
{
    [SerializeField] Slider bossHpbar;
    public static BossHpBarUI instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

    }

    public void OnSlider()
    {
        gameObject.SetActive(true);
    }

    public void CloseSlider()
    {
       gameObject.SetActive(false);
    }

    public void Setup(float maxHp)
    {
        bossHpbar.maxValue = maxHp;
        bossHpbar.value = maxHp;
    }

    public void UpdateHpSlider(float currentHp)
    {
       bossHpbar.value = currentHp;
    }
}
