using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDamping : MonoBehaviour
{
    public Transform target;
    public float damping = 1;
    public float yPosRestriction = -1;

    float offsetZ;
    Vector3 currentVelocity;
    Vector3 lookAheadPos;

    float nextTimeToSearch = 0;

    // Use this for initialization
    void Start()
    {
        offsetZ = (transform.position - target.position).z;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            FindPlayer();
            return;
        }

        Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

        newPos = new Vector3(transform.position.x, Mathf.Clamp(newPos.y, yPosRestriction, Mathf.Infinity), transform.position.z);

        transform.position = newPos;
    }

    void FindPlayer()
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
            if (searchResult != null)
                target = searchResult.transform;
            nextTimeToSearch = Time.time + 0.5f;
        }
    }
}
