using UnityEngine;
using UnityEngine.UI;

// EggMon�� ü�� ������ UI�� ǥ���ϴ� ��ũ��Ʈ
public class hp_statUI : MonoBehaviour
{
    // ü���� ��Ÿ���� �����̴��� �̹���
    public Slider hpSlider;
    public Image hpBarImage;

    // ���� �� ȣ��Ǵ� �Լ�
    void Start()
    {
        // ���� �ʱ�ȭ
        EggMonStat.InitializeStat();

        // �����̴� �ִ밪 ����
        hpSlider.maxValue = 1; // �����̴��� ���� 0�� 1 ���̷�, ������ ǥ���˴ϴ�.
    }

    // �����Ӹ��� ȣ��Ǵ� �Լ�
    void Update()
    {
        // UI ������Ʈ �Լ� ȣ��
        UpdateUI();
    }

    // UI�� ������Ʈ�ϴ� �Լ�
    private void UpdateUI()
    {
        // ü�� ���� ���
        float healthRatio = EggMonStat.health / EggMonStat.maxHealth;

        // �����̴� �� ����
        hpSlider.value = healthRatio;

        // ����� �α� �߰�
        Debug.Log("Health: " + EggMonStat.health + " / Max Health: " + EggMonStat.maxHealth + " - Ratio: " + healthRatio);

        // HP �� �̹��� ũ�� ����
        hpBarImage.rectTransform.sizeDelta = new Vector2(hpSlider.value * hpBarImage.rectTransform.sizeDelta.x, hpBarImage.rectTransform.sizeDelta.y);
    }
}
