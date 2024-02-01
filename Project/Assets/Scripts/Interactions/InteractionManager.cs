using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine;

public class InteractionManager : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Scripting OnStartScript;
    [SerializeField] Scripting OnInteractionScript;
    [SerializeField] public UnityEvent OnInteraction;

    private void Start()
    {
        OnStartScript?.StartScripting();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerId != -1) return;

        OnInteraction.Invoke();
        OnInteractionScript.StartScripting();
    }
}