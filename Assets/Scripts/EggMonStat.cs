using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// EggMon(�˸�)�� ������ �����ϴ� ���� Ŭ����
public static class EggMonStat
{
    // �� ������ �ʱⰪ ����
    public static float health, maxHealth, intellect, likeability, cleanliness, full, social, playfulness;

    // ���� �ʱ�ȭ �Լ�
    public static void InitializeStat()
    {
        maxHealth = 100f;
        health = maxHealth;
        intellect = 0f;
        likeability = 0f;
        playfulness = 0f;
        cleanliness = 50f;
        full = 50f;
        social = 0f;
    }

    // ���� ������Ű�� �Լ�
    public static void IncreaseStat(string stat, float num)
    {
        // ���� �̸��� ���� ������ ������ ������Ŵ
        switch (stat)
        {
            case "health": health += num; break;
            case "intellect": intellect += num; break;
            case "likeability": likeability += num; break;
            case "cleanliness": cleanliness += num; break;
            case "full": full += num; break;
            case "social": social += num; break;
            case "playfulness": playfulness += num; break;
            default: Debug.Log($"{stat}�̶�� ������ �������� �ʽ��ϴ�."); break;
        }
    }

    // ���� ���ҽ�Ű�� �Լ�
    public static void DecreaseStat(string stat, float num)
    {
        // ���� �̸��� ���� ������ ������ ���ҽ�Ŵ
        switch (stat)
        {
            case "health": health -= num; break;
            case "intellect": intellect -= num; break;
            case "likeability": likeability -= num; break;
            case "cleanliness": cleanliness -= num; break;
            case "full": full -= num; break;
            case "social": social -= num; break;
            case "playfulness": playfulness -= num; break;
            default: Debug.Log($"{stat}�̶�� ������ �������� �ʽ��ϴ�."); break;
        }
    }


}
