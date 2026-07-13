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
    // 만들어야 하는거 몬스터 랜덤위치 스폰(5마리 정도)(스포너 오브젝트 따로 만들고 프리팹등록)
    // 만약 닿은 물체가 플레이어 라면 게임펄 상태로 돌리기
    // 죽었을 때 점수 증가 
    // 상태 변환 (공격 맞았을 시 정지 상태 및 공격안에 갇히기)

    void Start()
    {
        mstate = MonsterState.Move;
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

    void BubleConfined()
    {
        mstate = MonsterState.Confined;
        //구속상태 애니메이션 추가 
    }

    void MonDie()
    {
        mstate = MonsterState.Die;
        gameObject.SetActive(false);
        //보석 떨구기 
    }

}
