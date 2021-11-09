using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindParameters : MonoBehaviour
{
    public Vector3 windDirection;
    [Range(-2f, 2f)] public float x;
    [Range(-2f, 2f)] public float z;
    [Range(1f, 2f)] public float windForce = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        windDirection.x = x;
        windDirection.z = z;
        windDirection.y = 0;
    }
}
