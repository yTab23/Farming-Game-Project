using UnityEngine;

[System.Serializable]
public class ItemDetails
{
    public int ItemCode;
    public ItemType itemType;
    public string itemDescription;
    public SpriteRenderer itemSprite;
    public string itemLongDescription;
    public short itemUseGridRadius;
    public float itemUseRadius;
    public bool isStartingItem;
    public bool canBePickedUp;
    public bool canBeDropped;
    public bool canBeEaten;
    public bool canBeCarried;
}
