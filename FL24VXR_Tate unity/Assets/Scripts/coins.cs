using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{
    // Reference to the player’s coin count (optional enhancement)
    public static int coinCount = 0;  // Tracks total coins collected across all coins
    public AudioSource coinSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Ensure your player object has the "Player" tag
        {
            coinCount++;
            StartCoroutine(PlaySoundAndDestroy());
        }
    }

    private IEnumerator PlaySoundAndDestroy()
    {
        coinSFX.Play();
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
    }
}
