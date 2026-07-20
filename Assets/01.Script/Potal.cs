using UnityEngine;

public class Potal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StageManager.instance.NextStage();
        }
    }
}
