using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToObject : MonoBehaviour
{
    [SerializeField] private Transform objectToFollow;
    [SerializeField] private bool useYAxis;

    private void Update()
    {
        if (useYAxis)
        {
            transform.LookAt(objectToFollow);
        }
        else
        {
            Vector3 lookHere = new Vector3(objectToFollow.position.x, 0, objectToFollow.position.z);
            transform.LookAt(lookHere);
        }
    }
}
