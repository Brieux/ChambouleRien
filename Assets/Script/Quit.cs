using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void cestciao()
    {
        Application.Quit();
    }

    public void letsgo()
    {
        GameManager.Instance.state = 1;
        GameManager.Instance.GetComponent<LevelLoader>().loadFirstLevel();
        GameManager.Instance.GetComponent<ShootBall>().numberOfShot = 4;
    }
}
