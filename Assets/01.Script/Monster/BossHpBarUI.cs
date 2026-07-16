using UnityEngine;
using UnityEngine.UI;

public class BossHpBarUI : MonoBehaviour
{
    [SerializeField] Slider bossHpbar;

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
