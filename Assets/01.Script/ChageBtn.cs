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
        Time.timeScale = 1;
        GameManager.instance.ResetHeart();
    }

    public void StageRe()
    {
        StageManager.instance.ReStage();
    }
}

//1. 보스몬스터 공격 패턴 생성 
//2. 토탈 스코어 두배로 적용되는 버그(완료) + 스테이지 넘어갈 때 아이템 비활성화 및 현재 점수 초기화 

//만들어야 하는 것들
//플레이어 애니매이션 제작및 적용 //이거 하는중 + 기초틀은 잡음 & 일반 몬스터 구속상태 애니매이션 만들기
//배경사운드 적용

//시간 남으면 할 것들
//UI들 꾸미기 (타이머에 초 넣기)

//싱글톤 자체를 사용하는 목적은 씬자체가 바뀔 때 사용을 하는 목적도 있는데
//내가 사용하는건 어차피 메인이랑 게임씬 1 1 밖에 없으니 이용할 이유가 없고
//내가 만약에 스테이지를 나누어서 씬을 만들었다면 그러면 사용을 할 이유가 생기면 
//디스트로이를 사용을 하면된다