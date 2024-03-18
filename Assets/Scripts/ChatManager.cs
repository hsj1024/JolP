using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class ChatManager : MonoBehaviourPunCallbacks
{
    public Button sendBtn; //ä�� �Է¹�ư
    public Text[] Players;
    public Text[] Chats;
    public int[] GuessNum;
    public GameObject[] playerFrame;
    public InputField inputField; //ä���Է� ��ǲ�ʵ�
    public Button GameStartBtn;
    public Text GuideText, BoardText;

    private int RandNum;
    private bool isGameStart = false;

    void Start()
    {
        int i = 0;
        PhotonNetwork.IsMessageQueueRunning = true;
        foreach(GameObject player in playerFrame)
        {
            player.SetActive(false);
        }
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            Debug.Log(PhotonNetwork.PlayerList.Length);
            playerFrame[i].SetActive(true);
            i += 1;
        }

        if (PhotonNetwork.IsMasterClient)
        {
            GameStartBtn.gameObject.SetActive(true);
        }
        else
        {
            GameStartBtn.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        ChatterUpdate();
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && !inputField.isFocused) SendButtonOnClicked();
    }

    public void SendButtonOnClicked()
    {
        if (inputField.text.Equals(""))
        {
            Debug.Log("Empty");
            return;
        }
        string msg = string.Format("{0}", inputField.text);
        photonView.RPC("ReceiveMsg", RpcTarget.OthersBuffered, PhotonNetwork.LocalPlayer.NickName, msg);
        ReceiveMsg(PhotonNetwork.LocalPlayer.NickName, msg);
        inputField.ActivateInputField(); // �޼��� ���� �� �ٷ� �޼����� �Է��� �� �ְ� ��Ŀ���� Input Field�� �ű�� ���� ���
        inputField.text = "";
    }

    void ChatterUpdate()
    {
        int i = 0;
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            Players[i].text = p.NickName;
            i += 1;
        }
    }

    public void GameStart()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("GameStartClick", RpcTarget.AllBuffered);
        }
        else
        {
            Debug.Log("������ Ŭ���̾�Ʈ�� �ƴ�");
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PlayerEnter();
        string msg = string.Format("�ȳ�!");
        ReceiveMsg(newPlayer.NickName, msg);
        
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        playerFrame[PhotonNetwork.PlayerList.Length - 1].SetActive(false);
    }

    [PunRPC]
    public void PlayerEnter()
    {
        playerFrame[PhotonNetwork.PlayerList.Length-1].SetActive(true);
    }

    [PunRPC]
    public void ReceiveMsg(string name, string msg)
    {
        if (!isGameStart)
        {
            int i = 0;
            foreach (Player p in PhotonNetwork.PlayerList)
            {
                if (name == Players[i].text)
                {
                    Chats[i].text = msg;
                }
                i += 1;
            }
        }
        else
        {
            int i = 0;
            foreach (Player p in PhotonNetwork.PlayerList)
            {
                if (name == Players[i].text)
                {
                    if(GuessNum[i] < 0 || GuessNum[i] > 100)
                    {
                        Chats[i].text = "�߸��� �Է�!";
                    }
                    else
                    {
                        Chats[i].text = GuessNum[i].ToString();
                    }
                }
                i += 1;
            }
        }
        
        
    }

    [PunRPC]
    public void GameStartClick()
    {
        StartCoroutine(ChangeTextCoroutine());
        GameStartBtn.gameObject.SetActive(false);
    }

    [PunRPC]
    public void UpdateGuideText(string msg)
    {
        GuideText.text = msg;
    }
    [PunRPC]
    public void UpdateBoardText(string msg)
    {
        BoardText.text = msg;
    }

    IEnumerator ChangeTextCoroutine()
    {
        string tmp1 = "�� ������ ���۵˴ϴ�..";
        photonView.RPC("UpdateGuideText", RpcTarget.OthersBuffered, tmp1);

        string tmp2 = "Ready?";
        photonView.RPC("UpdateBoardText", RpcTarget.OthersBuffered, tmp2);
        yield return new WaitForSeconds(4f);
        tmp1 = "���� �����ϴ� ���ڸ� �����ּ���";
        photonView.RPC("UpdateGuideText", RpcTarget.OthersBuffered, tmp1);
        yield return new WaitForSeconds(4f);
        tmp1 = "1���� 100 ������ ���ڸ� �����غ��Կ�";
        photonView.RPC("UpdateGuideText", RpcTarget.OthersBuffered, tmp1);

        RandNum = Random.Range(1, 100);

        yield return new WaitForSeconds(4f);
        tmp1 = "���� ������ ���ڴ� �����ϱ��?";
        photonView.RPC("UpdateGuideText", RpcTarget.OthersBuffered, tmp1);
        yield return new WaitForSeconds(1f);
        tmp2 = "3";
        photonView.RPC("UpdateBoardText", RpcTarget.OthersBuffered, tmp2);
        yield return new WaitForSeconds(1f);
        tmp2 = "2";
        photonView.RPC("UpdateBoardText", RpcTarget.OthersBuffered, tmp2);
        yield return new WaitForSeconds(1f);
        tmp2 = "1";
        photonView.RPC("UpdateBoardText", RpcTarget.OthersBuffered, tmp2);
        yield return new WaitForSeconds(1f);
        tmp2 = "0!";
        photonView.RPC("UpdateBoardText", RpcTarget.OthersBuffered, tmp2);

        isGameStart = true;
        
        int i = 0;
        int number;
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            if (int.TryParse(Chats[i].text, out number))
            {
                Debug.Log($"{Players[i].text}�� ������ ���ڴ� {number}");
                GuessNum[i] = number;
            }
            else
            {
                GuessNum[i] = -999;
            }
            
        }
        yield return new WaitForSeconds(1f);
        tmp1 = "���� ������ ���ڴ�...";
        photonView.RPC("UpdateGuideText", RpcTarget.OthersBuffered, tmp1);

        int whoisWinner = 0;
        int min = 999;
        i = 0;
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            if(min > Mathf.Abs(GuessNum[i] - RandNum))
            {
                min = Mathf.Abs(GuessNum[i] - RandNum);
                whoisWinner = i;
            }
            i += 1;
        }
        yield return new WaitForSeconds(2f);
        tmp2 = RandNum.ToString();
        photonView.RPC("UpdateBoardText", RpcTarget.OthersBuffered, tmp2);
        tmp1 = $"���� ������ ���ڴ� {RandNum}�Դϴ�!";
        photonView.RPC("UpdateGuideText", RpcTarget.OthersBuffered, tmp1);
        yield return new WaitForSeconds(2f);

        tmp1 = $"����ڴ� {Players[whoisWinner].text} �Դϴ�!";
        photonView.RPC("UpdateGuideText", RpcTarget.OthersBuffered, tmp1);
        yield return new WaitForSeconds(5f);
        PhotonNetwork.LoadLevel("Merge");
    }

}