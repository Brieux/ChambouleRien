using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<GameObject> UI;
    public Transform camTransform;
    public int state; //0 in menu, 1 in game, 2 in ending screen;
    [SerializeField] GameObject FXFirework;
    public bool win = false;
    private bool TextUpdate = true;

    private void Awake()
    {
        Instance = this;
        state = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (win)
        {
            state = 3;
            if (TextUpdate)
            {
                UI[3].GetComponentInChildren<win>().UpdateScore();
                TextUpdate = false;
            }
        }
        switch (state)
        {
            case 3:
                camTransform.rotation = new Quaternion(-0.0975827575f, 0, 0, 0.995227456f);
                FXFirework.GetComponent<ParticleSystem>().Play();
                UI[3].SetActive(true);
                UI[2].SetActive(false);
                UI[1].SetActive(false);
                UI[0].SetActive(false);
                break;
            case 2:
                UI[3].SetActive(false);
                UI[2].SetActive(true);
                UI[1].SetActive(false);
                UI[0].SetActive(false);
                break;
            case 1:
                Time.timeScale = 1;
                camTransform.rotation = new Quaternion(0.216439605f, 0, 0, 0.976296067f);
                UI[3].SetActive(false);
                UI[2].SetActive(false);
                UI[1].SetActive(true);
                UI[0].SetActive(false);
                break;
            case 0:
                Time.timeScale = 0;
                camTransform.rotation = new Quaternion(0.389289618f, -0.668421686f, 0.273699313f, 0.571624756f);
                UI[3].SetActive(false);
                UI[2].SetActive(false);
                UI[1].SetActive(false);
                UI[0].SetActive(true);
                break;
            default:
                UI[2].SetActive(false);
                UI[1].SetActive(false);
                UI[0].SetActive(false);
                break;
        }
    }
}
