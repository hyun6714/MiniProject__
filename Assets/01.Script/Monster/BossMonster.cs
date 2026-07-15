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
    //여기에 받는 데미지 공식 및 보스만의 공격& 맞으면 플레이어 사망 및 등등등 기억안나서 패스 
}
