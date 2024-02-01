using UnityEngine.EventSystems;
using UnityEngine;

public class Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            ItemManager item = eventData.pointerDrag.GetComponent<ItemManager>();
            item.parentAfterDrag = transform;
        }
    }
}
