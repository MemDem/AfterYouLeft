using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAimAndFire : MonoBehaviour
{
    public Transform gunTip;
    bool wolfIsDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TakeAimToFire();
        }
    }

    void TakeAimToFire()
    {
        if (wolfIsDead)
        {
            return;
        }
        RaycastHit hit;

        Ray ray = new Ray(gunTip.position, gunTip.forward);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("wolf"))
            {
                Destroy(hit.transform.gameObject);
                wolfIsDead = true;
            }
        }
        Debug.DrawRay(gunTip.position, gunTip.forward, Color.white, 0.5f);
    }
}
