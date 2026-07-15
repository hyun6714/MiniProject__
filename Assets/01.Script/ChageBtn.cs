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


//1.버블이 땅 통과 고치기

//2. 시간 지나면 몬스터속도증가 만들기 // 이건 완성 함 근데 확인 필요

//3. 보스몬스터 관련 구현

//5. 목숨 다끝나고 메인 넘어갈 때 다시 시작이 안되는 버그 

//6. 스테이지 실패시 그 스테이지에서 얻은 점수 초기화 현재스테이지 점수 저장 따로 스테이지 클리어시 그점수 따로 저장해서 전체 점수에 저장 
//완료

//4. 플레이어 및 몬스터 왼쪽이동시 왼쪽보기 