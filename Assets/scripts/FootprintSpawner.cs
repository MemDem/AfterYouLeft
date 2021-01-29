using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintSpawner : MonoBehaviour
{
    bool leftFoot = false;
    public GameObject leftFootPrint, rightFootPrint;
    public Transform leftPos, rightPos;
    public float distanceThreshold = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFootprint());
    }

    IEnumerator SpawnFootprint()
    {
        while (true)
        {
            Vector3 prevPosition = gameObject.transform.position;
            yield return new WaitForSeconds(1.0f);
            Vector3 curPosition = gameObject.transform.position;
            float dist = Vector3.Distance(prevPosition, curPosition);
            if (dist > distanceThreshold)
            {
                RaycastHit hit;
  

                if (leftFoot)
                {
                    Ray ray = new Ray(leftPos.position, -leftPos.up);
                    if (Physics.Raycast(ray, out hit))
                    {
                        // Find the line from the gun to the point that was clicked.
                        Vector3 incomingVec = hit.point - leftPos.position;

                        // Use the point's normal to calculate the reflection vector.
                        Vector3 reflectVec = Vector3.Reflect(incomingVec, hit.normal);
                        Vector3 tangent = Vector3.Cross(hit.normal.normalized, -Vector3.right);
                        if (tangent.magnitude == 0)
                        {
                            tangent = Vector3.Cross(hit.normal.normalized, Vector3.up);
                        }
                        //Instantiate(leftFootPrint, leftPos.position, Quaternion.Euler(reflectVec.normalized));
                        Instantiate(leftFootPrint, leftPos.position, Quaternion.LookRotation(tangent, hit.normal.normalized));

                    }
                }
                else
                {
                    Ray ray = new Ray(rightPos.position, -rightPos.up);
                    if (Physics.Raycast(ray, out hit))
                    {
                        // Find the line from the gun to the point that was clicked.
                        Vector3 incomingVec = hit.point - rightPos.position;

                        // Use the point's normal to calculate the reflection vector.
                        Vector3 reflectVec = Vector3.Reflect(incomingVec, hit.normal);
                        Vector3 tangent = Vector3.Cross(hit.normal.normalized, -Vector3.right);
                        if (tangent.magnitude == 0)
                        {
                            tangent = Vector3.Cross(hit.normal.normalized, Vector3.up);
                        }
                        //Instantiate(leftFootPrint, leftPos.position, Quaternion.Euler(reflectVec.normalized));
                        Instantiate(rightFootPrint, rightPos.position, Quaternion.LookRotation(tangent, hit.normal.normalized));

                    }
                    //Instantiate(rightFootPrint, rightPos.position, Quaternion.identity);
                }
                leftFoot = !leftFoot;
            }
        }
    }

}
