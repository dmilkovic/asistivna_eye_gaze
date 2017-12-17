using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    public AudioClip musicClipKidsCheering;
    public AudioClip musicClipEndCheering;
    public AudioSource musicSource;

    void Start ()
    {
        musicSource.clip = musicClipKidsCheering;
    }

    public void ChangeSource()
    {
        musicSource.clip = musicClipEndCheering;
    }
	
	public void PlayAudioClip ()
    {
        musicSource.Play();
    }
}
