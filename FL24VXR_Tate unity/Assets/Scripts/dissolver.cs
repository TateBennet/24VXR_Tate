using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dissolver : MonoBehaviour
{
    public float dissolveDuration = 2;
    public float dissolveStrength;
    public AudioSource acidBurn;

    public void startDissolver()
    {
        StartCoroutine(dissolverFunction());
    }

    public IEnumerator dissolverFunction()
    {
        //animate my dissolve shader over an elapsed time then destroy the object it is attatched to.
        float elapsedTime = 0;

        Material dissolveMaterial = GetComponent<Renderer>().material;

        while(elapsedTime < dissolveDuration)
        {
            elapsedTime += Time.deltaTime;

            dissolveStrength = Mathf.Lerp(0,1,elapsedTime / dissolveDuration);
            dissolveMaterial.SetFloat("_DissolveStrength", dissolveStrength);

            yield return null;
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //start the dissolve animation, play the sound effect and destroy the potion bottle
        if (collision.gameObject.CompareTag("acid"))
        {
            Debug.Log("acid rain!!!");
            Destroy(collision.gameObject);
            acidBurn.Play();
            startDissolver();
        }
    }
}
