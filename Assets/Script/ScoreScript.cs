using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{

    public int score;
    public int nbCan = 0;
    public int nbCanhit = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scoring()
    {
        score += ((nbCan * (nbCan + 1)) / 2);
        nbCan = 0;
    }

    public void finalScoring()
    {
        score += GetComponent<ShootBall>().numberOfShot * 10;
    }
}
