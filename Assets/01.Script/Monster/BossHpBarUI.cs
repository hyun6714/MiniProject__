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

    private void Start()
    {
        CloseSlider();
    }

    public void OnSlider()
    {
        bossHpbar.gameObject.SetActive(true);
    }

    public void CloseSlider()
    {
        bossHpbar.gameObject.SetActive(false);
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
