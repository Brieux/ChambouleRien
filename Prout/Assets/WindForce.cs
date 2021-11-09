using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
          Vector3 windDirection = cam.GetComponent<WindParameters>().windDirection;
            float windForce = cam.GetComponent<WindParameters>().windForce;
         ParticleSystem.VelocityOverLifetimeModule volt = GetComponent<ParticleSystem>().velocityOverLifetime;
        volt.x = windDirection.x;
        volt.y = windDirection.y;
        volt.z = windDirection.z;
        volt.speedModifier = windForce;
    }
}
