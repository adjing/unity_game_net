using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class NetConnSystem : MonoBehaviourPunCallbacks
{

    void Start()
    {
        
    }

    public void OnClick_CreateRoom(string room_guid)
    {
        PhotonNetwork.CreateRoom(room_guid);
    }

    public override void OnJoinedRoom()
    {
        HttpLog.Log("OnJoinedRoom");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        HttpLog.Log("OnPlayerEnteredRoom");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        StringBuilder s = new StringBuilder();
        if(roomList != null)
        {
            s.AppendLine("roomList is null");
            HttpLog.Log(s.ToString());
        }

        if(roomList.Count == 0)
        {
            s.AppendLine("roomList is null");
            HttpLog.Log(s.ToString());
        }

        for(int i = 0; i < roomList.Count; i++)
        {
            var item = roomList[i];
            s.AppendLine(string.Format("room_guid={0}",item.Name));
        }
        
        HttpLog.Log(s.ToString());
    }
}
