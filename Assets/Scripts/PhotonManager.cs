using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Text.RegularExpressions; 


public class PhotonManager : MonoBehaviourPunCallbacks
{
    public Text connectionStatus;
    public Text idText;
    public Button GoBtn;

    private void Start()
    {
        GoBtn.interactable = false;
    }
    public void LoginBtnClick()
    {
        PhotonNetwork.ConnectUsingSettings();
        connectionStatus.text = "������ ���� ���� ��..";
    }

    public void Connect()
    {
        
            PhotonNetwork.LocalPlayer.NickName = idText.text;
            GoBtn.interactable = false;

            if (PhotonNetwork.IsConnected)
            {
                connectionStatus.text = "�� ���� ��..";
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                connectionStatus.text = "(��������) ���� ����\n��õ� ��..";
                PhotonNetwork.ConnectUsingSettings();
            }
        
    }

    public override void OnConnectedToMaster()
    {
        GoBtn.interactable = true;
        connectionStatus.text = "(�¶���) ������ ������ �����";
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        GoBtn.interactable = false;
        connectionStatus.text = "(��������) ���� ����\n��õ� ��..";
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionStatus.text = "�� �� ���� ��..";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });
        // MaxPlayers�� 0���� �ϸ� ���Ѿ���
    }

    public override void OnJoinedRoom()
    {
        connectionStatus.text = "���� ����";
        PhotonNetwork.LoadLevel("MiniGame");
    }
}