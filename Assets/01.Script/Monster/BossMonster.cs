using UnityEngine;

public enum BossMonState
{
    Move,Die
}

public class BossMonster : Monster
{
    [SerializeField] private int maxHp = 1000;
    [SerializeField] private int currenHp;

    public BossHpBarUI bossHpbar;
    
    BossMonState Bstate;

    protected override void Awake()
    {
        currenHp = maxHp;
        base.Awake();

        if(bossHpbar != null)
        {
            bossHpbar.Setup(maxHp);
        }
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
        int dmg = Bubble.attackDmg;
        Debug.Log("데미지");
        currenHp -= dmg;
        if(currenHp <=0)
        {
            currenHp = 0;
            Die();
        }

        if(bossHpbar != null)
        {
            bossHpbar.UpdateHpSlider(currenHp);
        }
    }

    void Die()
    {
        Bstate = BossMonState.Die;
        GameManager.instance.GameClear();
        gameObject.SetActive(false);
        BossHpBarUI.instance.CloseSlider();
    }

    public void ResetBossHp()
    {
        currenHp = maxHp;
        if(bossHpbar != null)
        {
            bossHpbar.Setup(maxHp);
            bossHpbar.OnSlider();
        }
        bossHpbar.gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bubble"))
        {
            Debug.Log("호출");
            TakeDmg();
        }
    }
}
