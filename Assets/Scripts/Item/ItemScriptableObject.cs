using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Default, Book, Grade }

public class ItemScriptableObject : ScriptableObject
{
    public ItemType itemType;   
    public string itemName;
    public GameObject itemPrefab;
    public Sprite icons;
    public int maximumAmount;
    public string itemDescription;
}
