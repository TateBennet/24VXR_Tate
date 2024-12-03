using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dissolver : MonoBehaviour
{
    public float dissolveDuration = 2;
    public float dissolveStrength;

    public void startDissolver()
    {
        StartCoroutine(dissolverFunction());
    }

    public IEnumerator dissolverFunction()
    {
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
        if (collision.gameObject.CompareTag("acid"))
        {
            Debug.Log("acid rain!!!");
            Destroy(collision.gameObject);
            startDissolver();
        }
    }
}
