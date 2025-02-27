using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Search;
using Unity.VisualScripting;

public class Inventory : MonoBehaviour
{
    bool showInventoryMenu = false;
    public Rect inventoryRect;// = new Rect(Screen.width / 2, Screen.height / 2, 400, 400);
    public GameObject EmptyObject;
    private int InventorySize = 12;




    //public Item[] inventoryItems; //for arrays
    public List<Item> inventoryItems;

    //public Item[] QuickItems; //for arrays
    public List<Item> QuickItems;
    List<Item> Items = new List<Item>();

    private bool full = false;


    //finished (done)
    private void InitalizeInventory()
    {
        inventoryItems = new List<Item>(); 
        QuickItems = new List<Item>(); 

        for (int i = 0; i < InventorySize; i++)
        {
            inventoryItems.Add(new Item( -1, "Empty"));
            //if using gameobject go for item :
                //inventoryItems.Add(new Item( -1, EmptyObject)); 
        }
        for (int i = 0; i < 4; i++)
        {
           QuickItems.Add(new Item(-1, "Empty"));
            //if using gameobject go for item :
                //QuickItems.Add(new Item( -1, EmptyObject)); 
        }


    }
     

    //finish (progress)
    private void AddToInventory(int HowMany, GameObject NewItem)
    {
        bool added = false;

        for (int i = 0; i < inventoryItems.Count; i++) //goes through list of inventoryItems 1-12
        {
            if (inventoryItems[i].name == NewItem.name) //finds if there is a matching name if so increase quantity of item
            {
                //increase quantity of inventoryItems at i 
                int value = inventoryItems[i].Quantity + HowMany;
                inventoryItems[i].Quantity = value;
                break;
            }
            else if (inventoryItems[i].name != NewItem.name && inventoryItems[i].name == "Empty")
            {
                string Value= NewItem.name;
                Item createIt = new Item(HowMany, Value);
                // Item createIt = new Item(HowMany, NewItem);
                Items.Add(createIt);
                break;
            }
        }
        if (!added) //keep (git rid of else if) or get rid of
        {
            string Value = NewItem.name;
            Item createIt = new Item(HowMany, Value);
            Items.Add(createIt);
            
            
        }
    }


    //finish (in progress)
    private void RemoveFromInventory(int HowMany, string ItemName)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].Name.Equals(ItemName))
            {
                int value = inventoryItems[i].Quantity - HowMany;
                inventoryItems[i].Quantity = value;

                if (inventoryItems[i].Quantity <= 0)
                {
                    inventoryItems[i] = new Item(0, "Empty");
                    // if method took in a GameObject callled ItemName then do below
                        //inventoryItems[i] = new Item(0, EmptyObject);
                }
                break;
            }
        }
        for (int i = 0; i < QuickItems.Count; i++)
        {
            if (QuickItems[i].Quantity == 0)
            {
               // QuickItems[i]
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
                //inventoryAmount = other.gameObject.GetComponent<GroupInventoryAmount>().amount;
            }

            AddToInventory(inventoryAmount, other.gameObject);
            other.gameObject.SetActive(false);
        }
    }


    //finish (in progress)
    private void useItem(string name)
    { 
        //specifics for health/potions 
        //else for other items
            if (name == "Empty") { return; }
            //else if(name == "Potion10") { .health += 10; }
            //else if (name == "Potion10") { .health += 20; }
            //else if (name == "Potion10") { .health += 30; }
            else
            {
                for(int index = 0; index <inventoryItems.Count; index++)
                {

                }
            }
        RemoveFromInventory(1, name);

    }


    //change quick items method
}
