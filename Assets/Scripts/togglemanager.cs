using UnityEngine;

public class togglemanager : MonoBehaviour
{
    public GameObject firstPanel;   // Skin shop �г�
    public GameObject secondPanel;  // Food shop �г�
    public GameObject ThirdPanel;   // Play shop �г�

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
    public void ShowFirstPanel()
    {
        firstPanel.SetActive(true);
        secondPanel.SetActive(false);
        ThirdPanel.SetActive(false);
    }

    // �� ��° �г��� ��ư�� �Ҵ��� �޼���

    

    

    public void ShowThridPanel()
    {
        firstPanel.SetActive(false);
        secondPanel.SetActive(false);
        ThirdPanel.SetActive(true);
        
    }
}
