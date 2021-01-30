using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintSpawner : MonoBehaviour
{
    bool leftFoot = false;
    bool continueSpawn = true;
    public GameObject leftFootPrint, rightFootPrint;
    public Transform leftPos, rightPos;
    public float distanceThreshold = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFootprint());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("home"))
        {
            continueSpawn = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("home"))
        {
            continueSpawn = true;
        }
    }
    IEnumerator SpawnFootprint()
    {
        while (true)
        {
            Vector3 prevPosition = gameObject.transform.position;
            yield return new WaitForSeconds(1.0f);
            if (!continueSpawn)
            {
                continue;
            }
            Vector3 curPosition = gameObject.transform.position;
            float dist = Vector3.Distance(prevPosition, curPosition);
            if (dist > distanceThreshold)
            {


                if (leftFoot)
                {
                    SpawnFootprint(leftFootPrint, leftPos);
                }
                else
                {
                    SpawnFootprint(rightFootPrint, rightPos);
                }
                leftFoot = !leftFoot;
            }
        }
    }



    void SpawnFootprint(GameObject foot, Transform footPos)
    {
        RaycastHit hit;

        Ray ray = new Ray(footPos.position, -footPos.up);
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 tangent = Vector3.Cross(hit.normal.normalized, -Vector3.right);
            if (tangent.magnitude == 0)
            {
                tangent = Vector3.Cross(hit.normal.normalized, Vector3.up);
            }
            Instantiate(foot, footPos.position, Quaternion.LookRotation(tangent, hit.normal.normalized));
        }
    }

}