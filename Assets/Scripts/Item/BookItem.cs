using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Book item", menuName = "Inventory/Items/New Book")]
public class BookItem : ItemScriptableObject
{    
    public int KnowLedge;
    
    private void Start()
    {
        itemType = ItemType.Book;
    }
}
