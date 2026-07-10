using UnityEngine;
using UnityEngine.SceneManagement;

public class ChageBtn : MonoBehaviour
{
    public void ScnenChange()
    {
        UIManager.instance.GameOverPopClose();
        SceneManager.LoadScene("");//여기에 메인 씬 이름 넣기 + 씬추가 하기 
    }

    public void StageRe()
    {
        StageManager.instance.ReStage();
    }
}
