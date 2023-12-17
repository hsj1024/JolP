using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// �� ��ȯ�� ����ϴ� Ŭ����
public class SceneChanger : MonoBehaviour
{
    public Button RetryButton; // ��ȯ ��ư�� �Ҵ��� UI ��ư
    public string ingame; // �ε��� ���� �̸�

    // ���� �� ȣ��Ǵ� �Լ�
    void Start()
    {
        // ��ȯ ��ư�� Ŭ�� ������ �߰�
        RetryButton.onClick.AddListener(ChangeScene);
    }

    // ���� ��ȯ�ϴ� �Լ�
    void ChangeScene()
    {
        // ������ ������ ��ȯ
        SceneManager.LoadScene(ingame);
    }
}
