using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���׸��� ������ UI�� ǥ���ϴ� Ŭ����
public class StatUI : MonoBehaviour
{
    public Slider health_bar, intellect_bar, likeability_bar, cleanliness_bar, full_bar, social_bar, playfulness_bar;
    public Text playerName;
    public Image icon;

    private void Start()
    {
        online_play.LoadPlayerData();
    }

    // �����Ӹ��� ȣ��Ǵ� �Լ�
    private void Update()
    {
        if (online_play.playerIcon != null)
        {
            Sprite iconSprite = Resources.Load<Sprite>(online_play.playerIcon);
            if (iconSprite != null)
                icon.sprite = iconSprite;
            else
                Debug.Log($"{online_play.playerIcon}�� ã�� �� ����!");
        }
        if (online_play.playerName != null) playerName.text = online_play.playerName;
        
        // �� �����̴��� �ִ밪�� ���׸��� �ִ� ���� ������ ����
        health_bar.maxValue = EggMonStat.maxHealth;

        // �� �����̴��� ���� ���׸��� ���� ���� ����
        health_bar.value = EggMonStat.health;
        intellect_bar.value = EggMonStat.intellect;
        likeability_bar.value = EggMonStat.likeability;
        cleanliness_bar.value = EggMonStat.cleanliness;
        full_bar.value = EggMonStat.full;
        social_bar.value = EggMonStat.social;
        playfulness_bar.value = EggMonStat.playfulness;
    }
}
