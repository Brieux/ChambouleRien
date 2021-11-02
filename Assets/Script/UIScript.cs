using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] GameObject UICanvas;
    [SerializeField] GameObject UIScore;
    [SerializeField] GameObject UINbBalle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIScore.GetComponent<Text>().text = GetComponent<ScoreScript>().score.ToString();
        switch (GetComponent<ShootBall>().numberOfShot)
        {
            case 4:
                UINbBalle.GetComponent<Text>().text = "OOOO";
                break;
            case 3:
                UINbBalle.GetComponent<Text>().text = "OOOP";
                break;
            case 2:
                UINbBalle.GetComponent<Text>().text = "OOPP";
                break;
            case 1:
                UINbBalle.GetComponent<Text>().text = "OPPP";
                break;
            default:
                UINbBalle.GetComponent<Text>().text = "PPPP";
                break;
        }
    }   
}
