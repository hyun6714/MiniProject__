using UnityEngine;

public enum MonsterState
{
    Confined, Move , Die
}

public class Monster : MonoBehaviour
{

    public MonsterState mstate;

    float randomX;
    public static int currentMonCount = 5;

    float confinedTime;
    float timer;

    bool isConfined;
    Animator mAnim;

    protected float dir;
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
        mAnim = GetComponent<Animator>();
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bubble"))
        {
            Debug.Log("버블 충돌함");
            BubbleConfined();
            return;
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
        targetP = new Vector3(randomX, transform.position.y+0.5f, 0);
    }

    protected virtual void Move()
    {
        if(mstate != MonsterState.Move)
        {
            return;
        }

        dir = targetP.x - transform.position.x;

        SpriteDirection(dir);

        rb.linearVelocity = new Vector2(Mathf.Sign(dir) * GameManager.monSpeed, rb.linearVelocity.y);
        if(Mathf.Abs(dir) < 0.1f)
        {
            SetNewTarget();
        }
    }

    public void BubbleConfined()
    {
        mstate = MonsterState.Confined;
        Debug.Log("구속");
        isConfined = true;
        if (mAnim != null)
        {
            mAnim.SetBool("IsConfined", isConfined);
        }
        rb.linearVelocity = Vector2.zero;
        timer = 0;
    }

    public void BubbleRelease()
    {
        if(confinedTime <= timer)
        {
            mstate = MonsterState.Move;
            isConfined = false;
            if(mAnim != null)
            {
                mAnim.SetBool("IsConfined",isConfined);
            }

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
