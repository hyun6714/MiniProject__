using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum MonsterState
{
    Confined, Move , Die
}

public class Monster : MonoBehaviour
{

    public MonsterState mstate;

    float score;
    float speed;
    float randomX;
    float randomY;

    float confinedTime;
    float timer;

    Vector3 targetP;

    void Start()
    {
        mstate = MonsterState.Move;
        speed = 3f;

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
        if(collision.gameObject.layer == LayerMask.NameToLayer("Buble"))
        {
            BubbleConfined();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(mstate == MonsterState.Confined )
            {
                MonDie();
            }
        }
    }

    void SetNewTarget() 
    {
        randomX = Random.Range(-9f, 9f);
        targetP = new Vector3(randomX, transform.position.y, 0);
    }

    void Move()
    {
        mstate = MonsterState.Move;
        transform.position = Vector3.MoveTowards(transform.position, targetP, speed*Time.deltaTime);
        speed = 3f;
        if(Mathf.Abs(transform.position.x-targetP.x) < 0.5f)
        {
            SetNewTarget();
        }
    }

    void BubbleConfined()
    {
        mstate = MonsterState.Confined;
        speed = 0;
        timer = 0;
        //구속상태 애니메이션 추가 
    }

    void BubbleRelease()
    {
        if(confinedTime <= timer)
        {
            mstate = MonsterState.Move;

            SetNewTarget();
            Move();
        }
    }

    void MonDie()
    {
        mstate = MonsterState.Die;
        if(UIManager.instance != null)
        {
            UIManager.instance.GetScore(1000);
        }
        gameObject.SetActive(false);
        GameManager.instance.CheckClear();
    }

}
