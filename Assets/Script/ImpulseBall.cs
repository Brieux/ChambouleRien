using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseBall : MonoBehaviour
{
    [SerializeField] bool alreadyReset = false;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Impulse(Vector3 Target)
    {
        GetComponent<Rigidbody>().velocity = (Target - transform.position) * 5f;
        Invoke("Reset", 1.99f);
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().useGravity = true;
        if (collision.gameObject.tag == "Floor" && !alreadyReset)
        {

            GameManager.Instance.GetComponent<ShootBall>().resetBall();
            alreadyReset = true;
        }
    }

    private void Reset()
    {
        if (!alreadyReset)
        {
            GameManager.Instance.GetComponent<ShootBall>().resetBall();
            alreadyReset = true;
        }
    }
}
