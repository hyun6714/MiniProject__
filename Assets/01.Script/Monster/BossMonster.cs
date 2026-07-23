using UnityEngine;

public enum BossMonState
{
    Move,Die
}

public class BossMonster : Monster
{
    [SerializeField] private int maxHp = 1000;
    [SerializeField] private int currenHp;
    [SerializeField] GameObject bossAmmoPrefab;
    [SerializeField] GameObject bossButtle;

    float attackTimer;
    float timeMax = 10f;

    int bulletCount = 5;
    float spacing = 1f;

    float lastX;
    Animator bossMonAnim;
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

    void Start()
    {
        bossMonAnim = GetComponent<Animator>();
        
    }

    void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > timeMax)
        {
            Attack();
        }

        if (Bstate != BossMonState.Die)
        {
            mstate = MonsterState.Move;
            Move();
        }
    }

    protected override void Move()
    {
        Bstate = BossMonState.Move;
        base.Move();

        bool isMove = (Mathf.Abs(transform.position.x - lastX) > 0.001f);
        if (bossMonAnim != null)
        {
            bossMonAnim.SetBool("IsMove", isMove);
        }

        lastX = transform.position.x;
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

    public void Attack()
    {
        Vector3 bossPos = transform.position;
        Quaternion bossRot = transform.rotation;

        attackTimer = 0f;
        for (int i = 0; i < bulletCount; i++)
        {
            float offset = i - (bulletCount / 2);
            Vector3 localOffset = new Vector3(offset * spacing, 0, 0);
            Vector3 rotatedOffset = bossRot * localOffset;
            Vector3 spawnPos = bossPos + rotatedOffset;

            Instantiate(bossButtle, spawnPos, bossRot);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bubble"))
        {
            TakeDmg();
        }
    }
}
