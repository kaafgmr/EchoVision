using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]public Slot[] InventorySlot;
    [SerializeField] GameObject ItemPrefab;
    public static InventoryManager Instance;

    private void Start()
    {
        Instance = this;
    }

    int selectedSlot = -1;

    void ChangeSelectedSlot(int value)
    {
        selectedSlot = value;
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < InventorySlot.Length; i++)
        {
            Slot slot = InventorySlot[i];
            ItemManager itemInSlot = slot.GetComponentInChildren<ItemManager>();
            if (itemInSlot == null)
            {
                SpawnItem(item, slot);
                return true;
            }
        }
        return false;
    }

    public bool HasItem(Item item)
    {
        for (int i = 0; i < InventorySlot.Length; i++)
        {
            Slot slot = InventorySlot[i];
            ItemManager itemInSlot = slot?.GetComponentInChildren<ItemManager>();
            if (itemInSlot?.item == item)
            {
                return true;
            }
        }
        return false;
    }

    void SpawnItem(Item item, Slot slot)
    {
        GameObject newItemGo = Instantiate(ItemPrefab, slot.transform);
        ItemManager inventoryItem = newItemGo.GetComponent<ItemManager>();
        inventoryItem.Initialize(item);
    }

    public Item GetSelectedItem()
    {
        Slot slot = InventorySlot[selectedSlot];
        ItemManager itemInSlot = slot.GetComponentInChildren<ItemManager>();
        if (itemInSlot != null)
        {
            Destroy(itemInSlot.gameObject);
            return itemInSlot.item;
        }
        return null;
    }
}