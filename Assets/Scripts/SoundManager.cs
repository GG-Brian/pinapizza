using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> sounds;

    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("SoundManager is null");
            }
            return _instance;
        }
    }
    void Awake()
    {
        _instance = this;
    }

    public void PlayAudio(AudioSource audioSource, AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
