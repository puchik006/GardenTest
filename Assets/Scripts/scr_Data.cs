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
    public List<D_InventoryItem> Inventory;
}

[Serializable]
public struct D_InventoryItem
{
    public D_Item item;
    public int Quantity;
}

//Player
[Serializable]
public struct D_Player
{
    public string Name;
    public int Health;
    public int Level;
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
    public string Img;
}