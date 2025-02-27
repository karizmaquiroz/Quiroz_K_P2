using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//does not have a monobehavior
public class Item 
{
    [SerializeField] int quantity;
    //[SerializeField] GameObject go; 
    public string name;


    /*
     * if useing game object instead of string n for invenotry
     * 
    public Item(int quantity, GameObject gObject)
    {
        this.quantity = quantity;
        go = gObject;
        name = gObject.name;
        //name = n;
    }
    */
    
    
    
    public Item(int quantity, string n)
    {
        this.quantity = quantity;
        name = n;
    }
    
    
    /*
    public GameObject GObject
    {
        get { return go; }
        set { go = value; }
    }
    */
    
    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public override string ToString()
    {
        //return go.name + ": " + quantity + "\n";
        return name + ": " + quantity + "\n";
    }

}
