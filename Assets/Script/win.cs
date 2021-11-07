using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win : MonoBehaviour
{
    [SerializeField] GameObject Scoretext;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void UpdateScore()
    {
        Scoretext.GetComponent<Text>().text += GameManager.Instance.GetComponent<ScoreScript>().score;
    }
}
