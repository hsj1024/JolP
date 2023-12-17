using UnityEngine;
using UnityEngine.UI;

public class hp_statUI : MonoBehaviour
{
    public Slider hpSlider;

    void Start()
    {
        // ���� �ʱ�ȭ
        EggMonStat.InitializeStat();

        // �����̴� �ִ밪 ����
        hpSlider.maxValue = 1; // �����̴��� ���� 0�� 1 ���̷�, ������ ǥ���˴ϴ�.
    }

    void Update()
    {
        UpdateUI();
    }
    private void UpdateUI()
    {
        float healthRatio = EggMonStat.health / EggMonStat.maxHealth;
        hpSlider.value = healthRatio;

        // ����� �α� �߰�
        Debug.Log("Health: " + EggMonStat.health + " / Max Health: " + EggMonStat.maxHealth + " - Ratio: " + healthRatio);
    }

    /*private void UpdateUI()
    {
        // EggMonStat Ŭ������ health ���� maxHealth�� ������ �����̴��� ���� ������Ʈ�մϴ�.
        hpSlider.value = EggMonStat.health / EggMonStat.maxHealth;
    }*/
}
