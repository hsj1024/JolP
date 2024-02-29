using UnityEngine;

public class togglemanager : MonoBehaviour
{
    public GameObject firstPanel; // ù ��° �г��� ����
    public GameObject secondPanel; // �� ��° �г��� ����
    public GameObject ThirdPanel; // ����° - > skin �г� �߰�

    // ������ ������ �� ù ��° �г��� Ȱ��ȭ�ϰ� �� ��° �г��� ��Ȱ��ȭ�մϴ�.
    void Start()
    {
        firstPanel.SetActive(true);
        secondPanel.SetActive(false);
        ThirdPanel.SetActive(false);
    }

    // ù ��° �г��� ��ư�� �Ҵ��� �޼���
    public void ShowSecondPanel()
    {
        firstPanel.SetActive(false);
        secondPanel.SetActive(true);
        ThirdPanel.SetActive(false);
    }

    // �� ��° �г��� ��ư�� �Ҵ��� �޼���
    public void ShowFirstPanel()
    {
        firstPanel.SetActive(true);
        secondPanel.SetActive(false);
        ThirdPanel.SetActive(false) ;
    }

    public void ShowThridPanel()
    {
        firstPanel.SetActive(false);
        secondPanel.SetActive(false);
        ThirdPanel.SetActive(true);
        
    }
}
