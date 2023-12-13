using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int price;
    public SerializableDictionary<string, int> itemEffect;
    public string itemName;
    public Text itemPriceText;
    public Button itemBtn;
    public Sprite itemImage;

    private void Start()
    {
        itemEffect = new SerializableDictionary<string, int>();
        itemImage = GetComponent<Image>().sprite;
        itemBtn = GetComponentInParent<Button>();
        itemPriceText = GetComponentInChildren<Text>();

        itemBtn.onClick.AddListener(PurchaseItem);
        itemPriceText.text = string.Format( $"{price} coin");

        SetEffect();
    }
    private void SetEffect()
    {
        if (itemName == "Apple")
        {
            itemEffect.Add("full", 30);
        }
        if (itemName == "Steak")
        {
            itemEffect.Add("full", 100);
        }
    }
    private void PurchaseItem()
    {
        if (Inventory.instance.itemImages.Length == Inventory.instance.items.Count && !Inventory.instance.items.ContainsKey(this))
        {
            Debug.Log("�κ��丮�� ����á���ϴ�.");
            return;
        }
        if (MoneyManager.money > price)
        {
            Inventory.instance.GetItem(this);
            MoneyManager.money -= price;
            Debug.Log(string.Format($"{itemName}�� �����Ͽ����ϴ�"));
        }
        else
        {
            Debug.Log("��尡 �����Ͽ� ���ſ� �����Ͽ����ϴ�.");
        }
    }

}
