using System;
using System.Collections.Generic;
using UnityEngine;

public class scr_UI_Inventory : MonoBehaviour
{

}


public class scr_Inventory
{
    private List<D_Item> items = new List<D_Item>();
}


[Serializable]
public struct D_Item
{
    public string Name;
    public Sprite Icon;
    public int Quantity;
}

[Serializable]
public struct D_Inventory
{
    public List<D_Item> Items;
}