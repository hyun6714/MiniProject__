using UnityEngine;

[System.Serializable]
public struct TeleporPo
{
    public Transform exitP;//위
    public int holeID;//아래
}

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

//+ 스테이지마다 끄고 키기