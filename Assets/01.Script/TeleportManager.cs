using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public TeleporPo[] teleportList;

    public void TeleporObject(int currenHoleID, GameObject obj)
    {
        foreach(var pair in teleportList)
        {
            if(pair.holeID == currenHoleID)
            {
                obj.transform.position = pair.exitP.position;
                return;
            }
        }
    }
}

//유니티에 배치 필요 