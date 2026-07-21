using UnityEngine;

public class PotalManager : MonoBehaviour
{
    [SerializeField] GameObject potalPrefab;
    private GameObject currentPortal;
    public static PotalManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
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

    public void ClosePotal()
    {
        if (currentPortal != null)
        {
            currentPortal.SetActive(false);
        }

    }
}
