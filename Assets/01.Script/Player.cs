using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour //게임시작시 플레이어 위치 정하기 
{
    Vector2 dir;

    float moveSpeed;
    float jumpPower;
    int jumpCount;
    int jumpMax;

    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask pground;
    [SerializeField] private LayerMask monster;
    [SerializeField] private LayerMask buble;


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

    private void OnCollisionEnter2D(Collision2D collision) // 구속상태가 되어도 몬스터가 닿을 시 사망함 
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            Monster monster = collision.gameObject.GetComponent<Monster>();
            if(monster != null)
            {
                Debug.Log($"충돌 상태 {monster.mstate}");
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