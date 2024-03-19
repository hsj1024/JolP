using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

// ������ ������ ��Ÿ���� Ŭ����
public class Item : MonoBehaviour
{
    public int price; // ������ ����
    public SerializableDictionary<string, int> itemEffect; // ������ ȿ���� �����ϴ� ��ųʸ�
    public string itemName; // ������ �̸�
    private Text itemPriceText; // ������ ������ ǥ���ϴ� �ؽ�Ʈ
    private Button itemBtn; // �������� ��Ÿ���� ��ư
    public Sprite itemImage; // ������ �̹���
    public string itemType; // ������ ����

    //�߰�
    public AnimationClip Egg_Motion; // �� �Դ� ���
    public AnimationClip Animation_Motion;    // Child �Դ� ���


    // ���� �� ȣ��Ǵ� �Լ�
    private void Start()
    {
        // ������ ȿ�� ��ųʸ� �ʱ�ȭ
        itemEffect = new SerializableDictionary<string, int>();

        // ������ �̹��� �Ҵ�
        itemImage = GetComponent<Image>().sprite;

        // ������ ��ư �� �ؽ�Ʈ ������Ʈ �Ҵ�
        itemBtn = GetComponentInParent<Button>();
        itemPriceText = GetComponentInChildren<Text>();

        // ������ ���� ��ư�� Ŭ�� ������ �߰�
        itemBtn.onClick.AddListener(PurchaseItem);

        // ������ ���� ǥ��
        itemPriceText.text = string.Format($"{price} coin");

        // ������ ȿ�� ����
        SetEffect();
    }

    // ������ ȿ���� �����ϴ� �Լ�
    private void SetEffect()
    {
        // ������ �̸��� ���� ȿ���� ����

        //���� ȿ��
        if (itemName == "Apple")
        {
            itemEffect.Add("full", 30);
        }
        if (itemName == "Steak")
        {
            itemEffect.Add("full", 100);

        }
        if (itemName == "Can")
        {
            itemEffect.Add("full", 30);
        }

        //�峭�� ȿ��
        if (itemName == "Block")
        {
            itemEffect.Add("playfulness", 30);
        }
        if (itemName == "Car")
        {
            itemEffect.Add("playfulness", 50);
        }
        if (itemName == "Game")
        {
            itemEffect.Add("playfulness", 90);
        }


    }

    // �������� �����ϴ� �Լ�
    private void PurchaseItem()
    {
        // �κ��丮�� ���� �� �ְ�, ���� �������� �κ��丮�� ���� ���
        if (Inventory.instance.itemImages.Length == Inventory.instance.items.Count && !Inventory.instance.items.ContainsKey(this))
        {
            Debug.Log("�κ��丮�� ����á���ϴ�.");
            return;
        }

        // ������ ���� ������ ���ݺ��� ���� ���
        if (MoneyManager.money > price)
        {
            FrameManager.instance.OpenQuestionConfirm();
            QuestionConfirmController.instance.SetQuestion(string.Format($"{itemName}�� �����Ͻðڽ��ϱ�?"));
            StartCoroutine(ConfirmPayItem(this));
        }
        else
        {
            // ���� ������ ���
            Debug.Log("��尡 �����Ͽ� ���ſ� �����Ͽ����ϴ�.");
        }
    }
    // ������ ��� Ȯ�� �ڷ�ƾ
    private IEnumerator ConfirmPayItem(Item item)
    {
        QuestionConfirmController.instance.buttonClickedTask = new TaskCompletionSource<bool>();
        Button YesButton = QuestionConfirmController.instance.YesBtn;
        Button NoButtom = QuestionConfirmController.instance.NoBtn;

        yield return new WaitUntil(() => QuestionConfirmController.instance.buttonClickedTask.Task.IsCompleted);

        if (QuestionConfirmController.isYes == true)
        {
            // �κ��丮�� ������ �߰� �� �� ����
            Inventory.instance.GetItem(this);
            MoneyManager.money -= price;
        }
        else
        {

        }
        Inventory.instance.ClearInventory();
        Inventory.instance.InventoryUpdate();

        // ���� ĵ���� �ݱ�
        FrameManager.instance.CloseModal(FrameManager.instance.Shop); // currentModalCanvas�� ���� ���� ĵ������ ����

        // �ʱ�ȭ
        QuestionConfirmController.isYes = null;
    }
}
