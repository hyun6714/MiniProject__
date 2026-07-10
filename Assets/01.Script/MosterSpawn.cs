using UnityEngine;

public class MosterSpawn : MonoBehaviour
{
    float MinX;
    float MinY;
    float MaxX;
    float MaxY;

    [SerializeField] private GameObject enemyPrefap;

    void Start()
    {

        MinX = -4;
        MinY = -4;
        MaxX = 4;
        MaxY = 4;

        InvokeRepeating("SummonEnemy", 1f, 1f);
    }

    void SummonEnemy()
    {
        float x = Random.Range(MinX, MaxX);
        float y = Random.Range(MinY, MaxY);

        Instantiate(enemyPrefap, new Vector3(x, y, 0), Quaternion.identity);
    }

    public void StopSpawning()
    {
        CancelInvoke("SummonEnemy");
    }
}
