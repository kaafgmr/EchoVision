using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public Sprite image;
    public Vector2Int range = new Vector2Int(1, 4);
}