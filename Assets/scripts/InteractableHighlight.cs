using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Interactable nesnelere eklenir. Interactable nesnede asagidaki componentler bulunmalidir.
//Collider, rigidbody
public class InteractableHighlight : MonoBehaviour
{
    public string interactableName = "";

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //TODO burada metin gosterme coroutine baslayabilir ya da panel aktif hale gelebilir.
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
    }
}
