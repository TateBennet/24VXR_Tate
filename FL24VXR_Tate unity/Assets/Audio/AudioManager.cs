using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class PlaybackManager : MonoBehaviour
{
    public AudioSource audio1, audio2, audio3, audio4, auido5, audio6;
    public AudioClip myClip;
    //public Slider volumeSlider;

    //public AudioMixerGroup mainMix;
    //AudioMixer main;
    //public AudioListener listener;
    
    public AudioMixerSnapshot inside;
    public AudioMixerSnapshot outside;

    public void TransitionDay()
    {
        //will take two seconeds to transition from one to the other
        inside.TransitionTo(2);

    }

public void PlayOnce (AudioSource audioSource)
{
    if (!audioSource.isPlaying)
    {
        audioSource.PlayOneShot(myClip);
    }
    Debug.Log("clip played");
}

    public void TransitionNight()
    {
        outside.TransitionTo(2);
    }

   // public void ChangeVolume()
    //{
    //    audioSource.Play();
    //}

  //  public void ChangeVolume()
  // {
   // main.SetFloat("MainVolume", volumeSlider.maxValue);
  // }
}
