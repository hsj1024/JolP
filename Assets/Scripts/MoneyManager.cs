using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���� ������ ���� �����ϴ� Ŭ����
public class MoneyManager : MonoBehaviour
{
    public static int money; // ���� ������ ���� ����
    public Text coinText; // ���� ǥ���ϴ� UI �ؽ�Ʈ

    // ���� �� ȣ��Ǵ� �Լ�
    void Start()
    {
        money = 500; // �ʱ� �� ����
    }

    // �����Ӹ��� ȣ��Ǵ� �Լ�
    void Update()
    {
        // ���� ǥ���ϴ� UI �ؽ�Ʈ ������Ʈ
        coinText.text = money.ToString();
    }
}