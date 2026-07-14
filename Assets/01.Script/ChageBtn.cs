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
        //로비 같은 곳 만들기?
    }

    public void StageRe()
    {
        StageManager.instance.ReStage();
    }
}
