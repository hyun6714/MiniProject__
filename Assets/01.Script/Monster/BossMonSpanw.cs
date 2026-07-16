using UnityEngine;

public class BossMonSpanw : MonoBehaviour
{
    public static BossMonSpanw instance;
    [SerializeField] private GameObject BossPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
            Destroy(gameObject);
    }

    public void BossSpawn()
    {
        Instantiate(BossPrefab, new Vector3(7, -4, 0), Quaternion.identity);
    }

}
