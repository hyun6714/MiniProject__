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

    float confinedTime;
    float timer;

    Vector3 targetP;

    void Start()
    {
        mstate = MonsterState.Move;

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

    void SetNewTarget() 
    {
        randomX = Random.Range(-9f, 9f);
        targetP = new Vector3(randomX, transform.position.y, 0);
    }

    void Move()
    {
        if(mstate != MonsterState.Move)
        {
            return;
        }
        mstate = MonsterState.Move;
        transform.position = Vector3.MoveTowards(transform.position, targetP, GameManager.monSpeed*Time.deltaTime);
        //여기에 추가 
        if(Mathf.Abs(transform.position.x-targetP.x) < 0.5f)
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
            Debug.Log(gameObject.name + "가 MonDie()를 호출함! 호출한 곳: " + System.Environment.StackTrace);
            UIManager.instance.GetScore(1000);
        }
        gameObject.SetActive(false);
        GameManager.instance.CheckClear();
    }


}
