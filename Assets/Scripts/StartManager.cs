using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// ���� ȭ���� �����ϴ� Ŭ����
public class StartManager : MonoBehaviour
{
    public Button StartBtn, AlbumBtn, ExitBtn, GalaryExit; // UI ��ư���� ��Ÿ���� ������
    public Canvas Galary; // �ٹ��� ��Ÿ���� ĵ����

    // ���� �� ȣ��Ǵ� �Լ�
    void Start()
    {
        // �ٹ� ĵ���� ��Ȱ��ȭ
        Galary.gameObject.SetActive(false);

        // ��ư�� Ŭ�� ������ �߰�
        if (StartBtn != null)
        {
            StartBtn.onClick.AddListener(StartGame);
        }
        if (AlbumBtn != null)
        {
            AlbumBtn.onClick.AddListener(OpenAlbum);
        }
        if (ExitBtn != null)
        {
            ExitBtn.onClick.AddListener(ExitGame);
        }
    }

    // �����Ӹ��� ȣ��Ǵ� �Լ�
    private void Update()
    {
        // �ڷ� ���� Ű�� ������ �ٹ� ĵ���� ��Ȱ��ȭ
        if (Input.GetKey(KeyCode.Escape))
        {
            Galary.gameObject.SetActive(false);
        }
    }

    // ���� ���� �Լ�
    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    // �ٹ� ���� �Լ�
    private void OpenAlbum()
    {
        Galary.gameObject.SetActive(true);
    }

    // �ٹ� �ݱ� �Լ�
    private void CloseAlbum()
    {
        Galary.gameObject.SetActive(false);
    }

    // ���� ���� �Լ�
    private void ExitGame()
    {
        Application.Quit();
    }
}
