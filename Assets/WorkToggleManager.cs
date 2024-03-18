using UnityEngine;
using System.Collections; // Coroutine�� ����ϱ� ���� �ʿ�
using UnityEngine.UI; // UI ���� ����� ����ϱ� ���� �ʿ�



public class WorkToggleManager : MonoBehaviour
{
    public GameObject firstPanel;
    public GameObject secondPanel;
    public GameObject thirdPanel;
    public GameObject fourthPanel;

    public GameObject workMenuPanel;
    public Tamagotchi tamagotchi;


    // �� �гο� �����Ǵ� ������ �̹���
    public GameObject rewardImage1;
    public GameObject rewardImage2;
    public GameObject rewardImage3;
    public GameObject rewardImage4;


    public Text rewardText; // ���� �ؽ�Ʈ�� ���� ����


    void Start()
    {
        firstPanel.SetActive(false);
        secondPanel.SetActive(false);
        thirdPanel.SetActive(false);
        fourthPanel.SetActive(false);

        // ��� ������ �̹����� �ʱ⿡ ��Ȱ��ȭ
        rewardImage1.SetActive(false);
        rewardImage2.SetActive(false);
        rewardImage3.SetActive(false);
        rewardImage4.SetActive(false);
    }

    public void ShowFirstPanel()
    {
        ActivatePanel(firstPanel, rewardImage1, "���ܸ� ��ġ�� 200������ �޾ҽ��ϴ�!", 200, 3f);

        MoneyManager.AddMoney(200); // ù ��° �г�(�����ϱ�) Ȱ��ȭ �� 200 �߰�

        EggMonStat.DecreaseStat("full", 40f);

        if (EggMonStat.full <= 0) // full�� ������� ����
        {
            tamagotchi.DecreaseHP(); // ������� 0 �����̸� HP ����
        }


        Debug.Log("�� : 200���� ȹ��");

    }

    public void ShowSecondPanel()
    {
        ActivatePanel(secondPanel, rewardImage2, "��� ���� Ȱ���Ͽ� 400������ �޾ҽ��ϴ�!", 400, 3f);

        MoneyManager.AddMoney(200); // �� ��° �г�(����� �ϱ�) Ȱ��ȭ �� 400 �߰�

        EggMonStat.DecreaseStat("full", 40f);

        if (EggMonStat.full <= 0) // full�� ������� ����
        {
            tamagotchi.DecreaseHP(); // ������� 0 �����̸� HP ����
        }


        Debug.Log("�� : 400���� ȹ��");
    }

    public void ShowThirdPanel()
    {
        ActivatePanel(thirdPanel, rewardImage3, "ī�� ���� ��ġ�� 200������ �޾ҽ��ϴ�!", 200, 3f);

        MoneyManager.AddMoney(400); // �� ��° �г�(ī��˹�) Ȱ��ȭ �� 400 �߰�
        EggMonStat.DecreaseStat("full", 40f);

        if (EggMonStat.full <= 0) // full�� ������� ����
        {
            tamagotchi.DecreaseHP(); // ������� 0 �����̸� HP ����
        }

    }

    public void ShowFourthPanel()
    {
        ActivatePanel(fourthPanel, rewardImage4, "���ٵ��� �Ϸ��ϰ� 300������ �޾ҽ��ϴ�!", 300, 3f);

        MoneyManager.AddMoney(300); // �� ��° �г�(���ٴ�) Ȱ��ȭ �� 300 �߰�

        EggMonStat.DecreaseStat("full", 40f);

        if (EggMonStat.full <= 0) // full�� ������� ����
        {
            tamagotchi.DecreaseHP(); // ������� 0 �����̸� HP ����
        }


    }
    void ActivatePanel(GameObject panel, GameObject rewardImage, string rewardMessage, int moneyToAdd, float delay)
    {
        // ��� �г� ��Ȱ��ȭ
        firstPanel.SetActive(false);
        secondPanel.SetActive(false);
        thirdPanel.SetActive(false);
        fourthPanel.SetActive(false);

        // ������ �г� Ȱ��ȭ
        panel.SetActive(true);

        // �� �߰�
        MoneyManager.AddMoney(moneyToAdd);

        // EggMonStat�� tamagotchi ���� ������ ���⿡ ���� (����)

        // ���� �ؽ�Ʈ ������Ʈ �� �̹��� Ȱ��ȭ
        UpdateRewardTextAndShowImage(rewardImage, rewardMessage, delay);
    }
    void UpdateRewardTextAndShowImage(GameObject rewardImage, string text, float delay)
    {
        StartCoroutine(ShowRewardImageAfterDelay(rewardImage, text, delay));
    }

    IEnumerator ShowRewardImageAfterDelay(GameObject rewardImage, string text, float delay)
    {
        // ��� ������ �̹��� ��Ȱ��ȭ
        rewardImage1.SetActive(false);
        rewardImage2.SetActive(false);
        rewardImage3.SetActive(false);
        rewardImage4.SetActive(false);

        yield return new WaitForSeconds(delay);

        // ���� �ؽ�Ʈ ������Ʈ
        rewardText.text = text;

        // �ش� ���� �̹��� Ȱ��ȭ
        rewardImage.SetActive(true);
    }


    public void HideRewardImage()
    {
        // ��� ������ �̹��� ��Ȱ��ȭ
        rewardImage1.SetActive(false);
        rewardImage2.SetActive(false);
        rewardImage3.SetActive(false);
        rewardImage4.SetActive(false);
        


}

public void ShowExitPanel()
    {
        firstPanel.SetActive(false);
        secondPanel.SetActive(false);
        thirdPanel.SetActive(false);
        fourthPanel.SetActive(false);
        workMenuPanel.SetActive(true);

        // ��� ������ �̹����� ��Ȱ��ȭ�� �� ���
        HideRewardImage();
    }
}
