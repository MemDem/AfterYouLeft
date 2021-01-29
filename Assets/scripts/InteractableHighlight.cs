using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Interactable nesnelere eklenir. Interactable nesnede asagidaki componentler bulunmalidir.
//Collider, rigidbody
public class InteractableHighlight : MonoBehaviour
{
    public string interactableName = "";
    public int panelIndex = 0;
    PanelContainer panels;

    private void Start()
    {
        panels = FindObjectOfType<PanelContainer>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //TODO burada metin gosterme coroutine baslayabilir ya da panel aktif hale gelebilir.
            panels.storyPanels[panelIndex].SetActive(true);
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
