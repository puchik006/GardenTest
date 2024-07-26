using System;
using System.Collections.Generic;


//Main settings
[Serializable]
public struct D_MainSettings
{
    public string str_InventoryName;
}

//Inventory
[Serializable]
public struct D_Inventory
{
    public List<D_InventoryItem> ListOfItems;
}

[Serializable]
public struct D_InventoryItem
{
    public string ItemName; //key to D_Item
    public int Quantity;
}

//Player
[Serializable]
public struct D_Player
{
    public string Name;
    public int Health;
    public int Level;
    public int BodyCount;
}

//All possible items
[Serializable]
public struct D_Items
{
   public List<D_Item> Items;
}

[Serializable]
public struct D_Item
{
    public string Name;
    public E_ItemType Type;
    public string Img;
}
