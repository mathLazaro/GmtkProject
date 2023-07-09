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

    public void PlayFireAudio()
    {
        StartCoroutine(FireAudioClip(Input.GetButton("Fire1")));
    }

    
    IEnumerator FireAudioClip(bool input)
    {
        if(input)
        {
            fire.Play();
            yield return new WaitForSeconds(0.5f);
        }
    }
}