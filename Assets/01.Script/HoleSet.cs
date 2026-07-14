using UnityEngine;

public class HoleSet : MonoBehaviour
{
    public int myHoleId;
    public TeleportManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.TeleporObject(myHoleId, collision.gameObject);
    }
}