using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetConnSystem : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick_CreateRoom(string room_guid)
    {
        PhotonNetwork.CreateRoom(room_guid);
    }

    //public override void OnRoomListUpdate(List<RoomInfo> roomList)
    //{
    //    //base.OnRoomListUpdate(roomList);

    //}
}
