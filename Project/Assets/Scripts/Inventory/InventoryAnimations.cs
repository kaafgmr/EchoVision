using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAnimations : MonoBehaviour
{
    [SerializeField] Transform InventoryUI;
    [SerializeField] Transform StartPoint;
    [SerializeField] Transform FinalPoint;
    [SerializeField] float speed;
    
    bool opened = false;
    bool show = false;
    bool hide = false;
    public static InventoryAnimations instance;

    private void Start()
    {
        instance = this;
        CloseInventory();
    }

    private void FixedUpdate()
    {
        if (!opened) return;

        if (show)
        {
            ShowAnim();
        }

        if (hide)
        {
            HideAnim();
        }
    }

    public void OpenInventory()
    {
        opened = true;
        show = true;
        hide = false;
    }

    public void CloseInventory()
    {
        show = false;
        hide = true;
    }

    void ShowAnim()
    {
        if (Vector3.Distance(InventoryUI.position, FinalPoint.position) > 0.2f)
        {
            InventoryUI.transform.position = Vector3.Lerp(InventoryUI.position, FinalPoint.position, Time.fixedDeltaTime * speed);
        }
        else
        {
            InventoryUI.position = FinalPoint.position;
            show = false;
        }
    }
    void HideAnim()
    {
        if (Vector3.Distance(InventoryUI.position, StartPoint.position) > 0.2f)
        {
            InventoryUI.position = Vector3.Lerp(InventoryUI.position, StartPoint.position, Time.fixedDeltaTime * speed);
        }
        else
        {
            InventoryUI.position = StartPoint.position;
            hide = false;
            opened = false;
        }
    }

    public bool IsInventoryOpen()
    {
        return opened;
    }
}