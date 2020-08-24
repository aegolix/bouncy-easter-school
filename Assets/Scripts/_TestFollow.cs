using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestFollow : MonoBehaviour
{

    public GameObject bunny;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, bunny.transform.position, 2 * Time.deltaTime);
        //transform.LookAt(bunny.transform);
    }
}
