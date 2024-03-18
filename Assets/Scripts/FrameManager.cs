using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// UI ĵ������ �����ϴ� ��ũ��Ʈ
public class FrameManager : MonoBehaviour
{
    // ĵ���� �� ��ư ����
    public static FrameManager instance;
    public Canvas Shop, Stat, inventory, QuestionConfirm, TrainPopup, OnlinePlay, Play, Work;
    public Button HomeBtn, ShopBtn, StatBtn, BagBtn, TrainpopBtn, OnlinePlayBtn, PlayBtn, WorkBtn, FoodBtn;
    public Image BackgroundImage; // ��� �̹���
    public GameObject errorMessagePanel;

    private bool isModalOpen = false; // ��� â�� ���� �ִ��� ���θ� ��Ÿ���� �÷���
    private Canvas currentModalCanvas; // ���� ���� �ִ� ��� â�� �����ϱ� ���� ����

    // �ʱ�ȭ �Լ�
    private void Awake()
    {
        inventory.gameObject.SetActive(true);
    }

    // ���� �Լ�
    private void Start()
    {
        instance = this;

        // �� ĵ���� �ʱ� ��Ȱ��ȭ
        Shop.gameObject.SetActive(false);
        Stat.gameObject.SetActive(false);
        inventory.gameObject.SetActive(false);
        QuestionConfirm.gameObject.SetActive(false);
        TrainPopup.gameObject.SetActive(false);
        OnlinePlay.gameObject.SetActive(false);
        Play.gameObject.SetActive(false);
        Work.gameObject.SetActive(false);
        

        // �� ��ư�� ������ �߰�
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
        if (FoodBtn != null)
        {
            FoodBtn.onClick.AddListener(OpenFood);
        }

        // ��� �̹��� �ʱ� ��Ȱ��ȭ
        if (BackgroundImage != null)
        {
            BackgroundImage.gameObject.SetActive(false);
        }
    }

    // ������Ʈ �Լ�
    private void Update()
    {
        // Escape Ű�� ���� �� ĵ���� ��Ȱ��ȭ
        if (Input.GetKey(KeyCode.Escape))
        {
            Shop.gameObject.SetActive(false);
            Stat.gameObject.SetActive(false);
            inventory.gameObject.SetActive(false);
            TrainPopup.gameObject.SetActive(false);
            OnlinePlay.gameObject.SetActive(false);
            Play.gameObject.SetActive(false);
            Work.gameObject.SetActive(false);
            
        }
    }

    // Ȩ���� �̵� �Լ�
    public void GoHome()
    {
        SceneManager.LoadScene("Start");
    }

    // ���� ���� �Լ�
    public void OpenShop()
    {
        OpenModal(Shop);
    }

    // ���� �ݱ� �Լ�
    public void CloseShop()
    {
        CloseModal(Shop);
    }

    // ���� â ���� �Լ�
    public void OpenStat()
    {
        OpenModal(Stat);
    }

    // ���� â �ݱ� �Լ�
    public void CloseStat()
    {
        CloseModal(Stat);
    }

    // �κ��丮 ���� �Լ�
    public void OpenInventory()
    {
        Inventory.instance.ClearInventory();
        Inventory.instance.InventoryUpdate();
        OpenModal(inventory);
    }

    // �κ��丮 �ݱ� �Լ�
    public void CloseInventory()
    {
        CloseModal(inventory);
        Inventory.instance.OpenWithItemType = "All";
    }

    // ����ڿ��� Ȯ�� ���� ���� �Լ�
    public void OpenQuestionConfirm()
    {
        QuestionConfirm.gameObject.SetActive(true);
    }

    // Ȯ�� ���� �ݱ� �Լ�
    public void CloseQuestionConfirm()
    {
        QuestionConfirm.gameObject.SetActive(false);
    }

    // �Ʒ� �˾� ���� �Լ�
    public void OpenTrainPopup()
    {
        OpenModal(TrainPopup);
    }

    // �Ʒ� �˾� �ݱ� �Լ�
    public void CloseTrainPopup()
    {
        CloseModal(TrainPopup);
    }

    // �¶��� �÷��� ���� �Լ�
    public void OpenOnlinePlay()
    {
        OpenModal(OnlinePlay);
    }

    // �¶��� �÷��� �ݱ� �Լ�
    public void CloseOnlinePlay()
    {
        CloseModal(OnlinePlay);
    }

    // ���� â ���� �Լ�
    public void OpenPlay()
    {
        Inventory.instance.OpenWithItemType = "Toy";
        Inventory.instance.ClearInventory();
        Inventory.instance.InventoryUpdate();
        OpenModal(inventory);
    }

    // ���� â �ݱ� �Լ�
    public void ClosePlay()
    {
        CloseModal(inventory);
        Inventory.instance.OpenWithItemType = "All";
    }

    // ���� â ���� �Լ�
    public void OpenFood()
    {
        Inventory.instance.OpenWithItemType = "Food";
        Inventory.instance.ClearInventory();
        Inventory.instance.InventoryUpdate();
        OpenModal(inventory);
    }

    // ���� â �ݱ� �Լ�
    public void CloseFood()
    {
        CloseModal(inventory);
        Inventory.instance.OpenWithItemType = "All";
    }

    // ���ϱ� â ���� �Լ�
    public void OpenWork()
    {
        OpenModal(Work);
    }

    // ���ϱ� â �ݱ� �Լ�
    public void CloseWork()
    {
        CloseModal(Work);
    }


    
    // ���� �г��� �ݴ� �޼���
    public void CloseErrorMessagePanel()
    {
        errorMessagePanel.SetActive(false);
    }

    // ��� â ���� �Լ�
    private void OpenModal(Canvas modalCanvas)
    {
        if (!isModalOpen)
        {
            // ��� �̹����� ��Ӱ� ����� Ȱ��ȭ
            if (BackgroundImage != null && !BackgroundImage.gameObject.activeSelf)
            {
                BackgroundImage.gameObject.SetActive(true);
            }

            // ��� â Ȱ��ȭ
            modalCanvas.gameObject.SetActive(true);

            isModalOpen = true;
        }
    }

    // ��� â �ݱ� �Լ� ����
    public void CloseModal(Canvas modalCanvas)
    {
        if (isModalOpen)
        {
            // ��� �̹����� ��Ȱ��ȭ�� ��쿡�� Ȱ��ȭ�ϵ��� ����
            if (BackgroundImage != null && BackgroundImage.gameObject.activeSelf)
            {
                BackgroundImage.gameObject.SetActive(false);
            }

            // ��� â ��Ȱ��ȭ
            modalCanvas.gameObject.SetActive(false);

            isModalOpen = false;
        }
    }
}
