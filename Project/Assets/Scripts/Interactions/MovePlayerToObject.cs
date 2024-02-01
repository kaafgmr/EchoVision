using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MovePlayerToObject : MonoBehaviour//, IPointerDownHandler
{
    [SerializeField] Transform FinalPoint;
    [SerializeField] float speed = 10;

    bool Clicked = false;
    GameObject Player;

    private void Start()
    {
        Player = GameManager.Instance.Player;
    }
    private void FixedUpdate()
    {
        if (Clicked)
        {
            MoveToMe(Player);
        }
    }

    public void Move()
    {
        Clicked = true;
    }

    void MoveToMe(GameObject Object)
    {
        if (Vector3.Distance(Object.transform.position, FinalPoint.position) > 0.2f && Object.transform.rotation != FinalPoint.transform.rotation)
        {
            Object.transform.rotation = Quaternion.Lerp(Object.transform.rotation, FinalPoint.rotation, Time.fixedDeltaTime * speed);
            Object.transform.position = Vector3.Lerp(Object.transform.position, FinalPoint.position, Time.fixedDeltaTime * speed);
        }
        else
        {
            Object.transform.position = FinalPoint.position;
            Object.transform.rotation = FinalPoint.rotation;
            Clicked = false;
        }
    }
}
