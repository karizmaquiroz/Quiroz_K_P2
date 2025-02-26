using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Search;

public class Inventory : MonoBehaviour
{
    bool showInventoryMenu = false;
    public Rect inventoryRect;// = new Rect(Screen.width / 2, Screen.height / 2, 400, 400);
    public GameObject EmptyObject;
    private int InventorySize = 12;




    //public Item[] inventoryItems; //
    public List<Item> inventoryItems;

    //public Item[] QuickItems; //
    public List<Item> QuickItems;
    List<Item> Items = new List<Item>();

    private bool full = false;



    private void InitalizeInventory()
    {
        inventoryItems = new List<Item>(); //inventoryItems = new Item[InventorySize];
        QuickItems = new List<Item>(); //QuickItems = new List(4); //set size of quick items to 4

        for (int i = 0; i < InventorySize; i++)
        {
            inventoryItems.Add(new Item("Empty", -1));
        }
        for (int i = 0; i < 4; i++)
        {
            QuickItems.Add(new Item("Empty", -1));
        }


    }

    private void AddToInventory(int HowMany, GameObject NewItem)
    {
        bool added = false;

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].name == NewItem.name)
            {
                //increase quantity of inventoryItems at i 
            }
        }
        if (!added)
        {

        }
    }

    private void RemoveFromInventory(int HowMany, string ItemName)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].Name.Equals(ItemName))
            {
                //finish
            }
        }
        for (int i = 0; i < QuickItems.Count; i++)
        {
            if (QuickItems[i].Quantity == 0)
            { 
                //finish}
            }
        }
    }

    private void Awake()
    {
        InitalizeInventory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            showInventoryMenu = (showInventoryMenu) ? false : true;
        }

        shootKeys();
    }

    private void shootKeys()
    {
        if (Input.GetKeyDown("1") || Input.GetKeyDown("[1]"))
            useItem(QuickItems[0].Name);
        if (Input.GetKeyDown("2") || Input.GetKeyDown("[2]"))
            useItem(QuickItems[2].Name);
        if (Input.GetKeyDown("3") || Input.GetKeyDown("[3]"))
            useItem(QuickItems[3].Name);
        if (Input.GetKeyDown("4") || Input.GetKeyDown("[4]"))
            useItem(QuickItems[4].Name);
    }

    private void OnTriggerEnter(Collider other)
    {
        int inventoryAmount = 1;
        if (other.gameObject.tag.Equals("inventoryItem"))
        {
            if (inventoryItems[11].Name != "Empty")
            {
                full = true;
                return;
            }
            if (other.gameObject.name.Contains("Group"))
            {
                inventoryAmount = other.gameObject.GetComponent<GroupInventoryAmount>().amount;
            }

            AddToInventory(inventoryAmount, other.gameObject);
            other.gameObject.SetActive(false);
        }
    }

    //use items method
        //specifics for health/potions 
        //else for other items



    //change quick items method
}
