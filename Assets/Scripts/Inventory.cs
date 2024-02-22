using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // �κ��丮 �̱��� �ν��Ͻ�
    public static Inventory instance;
    public GameObject characterGameObject; // �ִϸ��̼� ������ ���� ����

    // �����۰� ������ �����ϴ� ��ųʸ�
    public SerializableDictionary<Item, int> items;

    // UI ��� �迭
    public GameObject[] inventoryItems;
    public GameObject[] itemImages;
    public GameObject[] itemNum;

    // �κ��丮�� Ư�� ������ Ÿ������ �� �� ����ϴ� �ʵ�
    public string OpenWithItemType;

    // �ʱ�ȭ �Լ�
    public void Start()
    {
        OpenWithItemType = "All";
        instance = this;
        items = new SerializableDictionary<Item, int>();

        // UI ��ҵ��� �±׷� ã�� �迭�� �Ҵ�
        itemImages = GameObject.FindGameObjectsWithTag("itemImage");
        itemNum = GameObject.FindGameObjectsWithTag("itemNum");
        inventoryItems = GameObject.FindGameObjectsWithTag("inventoryItem");

        // �ʱ�ȭ �� ��� ������ �̹����� ��Ȱ��ȭ
        foreach (var itemImage in itemImages)
        {
            itemImage.SetActive(false);
        }
    }

    // �κ��丮 �ʱ�ȭ �Լ�
    public void ClearInventory()
    {
        int i = 0;
        foreach (var itemimage in itemImages)
        {
            itemimage.SetActive(true);
            itemimage.GetComponent<Image>().sprite = null;
            itemimage.SetActive(false);
            itemNum[i].GetComponent<Text>().text = "";
            inventoryItems[i].GetComponent<inventoryItemClick>().item = null;
            i += 1;
        }
    }

    // �κ��丮 ������Ʈ �Լ�
    public void InventoryUpdate()
    {
        if (items.Count > 0)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (OpenWithItemType == "All" || OpenWithItemType == item.Key.itemType)
                {
                    if (itemImages.Length > i)
                    {
                        itemImages[i].SetActive(true);
                        itemImages[i].GetComponent<Image>().sprite = item.Key.itemImage;
                        itemNum[i].GetComponent<Text>().text = item.Value.ToString();
                        inventoryItems[i].GetComponent<inventoryItemClick>().item = item.Key;
                        i += 1;
                    }
                }
            }
        }
    }

    // ������ ȹ�� �Լ�
    public void GetItem(Item item)
    {
        if (items.ContainsKey(item))
        {
            items[item] += 1;
        }
        else
        {
            items.Add(item, 1);
        }
    }

    // ������ ��� �Լ�
    public void UseItem(Item item)
    {
        if (items.ContainsKey(item) && items[item] > 0)
        {
            FrameManager.instance.OpenQuestionConfirm();
            QuestionConfirmController.instance.SetQuestion(string.Format($"{item.itemName}�� ����Ͻðڽ��ϱ�?"));
            StartCoroutine(ConfirmUseItem(item));
        }
    }

    // ������ ��� Ȯ�� �ڷ�ƾ
    private IEnumerator ConfirmUseItem(Item item)
    {
        QuestionConfirmController.instance.buttonClickedTask = new TaskCompletionSource<bool>();
        Button YesButton = QuestionConfirmController.instance.YesBtn;
        Button NoButtom = QuestionConfirmController.instance.NoBtn;

        yield return new WaitUntil(() => QuestionConfirmController.instance.buttonClickedTask.Task.IsCompleted);

        if (QuestionConfirmController.isYes == true)
        {
            // ������ ȿ�� ����
            foreach (var stat in item.itemEffect)
            {
                EggMonStat.IncreaseStat(stat.Key, stat.Value);
                Debug.Log(string.Format($"{stat.Key} ������ {stat.Value}��ŭ �����Ͽ����ϴ�."));
            }

            // ������ ���� ����
            items[item] -= 1;

            // ������ 0 �����̸� ��ųʸ����� ������ ����
            if (items[item] <= 0)
            {
                items.Remove(item);
            }

            // �κ��丮 Ŭ���� �� ������Ʈ
            ClearInventory();
            InventoryUpdate();
        }

        // ���� ĵ���� �ݱ� (��: �κ��丮 ĵ����)
        FrameManager.instance.CloseModal(FrameManager.instance.inventory); // currentModalCanvas�� ���� ���� ĵ������ ����

        // ĳ���� �ִϸ��̼� ����
        Animator characterAnimator = characterGameObject.GetComponent<Animator>();
        if (characterAnimator != null)
        {
            characterAnimator.SetTrigger("useItem");
        }

        // �ʱ�ȭ
        QuestionConfirmController.isYes = null;
    }
}
