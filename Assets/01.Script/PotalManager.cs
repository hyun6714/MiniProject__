using UnityEngine;

public class PotalManager : MonoBehaviour
{
    [SerializeField] GameObject potalPrefab;
    private GameObject currentPortal;
    public static PotalManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void SpawnPotal(Vector3 position)
    {
        if(currentPortal == null)
        {
            currentPortal = Instantiate(potalPrefab, position, Quaternion.identity);
        }
        else
        {
            currentPortal.transform.position = position;
            currentPortal.SetActive(true);
        }
    }

}
