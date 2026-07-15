using UnityEngine;

public enum BossMonState
{
    Move,Die
}


public class BossMonster : Monster
{
    int hp = 1000;
    
    BossMonState Bstate;
    [SerializeField] GameManager BossPrefab;

    int dmg = Bubble.attackDmg;

    protected override void Move()
    {
        Bstate = BossMonState.Move;
        base.Move();
    }

    public void TakeDmg()
    {
        hp -= dmg;
        if(hp <=0)
        {
            Bstate = BossMonState.Die;
            gameObject.SetActive(false);

            GameManager.instance.GameClear();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bubble"))
        {
            TakeDmg();
        }
    }
    //보스몬스터의 공격 + 체력바 UI + 소환(스크립트 따로 생성)
}
