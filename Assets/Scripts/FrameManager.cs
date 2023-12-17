using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FrameManager : MonoBehaviour
{
    public static FrameManager instance;
    public  Canvas Shop, Stat, Inventory, QuestionConfirm, TrainPopup, OnlinePlay, Play, Work;
    public  Button HomeBtn, ShopBtn, StatBtn, BagBtn, TrainpopBtn, OnlinePlayBtn, PlayBtn, WorkBtn;

    public Image BackgroundImage; // ��� �̹���
    private bool isModalOpen = false; // ��� â�� ���� �ִ��� ���θ� ��Ÿ���� �÷���


    private void Start()
    {
        instance = this;
        Shop.gameObject.SetActive(false);
        Stat.gameObject.SetActive(false);
        Inventory.gameObject.SetActive(false);
        QuestionConfirm.gameObject.SetActive(false);
        TrainPopup.gameObject.SetActive(false);
        OnlinePlay.gameObject.SetActive(false);
        Play.gameObject.SetActive(false);
        Work.gameObject.SetActive(false);

        if (HomeBtn != null)
        {
            HomeBtn.onClick.AddListener(GoHome);
        }
        if (ShopBtn != null)
        {
            ShopBtn.onClick.AddListener(OpenShop);
        }
        if (StatBtn != null)
        {
            StatBtn.onClick.AddListener(OpenStat);
        }
        if (BagBtn != null)
        {
            BagBtn.onClick.AddListener(OpenInventory);
        }
        if (TrainpopBtn != null)
        {
            TrainpopBtn.onClick.AddListener(OpenTrainPopup);
        }
        if (OnlinePlayBtn != null)
        {
            OnlinePlayBtn.onClick.AddListener(OpenOnlinePlay);
        }
        if (PlayBtn != null)
        {
            PlayBtn.onClick.AddListener(OpenPlay);
        }
        if (WorkBtn != null)
        {
            WorkBtn.onClick.AddListener(OpenWork);
        }

        // 1217 �߰� �˾� ������ �� ��� ��Ӱ�
        if (BackgroundImage != null)
        {
            BackgroundImage.gameObject.SetActive(false);
        }

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Shop.gameObject.SetActive(false);
            Stat.gameObject.SetActive(false);
            Inventory.gameObject.SetActive(false);
            TrainPopup.gameObject.SetActive(false);
            OnlinePlay.gameObject.SetActive(false);
            Play.gameObject.SetActive(false);
            Work.gameObject.SetActive(false);
        }
    }

    
    /*public  void GoHome()
    {
        SceneManager.LoadScene("Start");
    }

    public void OpenShop()
    {
        Shop.gameObject.SetActive(true);
    }
    public  void CloseShop()
    {
        Shop.gameObject.SetActive(false);
    }

    public void OpenStat()
    {
        Stat.gameObject.SetActive(true);
    }

    public void CloseStat()
    {
        Stat.gameObject.SetActive(false);
    }

    public void OpenInventory()
    {
        Inventory.gameObject.SetActive(true);
    }

    public void CloseInventory()
    {
        Inventory.gameObject.SetActive(false);
    }

    public void OpenQuestionConfirm()
    {
        QuestionConfirm.gameObject.SetActive(true);
    }
    public void CloseQuestionConfirm()
    {
        QuestionConfirm.gameObject.SetActive(false);
    }


    public void OpenTrainPopup()
    {
        TrainPopup.gameObject.SetActive(true);
    }

    public void CloseTrainPopup()
    {
        Debug.Log("�Ʒ�â exit");
        TrainPopup.gameObject.SetActive(false);
    }

    public void OpenOnlinePlay()
    {
        OnlinePlay.gameObject.SetActive(true);
    }

    public void CloseOnlinePlay()
    {
        OnlinePlay.gameObject.SetActive(false);
    }

    public void OpenPlay()
    {
        Play.gameObject.SetActive(true);
    }

    public void ClosePlay()
    {
        Play.gameObject.SetActive(false);
    }

    public void OpenWork()
    {
        Work.gameObject.SetActive(true);
    }

    public void CloseWork()
    {
        Work.gameObject.SetActive(false);
    }*/

    // ��� â ���� �Լ� ����
    private void OpenModal(Canvas modalCanvas)
    {
        if (!isModalOpen)
        {
            // ��� �̹����� ��Ӱ� ����� Ȱ��ȭ
            if (BackgroundImage != null)
            {
                BackgroundImage.gameObject.SetActive(true);
                BackgroundImage.color = new Color(0, 0, 0, 0.5f); // ��ο� ����
            }

            // ��� â Ȱ��ȭ
            modalCanvas.gameObject.SetActive(true);

            isModalOpen = true;
        }
    }

    // ��� â �ݱ� �Լ� ����
    private void CloseModal(Canvas modalCanvas)
    {
        if (isModalOpen)
        {
            // ��� �̹��� ��Ȱ��ȭ
            if (BackgroundImage != null)
            {
                BackgroundImage.gameObject.SetActive(false);
                BackgroundImage.color = new Color(0, 0, 0, 0); // ������ ����
            }

            // ��� â ��Ȱ��ȭ
            modalCanvas.gameObject.SetActive(false);

            isModalOpen = false;
        }
    }
    public void GoHome()
    {
        SceneManager.LoadScene("Start");
    }

    public void OpenShop()
    {
        OpenModal(Shop);
    }

    public void CloseShop()
    {
        CloseModal(Shop);
    }

    public void OpenStat()
    {
        OpenModal(Stat);
    }

    public void CloseStat()
    {
        CloseModal(Stat);
    }

    public void OpenInventory()
    {
        OpenModal(Inventory);
    }

    public void CloseInventory()
    {
        CloseModal(Inventory);
    }

    public void OpenQuestionConfirm()
    {
        OpenModal(QuestionConfirm);
    }

    public void CloseQuestionConfirm()
    {
        CloseModal(QuestionConfirm);
    }

    public void OpenTrainPopup()
    {
        OpenModal(TrainPopup);
    }

    public void CloseTrainPopup()
    {
        CloseModal(TrainPopup);
    }

    public void OpenOnlinePlay()
    {
        OpenModal(OnlinePlay);
    }

    public void CloseOnlinePlay()
    {
        CloseModal(OnlinePlay);
    }

    public void OpenPlay()
    {
        OpenModal(Play);
    }

    public void ClosePlay()
    {
        CloseModal(Play);
    }

    public void OpenWork()
    {
        OpenModal(Work);
    }

    public void CloseWork()
    {
        CloseModal(Work);
    }
}
