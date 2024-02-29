using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ����� ����ϱ� ���� �ʿ�

public class TrainControl : MonoBehaviour
{
    public GameObject panelToActivate; // Ȱ��ȭ�� �г��� ������ ����

    // Start �޼���� ��ũ��Ʈ �ν��Ͻ��� �ε��� �� ȣ��˴ϴ�.
    void Start()
    {
        if (panelToActivate != null)
            panelToActivate.SetActive(false); // ���� ���� �� �г��� ��Ȱ��ȭ
    }

    // ��ư Ŭ�� �� ȣ��� �޼���
    public void ActivatePanel()
    {
        if (panelToActivate != null)
            panelToActivate.SetActive(true); // �г��� Ȱ��ȭ
    }
}

