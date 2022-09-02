using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
public class NetWorkManager : MonoBehaviourPunCallbacks
{
    public Text StateText;
    public InputField roomInput, NickNmaeInput;

    void Awake() => Screen.SetResolution(960, 540, false);

    void Update() => StateText.text = PhotonNetwork.NetworkClientState.ToString();

    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster()
    {
        print("서버 접속 완료");
        PhotonNetwork.LocalPlayer.NickName = NickNmaeInput.text;
    }



    public void Disconnect() => PhotonNetwork.Disconnect();

    public override void OnDisconnected(DisconnectCause cause) => print("연결끊김");



    public void JoinLobby() => PhotonNetwork.JoinLobby();

    public override void OnJoinedLobby() => print("로비접속완료");



    public void CreateRoom() => PhotonNetwork.CreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 2 });
    public void JoinRoom() => PhotonNetwork.JoinRoom(roomInput.text);
    public void JoinOrCreateRoom() => PhotonNetwork.JoinOrCreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 2 }, null);
    public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();
    public void LeaveRoom() => PhotonNetwork.LeaveRoom();
    public override void OnCreatedRoom() => print("방만들기 완료");
    public override void OnJoinedRoom() => print("방참가 완료");
    public override void OnCreateRoomFailed(short returnCode, string message) => print("방만들기 실패");
    public override void OnJoinRoomFailed(short returnCode, string message) => print("방참가 실패");
    public override void OnJoinRandomFailed(short returnCode, string message) => print("방랜덤 참가 실패");
}
