using System.Collections.Generic;
using UnityEngine;

public enum EnumAudioType
{
    SACAR_TRONCO,
}



public class AudioManager : MonoBehaviour
{
    public AudioSource _audioSourceFsx;
    public AudioSource _audioSourceMusic;

    public AudioClip _music;
    public AudioClip _sacarTronco;

    private void Awake()
    {
        if (FindObjectsOfType<AudioManager>().Length > 1)
            Destroy(this);
        else
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (_audioSourceMusic.clip == null)
        {
            _audioSourceMusic.clip = _music;
            _audioSourceMusic.Play();
        }

    }

    public void PlaySound(EnumAudioType audioType)
    {
        switch (audioType)
        {
            case EnumAudioType.SACAR_TRONCO:
                _audioSourceFsx.clip = _sacarTronco;
                _audioSourceFsx.Play();
                break;
        }
    }
}
