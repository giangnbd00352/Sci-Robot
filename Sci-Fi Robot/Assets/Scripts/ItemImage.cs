using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string ItemName;
    public Sprite Image;
    public string Description;
}

public class ItemImage : MonoBehaviour {
    public List<Sprite> lstImages = new List<Sprite>();
    // Use this for initi
}
