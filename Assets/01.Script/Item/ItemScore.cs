using UnityEngine;

public class ItemScore : MonoBehaviour
{
    [SerializeField] private int itemScore;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GetScoreItem();
            gameObject.SetActive(false);
        }
    }

    // º¸¼® ºí·ç 1000Á¡
    // ³ë¶û 2000
    // ÇÏ´Ã 3000
    // ¿¬µÎ 5000
    // »¡°­ 10000
}
