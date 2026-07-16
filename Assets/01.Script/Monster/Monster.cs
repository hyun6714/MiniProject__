using UnityEngine;

public enum MonsterState
{
    Confined, Move , Die
}

public class Monster : MonoBehaviour
{

    public MonsterState mstate;

    float score;
    float randomX;
    float randomY;

    public static int currentMonCount = 5;

    float confinedTime;
    float timer;

    protected SpriteRenderer sr;
    protected Rigidbody2D rb;
    Vector3 targetP;
    protected virtual void Awake()
    {
        mstate = MonsterState.Move;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        confinedTime = 5f;
        SetNewTarget();
    }

    void Update()
    {
        switch (mstate)
        {
            case MonsterState.Move:
                Move(); 
                break;

            case MonsterState.Confined:
                timer += Time.deltaTime;
                BubbleRelease();
                break;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Buble"))
        {
            BubbleConfined();
            return;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(mstate == MonsterState.Confined)
            {
                MonDie();
            }
            else if(mstate == MonsterState.Move)
            {
                return;
            }

        }
    }

    protected virtual void SpriteDirection(float direction)
    {
        if (direction < 0)
        {
            sr.flipX = true;
        }
        else if (direction > 0)
        {
            sr.flipX = false;
        }
    }

    protected virtual void SetNewTarget() 
    {
        randomX = Random.Range(-9f, 9f);
        targetP = new Vector3(randomX, transform.position.y, 0);
    }

    protected virtual void Move()
    {
        if(mstate != MonsterState.Move)
        {
            return;
        }
        float direction = targetP.x - transform.position.x;

        SpriteDirection(direction);

        rb.linearVelocity = new Vector2(Mathf.Sign(direction) * GameManager.monSpeed, rb.linearVelocity.y);
        if(Mathf.Abs(direction) < 0.1f)
        {
            SetNewTarget();
        }
    }

    public void BubbleConfined()
    {
        mstate = MonsterState.Confined;
        Debug.Log("구속");
        timer = 0;
        //구속상태 애니메이션 추가 
    }

    public void BubbleRelease()
    {
        if(confinedTime <= timer)
        {
            mstate = MonsterState.Move;

            SetNewTarget();
            Move();
        }
    }

    public void MonDie()
    {
        mstate = MonsterState.Die;
        if(UIManager.instance != null)
        {
            UIManager.instance.GetScore(1000);
        }
        currentMonCount--;
        Debug.Log($"현 몬스 {currentMonCount}");
        gameObject.SetActive(false);

        if(currentMonCount <= 0)
        {
            Debug.Log("호출");
            GameManager.instance.CheckClear();
        }
    }

}
