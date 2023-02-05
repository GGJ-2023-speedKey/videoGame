using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Image button;
    public Sprite mute;
    public Sprite volume;
    public AudioSource audioSource;



    private void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();

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
