using UnityEngine;

public class Potal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StageManager.instance.NextStage();
        }
    }
}
