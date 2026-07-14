using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour //게임시작시 플레이어 위치 정하기 
{
    Vector2 dir;

    float moveSpeed;
    float jumpPower;
    int jumpCount;
    int jumpMax;

    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask pground;
    [SerializeField] LayerMask monster;
    [SerializeField] LayerMask buble;


    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveSpeed = 3f;

        jumpPower = 5f;
        jumpCount = 0;
        jumpMax = 1;
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        dir = Vector2.zero;

        if(Keyboard.current.aKey.isPressed)
        {
            dir += Vector2.left;
        }
        if(Keyboard.current.dKey.isPressed)
        { 
            dir += Vector2.right;
        }
        rb.linearVelocity = new Vector2(dir.x * moveSpeed, rb.linearVelocity.y);

        bool isGrounded = Physics2D.CircleCast(transform.position, 0.3f, Vector2.down, 0.5f, ground | pground | buble);

        if (isGrounded && rb.linearVelocity.y <=0)
        {
            JumpReset();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            Monster monster = collision.gameObject.GetComponent<Monster>();
            if(monster != null)
            {
                if(monster.mstate != MonsterState.Confined)
                {
                    Die();
                }
            }
        }

    }

    void Jump()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (jumpCount == 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
                jumpCount = 1;
            }
        }
    }

    void JumpReset()
    {
        jumpCount = 0;
    }

    void Die()
    {
        GameManager.instance.StageFail();
    }
}




//이제 몬스터&플레이어가 구멍에 빠질 때 다른 맵위쪽 구멍에 텔포
//단 방법 1. 하나씩 텔포위치를 만들고 거기로 이동하게 하기 or 2.위치를 배열에 저장을 하고 만약 몇번배열 위치에서 떨어졌을 때 어떤 위치로 텔포하기
//배열에 저장할 떄 나 하나씩 만들 땐 위 아래 구분