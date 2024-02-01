using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NoiseMaker : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioMixerGroup audioMixer;
    [SerializeField] bool playOnAwake = false;
    [SerializeField] Transform where;

    AudioSource Audio;

    private void Start()
    {
        Init();
    }
    void Init()
    {
        Audio = gameObject.GetComponent<AudioSource>();
        if (Audio == null)
        {
            Audio = gameObject.AddComponent<AudioSource>();
        }
        
        Audio.clip = audioClip;
        Audio.outputAudioMixerGroup = audioMixer;
        Audio.spatialBlend = 1;
        Audio.playOnAwake = playOnAwake;
        Audio.loop = false;
    }

    public void MakeNoise()
    {
        EchoEffectController.instance.CreateEchoAt(where.position);
        Audio.Play();
    }
}