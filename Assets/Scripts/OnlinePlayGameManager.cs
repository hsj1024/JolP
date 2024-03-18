using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlinePlayGameManager : MonoBehaviour
{
    public Text playerName;
    public Image icon;
    public InputField inputField;

    void Update()
    {
        playerName.text = online_play.playerName;
        icon.sprite = Resources.Load<Sprite>(online_play.playerIcon);
    }
    public void RenameNickName()
    {
        string inputText = inputField.text; // �Էµ� �ؽ�Ʈ ��������
        Debug.Log("�Էµ� �ؽ�Ʈ: " + inputText); // �ؽ�Ʈ ����׷� ���
        online_play.playerName = inputText;
    }

    public void GoBtnClicked()
    {
        
    }
}
