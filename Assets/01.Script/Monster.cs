using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

enum MonsterState
{
    Confined, Move , Die
}

public class Monster : MonoBehaviour
{

     MonsterState mstate;

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
                BubleRelease();
                break;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Buble"))
        {
            BubleConfined();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && mstate == MonsterState.Confined)
        {
            MonDie();
        }
    }

    void SetNewTarget() //보완필요 지금 한 곳으로 몰아버림 
    {
        randomX = Random.Range(-9f, 9f);
        randomY = Random.Range(-8.5f, 5f);
        targetP = new Vector3(randomX, randomY, 0);
    }

    void Move()
    {
        mstate = MonsterState.Move;
        transform.position = Vector3.MoveTowards(transform.position, targetP, speed*Time.deltaTime);

        if(Vector3.Distance(transform.position, targetP) < 0.5f)
        {
            SetNewTarget();
        }
    }

    void BubleConfined()
    {
        mstate = MonsterState.Confined;
        timer = 0;
        //구속상태 애니메이션 추가 
    }

    void BubleRelease()
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
    }

}
