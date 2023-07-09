using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource princessHurt;
    [SerializeField] private AudioSource fire;

    public static AudioController Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        backgroundMusic.Play();
    }

    public void PlayPrincessHurtAudio()
    {
        princessHurt.Play();
    }

    public void BackgroundMusicControl(bool a)
    {
        if(a)
        {
            backgroundMusic.Play();
        }
        else
        {
            backgroundMusic.Pause();
        }
    }

    public void PlayFireAudio()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            fire.Play();
        }
    }

    /*
    IEnumerator FireAudioClip()
    {
            
            yield return new WaitForSeconds(1f);
            fire.Pause();
    }*/
}
