using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Image button;
    public Sprite mute;
    public Sprite volume;
    private AudioSource audioSource;



    private void Start()
    {
        audioSource = FindObjectOfType<AudioManager>()._audioSourceMusic;

        if (audioSource.mute)
        {
            button.sprite = mute;
        }
        else
        {
            button.sprite = volume;
        }
    }

    public void ChangeSoundState()
    {
        audioSource.mute = !audioSource.mute;

        if (audioSource.mute)
        {
            button.sprite = mute;
        }
        else
        {
            button.sprite = volume;
        }
    }

}
