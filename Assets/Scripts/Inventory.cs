using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;


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

    //���� �߰� 
    public Animator anim;
    public Animator egganim;
    public GameObject skin1; // �� ������ Inspector���� �Ҵ��ؾ� �մϴ�.
    public GameObject skin2;
    public GameObject skin3;
    public Tamagotchi tamagotchi;


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

            /// ������ ��� �ִϸ��̼� ����

            /// �� ������ ��

            // �� ������ �� �ִϸ��̼� ����
            if (tamagotchi.state == Tamagotchi.State.EGG)
            {
                // "Apple", "Can", "Steak" �����ۿ� ���� �� ���� �ִϸ��̼�
                if (item.itemName == "Apple" && item.Egg_Motion != null)
                {
                    EggMonStat.IncreaseStat("health", 30);

                    StartCoroutine(PlayAnimationRepeat("Eggeat", 2));

                    // ���� �г� ��Ȱ��ȭ
                    tamagotchi.errorMessagePanel.SetActive(false);
                }
                if (item.itemName == "Can" && item.Egg_Motion != null)
                {
                    EggMonStat.IncreaseStat("full", 30);

                    StartCoroutine(PlayAnimationRepeat("Eggeat", 2));                    // ���� �г� ��Ȱ��ȭ
                    tamagotchi.errorMessagePanel.SetActive(false);
                }
                if (item.itemName == "Steak" && item.Egg_Motion != null)
                {
                    EggMonStat.IncreaseStat("health", 100);

                    StartCoroutine(PlayAnimationRepeat("Eggeat", 2));                    // ���� �г� ��Ȱ��ȭ
                    tamagotchi.errorMessagePanel.SetActive(false);
                }
                if (item.itemName == "Skin Berry" || item.itemName == "Skin Bread" || item.itemName == "Skin Rabbit")
                {
                    tamagotchi.errorMessagePanel.SetActive(true);

                }
            }


            


            // Child ������ ��
            if (tamagotchi.state == Tamagotchi.State.CHILD)
            {
                // CHILD ���¿����� ������ ��� �� �ִϸ��̼� ����
                // ��: "Apple" ������ ��� ��
                if (item.itemName == "Apple" && item.Animation_Motion != null)
                {
                    EggMonStat.IncreaseStat("health", 30);

                    StartCoroutine(PlayAnimationRepeat("isEat", 3));
                    tamagotchi.errorMessagePanel.SetActive(false);
                }
                else if (item.itemName == "Can" && item.Animation_Motion != null)
                {
                    EggMonStat.IncreaseStat("full", 30);

                    StartCoroutine(PlayAnimationRepeat("EatCan", 3));
                }
                else if (item.itemName == "Steak" && item.Animation_Motion != null)
                {
                    EggMonStat.IncreaseStat("health", 100);

                    StartCoroutine(PlayAnimationRepeat("EatSteak", 3));
                }

            
            // �峭��
            if (item.itemName == "Block" && item.Animation_Motion != null)
                {
                    EggMonStat.IncreaseStat("playfulness", 30);

                    anim.SetBool("playMotion", true);


                }
                if (item.itemName == "Car" && item.Animation_Motion != null)
                {
                    EggMonStat.IncreaseStat("playfulness", 50);

                    anim.SetBool("playMotion", true);

                }
                if (item.itemName == "Game" && item.Animation_Motion != null)
                {
                    EggMonStat.IncreaseStat("playfulness", 90);

                    anim.SetBool("playMotion", true);

                }
                //��Ų
                if (item.itemName == "Skin Berry")
                {
                    tamagotchi.ApplySkin(0); // ApplySkin ȣ��, �迭�� ù ��° ��Ų
                    ShowSkinUI(item.itemName); // UI ������Ʈ
                    Debug.Log("��Ų1");
                }
                else if (item.itemName == "Skin Bread")
                {
                    tamagotchi.ApplySkin(1); // �迭�� �� ��° ��Ų
                    ShowSkinUI(item.itemName); // UI ������Ʈ

                }
                else if (item.itemName == "Skin Rabbit")
                {
                    tamagotchi.ApplySkin(2); // �迭�� �� ��° ��Ų
                    ShowSkinUI(item.itemName); // UI ������Ʈ

                }
            }

            // TEEN �����϶�
            else if (tamagotchi.state == Tamagotchi.State.TEEN || tamagotchi.state == Tamagotchi.State.ADULT)
            {
                if (item.itemName == "Skin Berry" || item.itemName == "Skin Bread" || item.itemName == "Skin Rabbit")
                {
                    tamagotchi.errorMessagePanel.SetActive(true);

                }

                if (item.itemName == "Block" || item.itemName == "Car" || item.itemName == "Game")
                {
                    tamagotchi.errorMessagePanel.SetActive(true);

                }
            }

            
                


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
        

        // �ʱ�ȭ
        QuestionConfirmController.isYes = null;
    }

    // �ִϸ��̼��� ������ Ƚ����ŭ �ݺ��� �� ��Ȱ��ȭ�ϴ� Coroutine
    IEnumerator PlayAnimationRepeat(string animationBoolName, int repeatCount)
    {
        for (int i = 0; i < repeatCount; i++)
        {
            anim.SetBool(animationBoolName, true);
            egganim.SetBool(animationBoolName, true);
            tamagotchi.EGGTalkPanel.SetActive(true);
            // �ִϸ��̼��� ������ ���� ������ ��ٸ� (�ִϸ��̼� ���̸� �����ϼ���)
            yield return new WaitForSeconds(1.5f); // ������ 1�� ����

            anim.SetBool(animationBoolName, false);
            tamagotchi.EGGTalkPanel.SetActive(false);
            egganim.SetBool(animationBoolName, false);
            // ���� �ݺ� ���� ª�� ��� �ð��� ���� (�ʿ信 ���� ����)
            //yield return new WaitForSeconds(0.1f);
        }
    }
    // ��Ų UI Ȱ��ȭ �Լ�
    public void ShowSkinUI(string skinName)
    {
        // ��� ��Ų UI�� ���� ��Ȱ��ȭ
        skin1.SetActive(false);
        skin2.SetActive(false);
        skin3.SetActive(false);

        // ��Ų �̸��� ���� �ش��ϴ� ��Ų UI�� Ȱ��ȭ
        switch (skinName)
        {
            case "Skin Berry":
                skin1.SetActive(true);
                break;
            case "Skin Bread":
                skin2.SetActive(true);
                break;
            case "Skin Rabbit":
                skin3.SetActive(true);
                break;
        }
    }

}
