using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// �� ��ȯ�� ����ϴ� Ŭ����
public class SceneChanger : MonoBehaviour
{

    // ���� ��ȯ�ϴ� �Լ�
    public void ChangeSceneToOnline()
    {
        // ������ ������ ��ȯ
        SceneManager.LoadScene("Multi");
    }

    public void ChangeSceneToMiniGame()
    {
        // ������ ������ ��ȯ
        SceneManager.LoadScene("MiniGame");
    }
}
