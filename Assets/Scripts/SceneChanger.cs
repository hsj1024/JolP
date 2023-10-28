using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public Button RetryButton; // ���⿡ ��ȯ ��ư�� �Ҵ��ϼ���.
    public string ingame; // ���⿡ �ε��� ���� �̸��� �Է��ϼ���.

    void Start()
    {
        RetryButton.onClick.AddListener(ChangeScene);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(ingame);
    }
}
