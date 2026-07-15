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
        //로비 같은 곳 만들기?
    }

    public void StageRe()
    {
        StageManager.instance.ReStage();
    }
}


//1.버블이 땅 통과 고치기 
//2. 시간 지나면 몬스터속도증가 만들기 // 이건 완성 함 근데 확인 안함 
//3. 보스몬스터 관련 구현
//4. 텔레포트 하는거 스테이지마다 끄고 키기 만들기 
//5. 목숨 다끝나고 메인 넘어갈 때 다시 시작이 안되는 버그 (아마 목숨초기화 문제 일것같음)
//6. 스테이지 실패시 그 스테이지에서 얻은 점수 초기화 
