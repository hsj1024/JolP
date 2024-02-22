using UnityEngine;

public class togglemanager : MonoBehaviour
{
    public GameObject firstPanel; // ù ��° �г��� ����
    public GameObject secondPanel; // �� ��° �г��� ����

    // ������ ������ �� ù ��° �г��� Ȱ��ȭ�ϰ� �� ��° �г��� ��Ȱ��ȭ�մϴ�.
    void Start()
    {
        firstPanel.SetActive(true);
        secondPanel.SetActive(false);
    }

    // ù ��° �г��� ��ư�� �Ҵ��� �޼���
    public void ShowSecondPanel()
    {
        firstPanel.SetActive(false);
        secondPanel.SetActive(true);
    }

    // �� ��° �г��� ��ư�� �Ҵ��� �޼���
    public void ShowFirstPanel()
    {
        firstPanel.SetActive(true);
        secondPanel.SetActive(false);
    }
}
