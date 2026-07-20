using UnityEngine;
using UnityEngine.SceneManagement;

public class ChageBtn : MonoBehaviour
{
    public void ScnenChange()
    {
        UIManager.instance.GameOverPopClose();
        SceneManager.LoadScene("MainScene");
    }

    public void ScnenGame()
    {
        SceneManager.LoadScene("GameScene");
        UIManager.instance.StageFClose();
        Time.timeScale = 1;
        GameManager.instance.ResetHeart();
    }

    public void StageRe()
    {
        StageManager.instance.ReStage();
    }
}


//목숨 다끝나고 메인 넘어갈 때 다시 시작이 안되는 버그 //이거는 어웨이크쪽 문제 고치기



//1. 보스몬스터 공격 패턴 생성 
//2. 토탈 스코어 두배로 적용되는 버그(완료) + 스테이지 넘어갈 때 아이템 비활성화 및 현재 점수 초기화 

//만들어야 하는 것들
//플레이어 애니매이션 제작및 적용 //이거 하는중 + 기초틀은 잡음 & 일반 몬스터 구속상태 애니매이션 만들기
//배경사운드 적용

//시간 남으면 할 것들
//UI들 꾸미기 (타이머에 초 넣기)