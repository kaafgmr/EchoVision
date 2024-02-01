using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffectController : MonoBehaviour
{
    [Serializable]
    public struct NoisyObjectsParams
    {
        public Transform transform;
        public float noiseDistance;
    };

    [Range(1, 4)]
    [SerializeField] int waveAmount = 2;
    [SerializeField] float maxDistance = 5;
    [SerializeField] float width = 0.5f;
    [SerializeField] float speed = 1f;
    [SerializeField] Material[] materials;

    Vector4[] Noises;
    public static EchoEffectController instance;
    int lastEmptyNoiseIDFound;
    private void Awake()
    {
        instance = this;
        Noises = new Vector4[50];
        InitEcho();
    }

    private void FixedUpdate()
    {
        ExpandEcho();
    }

    public void CreateEchoAt(Vector3 Position)
    {
        if (isNoisesFull()) return;

        Noises[lastEmptyNoiseIDFound] = Position;
        Noises[lastEmptyNoiseIDFound].w = 0;
    }

    private bool isNoisesFull()
    {
        for (int i = 0; i < Noises.Length; i++)
        {
            if (Noises[i].w == 1)
            {
                lastEmptyNoiseIDFound = i;
                return false;
            }
        }

        return true;
    }

    void InitVariables()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetFloat("_WaveAmount", waveAmount);
            materials[i].SetFloat("_EchoMaxDistance", maxDistance);
            materials[i].SetFloat("_EchoWidth", width);
        }
    }
    private void InitEcho()
    {
        InitVariables();
        ResetEcho();
    }

    private void ResetEcho()
    {
        for (int i = 0; i < Noises.Length; i++)
        {
            Noises[i] = Vector4.zero;
            Noises[i].w = 1;
        }

        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetVectorArray("_Noises", Noises);
        }
    }

    private void ExpandEcho()
    {
        for (int i = 0; i < Noises.Length; i++)
        {
            if (Noises[i].w < 1)
            {
                Noises[i].w +=  Time.fixedDeltaTime * speed;
            }
            else
            {
                Noises[i].w = 1;
            }
        }

        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetVectorArray("_Noises", Noises);
        }
    }

    public void SetWaveAmount(int amount)
    {
        waveAmount = Mathf.Clamp(waveAmount, 1, 4);
        InitVariables();
    }

    public void SetMaxDistance(float amount)
    {
        maxDistance = amount;
        InitVariables();
    }
     
    public void SetEchoWidth(float amount)
    {
        width = amount;
        InitVariables();
    }

    public int GetWaveAmount()
    {
        return waveAmount;
    }

    public float GetMaxDistance()
    {
        return maxDistance;
    }

    public float GetEchoWidth()
    {
        return width;
    }
}