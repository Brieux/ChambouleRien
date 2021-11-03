using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactCanFloor : MonoBehaviour
{
    public bool Hited = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor" && Hited == false)
        {
            Hited = true;
            GameManager.Instance.GetComponent<ScoreScript>().nbCan += 1;
            GameManager.Instance.GetComponent<ScoreScript>().nbCanhit += 1;
            
        }
    }
}
