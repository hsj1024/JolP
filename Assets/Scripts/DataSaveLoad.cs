using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaveLoad : MonoBehaviour
{
    public string playerIcon;
    public string playerName;

    // �����͸� �����ϴ� �Լ�
    public void SavePlayerData()
    {
        PlayerPrefs.SetString("PlayerIcon", playerIcon);
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
        Debug.Log("�����Ͱ� ����Ǿ����ϴ�.");
    }

    // �����͸� �ҷ����� �Լ�
    public void LoadPlayerData()
    {
        playerIcon = PlayerPrefs.GetString("PlayerIcon");
        playerName = PlayerPrefs.GetString("PlayerName");
        Debug.Log($"{playerName}�� �������� {playerIcon}�Դϴ�.");
    }
}
