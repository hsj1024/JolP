using UnityEngine;
using UnityEngine.UI;

public static class online_play 
{
    public static string playerIcon;
    public static string playerName;

    // �����͸� �����ϴ� �Լ�
    public static void SavePlayerData()
    {
        if(string.IsNullOrEmpty(playerIcon) || string.IsNullOrEmpty(playerName))
        {
            Debug.Log("�÷��̾� ������ �Ǵ� �÷��̾� �̸��� ����ֽ��ϴ�.");
        }
        else
        {
            PlayerPrefs.SetString("PlayerIcon", playerIcon);
            PlayerPrefs.SetString("PlayerName", playerName);
            PlayerPrefs.Save();
            Debug.Log("�����Ͱ� ����Ǿ����ϴ�.");
        }
    }

    // �����͸� �ҷ����� �Լ�
    public static void LoadPlayerData()
    {
        playerIcon = PlayerPrefs.GetString("PlayerIcon", "egg");
        playerName = PlayerPrefs.GetString("PlayerName", "Player");
        Debug.Log($"{playerName}�� ������ ������ �̸��� {playerIcon}�Դϴ�..");
    }
}
