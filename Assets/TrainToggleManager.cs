using UnityEngine;

public class TrainToggleManager : MonoBehaviour
{
    public GameObject firstPanel;
    public GameObject secondPanel;
    public GameObject thirdPanel;
    public GameObject fourthPanel;

    public GameObject trainMenuPanel;

    private Animator firstPanelAnimator;
    private Animator secondPanelAnimator;
    private Animator thirdPanelAnimator;
    private Animator fourthPanelAnimator;

    void Start()
    {
        firstPanel.SetActive(true);
        secondPanel.SetActive(false);
        thirdPanel.SetActive(false);
        fourthPanel.SetActive(false);

        // �гο� ����� Animator ������Ʈ ��������
        firstPanelAnimator = firstPanel.GetComponent<Animator>();
        secondPanelAnimator = secondPanel.GetComponent<Animator>();
        thirdPanelAnimator = thirdPanel.GetComponent<Animator>();
        fourthPanelAnimator = fourthPanel.GetComponent<Animator>();
    }

    public void ShowFirstPanel()
    {
        firstPanel.SetActive(true);
        secondPanel.SetActive(false);
        thirdPanel.SetActive(false);
        fourthPanel.SetActive(false);

        // ù ��° �г��� �ִϸ��̼� ���
        firstPanelAnimator.SetTrigger("Show");
    }

    public void ShowSecondPanel()
    {
        firstPanel.SetActive(false);
        secondPanel.SetActive(true);
        thirdPanel.SetActive(false);
        fourthPanel.SetActive(false);

        // �� ��° �г��� �ִϸ��̼� ���
        secondPanelAnimator.SetTrigger("Show");
    }

    public void ShowThirdPanel()
    {
        firstPanel.SetActive(false);
        secondPanel.SetActive(false);
        thirdPanel.SetActive(true);
        fourthPanel.SetActive(false);

        // �� ��° �г��� �ִϸ��̼� ���
        thirdPanelAnimator.SetTrigger("Show");
    }

    public void ShowFourthPanel()
    {
        firstPanel.SetActive(false);
        secondPanel.SetActive(false);
        thirdPanel.SetActive(false);
        fourthPanel.SetActive(true);

        // �� ��° �г��� �ִϸ��̼� ���
        fourthPanelAnimator.SetTrigger("Show");
    }

    public void ShowExitPanel()
    {
        firstPanel.SetActive(false);
        trainMenuPanel.SetActive(true);
    }
}
