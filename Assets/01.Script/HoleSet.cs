using UnityEngine;

public class HoleSet : MonoBehaviour
{
    public int myHoleId;
    public TeleportManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.TeleporObject(myHoleId, collision.gameObject);
    }
}


//총 만들어야하는 것  
//1. 플레이어 위치 정하기 
//2. 아이템 트리거 만들기
//3. 버블 만들기
//4. 보스 만들기
//5. 텔포하는 것 스테이지마다 끄고 키는거 만들기 