using UnityEngine;

public enum BossMonState
{
    Move,Die
}


public class BossMonster : Monster
{
    int hp = 1000;
    
    BossMonState Bstate;

    int dmg = Bubble.attackDmg;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void Move()
    {
        Bstate = BossMonState.Move;
        base.Move();
    }

    protected override void SetNewTarget()
    {
        base.SetNewTarget();
    }

    protected override void SpriteDirection(float direction)
    {
        sr.flipX = (direction > 0);
    }

    public void TakeDmg()
    {
        hp -= dmg;
        if(hp <=0)
        {
            Bstate = BossMonState.Die;
            gameObject.SetActive(false);
            Die();
        }
    }

    void Die()
    {
        GameManager.instance.GameClear();
        //여기에서 죽는다면 필요한 것들 호출
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bubble"))
        {
            TakeDmg();
        }
    }
    //보스몬스터의 공격 + 체력바 UI + 소환(스크립트 따로 생성) + 이동하는 거 업데이트로 스위치문으로 하기 
}
