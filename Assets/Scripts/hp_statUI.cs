using UnityEngine;
using UnityEngine.UI;

public class hp_statUI : MonoBehaviour
{
    public Slider hpSlider;
    public Image hpBarImage;

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

        hpBarImage.rectTransform.sizeDelta = new Vector2(hpSlider.value * hpBarImage.rectTransform.sizeDelta.x, hpBarImage.rectTransform.sizeDelta.y);
    }

}
