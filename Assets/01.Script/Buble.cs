using UnityEngine;

public class Buble : MonoBehaviour
{
    [SerializeField] GameObject buble;

    float attackDmg;

    public void Start()
    {
        attackDmg = 10;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            //여기에 몬스터가 닿았을 시 구속상태로 변환 하거나 몬스터에서 구현 하기 
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("BossMonster"))
        {
            //보스몬스터가 닿았을 시 데미지 주기 
        }
    }

}
