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

    public void StageReGame()
    {
        StageManager.instance.ReStage();
    }
}

//남은 것들 몬스터 구속상태 애니메이션 조금 더 다듬기 + 사운드들 더 넣어보기? + UI밋밋한것들 더 꾸며보기 
//보스몬스터 공격 패턴 생성 //이건 고민중 만들까 말까 



//보스몬스터 공격 생각 
//1. 타이머를 두고 시간을 재서 n초마다 총알 같은거 생성후 날아가게 하기 인데 원히트 원데드라 이게 어렵게 해버리면 깰수가 없음 

















//싱글톤 자체를 사용하는 목적은 씬자체가 바뀔 때 사용을 하는 목적도 있는데
//내가 사용하는건 어차피 메인이랑 게임씬 1 1 밖에 없으니 이용할 이유가 없고
//내가 만약에 스테이지를 나누어서 씬을 만들었다면 그러면 사용을 할 이유가 있으니 디스트로이를 사용을 하면된다