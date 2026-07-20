using UnityEngine;
using UnityEngine.SceneManagement;

public class ChageBtn : MonoBehaviour
{
    public void ScnenChange()
    {
        UIManager.instance.GameOverPopClose();
        SceneManager.LoadScene("MainScene");
    }

    public void ScnenGame() //다시 메인 넘어가고 다시 시작할시 안되는 버그 
    {
        SceneManager.LoadScene("GameScene");
        UIManager.instance.StageFClose();
        Time.timeScale = 1;
        GameManager.instance.ResetHeart();
        //로비 같은 곳 만들기?
    }

    public void StageRe()
    {
        StageManager.instance.ReStage();
    }
}


//목숨 다끝나고 메인 넘어갈 때 다시 시작이 안되는 버그 //이건 물어보는게 제일 좋을 듯 
//팝업들 프리팹으로 만들고 직접호출하기



//1. 보스몬스터 공격 패턴 생성 
//2. 토탈 스코어 두배로 적용되는 버그 + 스테이지 넘어갈 때 아이템 비활성화 및 현재 점수 초기화 

//만들어야 하는 것들
//플레이어 애니매이션 제작및 적용 //이거 하는중 + 기초틀은 잡음 & 일반 몬스터 구속상태 애니매이션 만들기
//배경사운드 적용

//시간 남으면 할 것들
//UI들 꾸미기 (타이머에 초 넣기)