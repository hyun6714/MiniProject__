using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 dir;

    float moveSpeed;
    float jumpPower;
    int jumpCount;

    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask pground;
    [SerializeField] private LayerMask monster;
    [SerializeField] private LayerMask bubble;

    Animator anim;

    SpriteRenderer sr;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        moveSpeed = 3f;

        jumpPower = 6.5f;
        jumpCount = 0;
        transform.position += new Vector3(0f, 0.5f, 0f);
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        dir = Vector2.zero;
        bool isGrounded = Physics2D.CircleCast(transform.position, 0.3f, Vector2.down, 0.5f, ground | pground | bubble);

        if (Keyboard.current.aKey.isPressed)
        {
            dir += Vector2.left;
            sr.flipX = true;
        }
        if(Keyboard.current.dKey.isPressed)
        { 
            dir += Vector2.right;
            sr.flipX = false;
        }
        rb.linearVelocity = new Vector2(dir.x * moveSpeed, rb.linearVelocity.y);

        bool isMove = (dir.x != 0 && isGrounded);
        if(anim != null)
        {
            anim.SetBool("IsMove",isMove);
        }

        if (isGrounded && rb.linearVelocity.y <=0)
        {
            JumpReset();

            if(anim != null)
            {
                anim.SetBool("IsJump",false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Monster") || collision.gameObject.layer == LayerMask.NameToLayer("BossMonster"))
        {
            Monster monster = collision.gameObject.GetComponent<Monster>();
            if(monster.mstate == MonsterState.Confined)
            {
                monster.MonDie();
            }
            else if(monster.mstate == MonsterState.Move)
            {
                Die();
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

                if (anim != null)
                {
                    anim.SetBool("IsJump", true);
                }

                transform.position += new Vector3(0f, 0.5f, 0f);
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