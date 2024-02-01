using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
public class ItemManager : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [Header("UI")]
    [SerializeField] public Image image;

    [HideInInspector] public Item item;
    [HideInInspector] public Transform parentAfterDrag;

    public void Initialize(Item newItem)
    {
        item = newItem;
        image.sprite = item.image;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}
