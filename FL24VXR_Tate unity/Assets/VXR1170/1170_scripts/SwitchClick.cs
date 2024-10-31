using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchClick : MonoBehaviour
{
    public static int clickCount = 0;

    private void OnMouseDown()
    {
        clickCount++;
        Transform moveLoc;
        GameObject tmp = Instantiate(this.gameObject);
        Destroy(tmp.GetComponent<SwitchClick>());

        switch (clickCount)
        {
            case 1:
                tmp.name = "Pan Item 1";
                moveLoc = GameObject.Find("Loc1").transform;

                tmp.transform.position = moveLoc.position;
                //tmp.transform.rotation = moveLoc.rotation;
                //tmp.transform.localScale = new Vector3(1f, 1f, 1f);
                break;

            case 2:
                tmp.name = "Pan Item 2";
                moveLoc = GameObject.Find("Loc2").transform;

                tmp.transform.position = moveLoc.position;
                //tmp.transform.rotation = moveLoc.rotation;
                //tmp.transform.localScale = new Vector3(1f, 1f, 1f);
                break;

            case 3:
                tmp.name = "Pan Item 3";
                moveLoc = GameObject.Find("Loc3").transform;

                tmp.transform.position = moveLoc.position;
                //tmp.transform.rotation = moveLoc.rotation;
                //tmp.transform.localScale = new Vector3(1f, 1f, 1f);
                clickCount = 0;
                break;
        }
    }
}
