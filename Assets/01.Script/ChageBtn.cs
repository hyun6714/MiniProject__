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



//확인해야 하는 것들
//1. 포탈 작동하나
//2. 스테이지 넘어가서 몬스터스폰&몬스터이동,스테이지,배경,아이템스폰,클리어판정,실패시 플레이중 인 스테이지 인가,포탈생성,이벤트발생하는 것들, 시간이 제대로 흐르나, 등등
//3. 보스몬스터 공격 패턴 생성 

//만들어야 하는 것들
//플레이어 애니매이션 제작및 적용
//몬스터들 버블 맞을 때 구속모션 넣기
//배경사운드 적용

//시간 남으면 할 것들
//UI들 꾸미기 (타이머에 초 넣기)