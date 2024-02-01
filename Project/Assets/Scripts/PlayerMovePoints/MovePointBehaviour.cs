using UnityEngine;

public class MovePointBehaviour : MonoBehaviour
{
    [SerializeField] GameObject ObjectToDisappear;

    private void Start()
    {
        if (ObjectToDisappear == null)
        {
            ObjectToDisappear = GetComponentInChildren<GameObject>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        ObjectToDisappear.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        ObjectToDisappear.SetActive(true);
    }
}
