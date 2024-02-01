using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] NoiseMaker noiseMaker;
    [SerializeField] float noiseTimer;
    CameraMovement cm;
    float TimeToMakeNoise;
    bool CanMakeNoise = false;

    private void Start()
    {
        cm = GetComponent<CameraMovement>();
        TimeToMakeNoise = noiseTimer;
    }

    private void Update()
    {
        PauseOrResume();
        if (!PauseMenu.instance.IsPaused())
        {
            MakeNoiseUpdate();
            InventoryUpdate();
            MouseUpdate();
        }
    }


    void MakeNoiseUpdate()
    {
        if (TimeToMakeNoise <= 0)
        {
            TimeToMakeNoise = 0;
            CanMakeNoise = true;
        }
        else
        {
            TimeToMakeNoise -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.W) && CanMakeNoise)
        {
            noiseMaker.MakeNoise();
            TimeToMakeNoise = noiseTimer;
            CanMakeNoise = false;
        }
    }

    void MouseUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            cm.InitCameraMovement();
        }

        if (Input.GetMouseButton(1))
        {
            cm.MoveCameraWithMouse();
        }

        if (!Input.GetMouseButtonDown(0)) return;
        Vector2 mousePos = Input.mousePosition;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        Physics.Raycast(ray, out hit);

        GameObject ObjectColided = hit.collider?.gameObject;

        if (ObjectColided != null)
        {
            if (ObjectColided.TryGetComponent(out MovePlayerToObject MPO) &&
                Vector3.Distance(transform.position, ObjectColided.transform.position) < 7f)
            {
                MPO.Move();
            }
            else if (hit.collider.gameObject.TryGetComponent(out DoorInteraction DI))
            {
                DI.Interact();
            }
        }

    }

    void InventoryUpdate()
    {
        if (!Input.GetKeyDown(KeyCode.I)) return;
        
        if (!InventoryAnimations.instance.IsInventoryOpen())
        {
            InventoryAnimations.instance.OpenInventory();
        }
        else
        {
            InventoryAnimations.instance.CloseInventory();
        }
    }

    void PauseOrResume()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        
        if (PauseMenu.instance.IsOnSettings())
        {
            PauseMenu.instance.CloseSettingsMenu();
        }
        else
        {
            if (PauseMenu.instance.IsPaused())
            {
                PauseMenu.instance.Resume();
            }
            else
            {
                PauseMenu.instance.Pause();
            }
        }
    }
}
