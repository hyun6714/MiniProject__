using UnityEngine;

public class BossButtle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerDie();
        }
    }

    void PlayerDie()
    {
        GameManager.instance.StageFail();
    }
}