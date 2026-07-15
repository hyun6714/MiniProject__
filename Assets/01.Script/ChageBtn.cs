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


//1.버블이 땅 통과 고치기or 벽에 닿을 시 비활성화 하기 

//3. 보스몬스터 관련 구현

//4. 플레이어 및 몬스터 왼쪽이동시 왼쪽보기 + 자꾸 땅에 끼는거 방지 해보기  // 완료 

//5. 목숨 다끝나고 메인 넘어갈 때 다시 시작이 안되는 버그 //이건 물어보는게 제일 좋을 듯 
//팝업들 프리팹으로 만들고 직접호출하기 

//6. 타이머 시간 넘어가면 Hurrup 팝업 만들기 //만듬 근데 확인 할 필요 

//8. 포탈 확인해야 함 

//유니티 세팅중

//여태까지 고친거 
//1. 맵밖으로 나가는 거 방지
//2. 스테이지 실패시 아이템들 비활성화 
//3. Hurryup 이벤트 및 팝업 구현
//4. 스테이지 관련 팝업 구현 및 확인 
