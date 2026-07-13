using UnityEngine;

public class ItemScore : MonoBehaviour
{
    [SerializeField] int itemScore;
    float itemLifetime;

    private void Start()
    {
        itemLifetime = 10f;
    }

    private void Update()
    {
        ItemDeactivation();
    }

    void GetScoreItem()
    {
        UIManager.instance.GetScore(itemScore);
    }

    void ItemDeactivation()
    {
        itemLifetime -= Time.deltaTime;
        if (itemLifetime == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
