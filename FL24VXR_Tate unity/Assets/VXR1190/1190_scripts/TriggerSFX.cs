using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
{

    public AudioSource playSound;
    public AudioClip whisper;
    public float count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (count == 1)
        {
            playSound.Stop();
            count = 0;
        }
        else
        {
            playSound.Play();
            playSound.PlayOneShot(whisper, 0.5f);
            count++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
