using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    public int numberOfShot = 4;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform spawnPoint;
    private Vector3 RaycastPos;
    [SerializeField] GameObject balle;
    [SerializeField] bool activeBall = false;
    [SerializeField] bool GameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        resetBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver == false)
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool isHit = Physics.Raycast(raycast, out hit, 100);
            if (isHit)
            {
                RaycastPos = hit.point;
            }
            if (availableShot() && !activeBall)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    activeBall = true;
                    Shoot();
                }
            }
            if (!availableShot())
            {
                Debug.Log("GameOver");
                GetComponent<ScoreScript>().Scoring();
            }
        }
    }

    public bool availableShot()
    {
        if (numberOfShot > 0)
        {
            
            return true;
        }
        else
        {
            GameOver = true;
            return false;
        }
    }

    public void setNumberOfShot(int delta)
    {
        numberOfShot += delta;
    }

    public void resetBall()
    {
        if (availableShot())
        {
            
            balle = Instantiate(ballPrefab, spawnPoint.position, new Quaternion(0, 0, 0, 0));
            activeBall = false;
        }
    }
    public void Shoot()
    {
        GetComponent<ScoreScript>().Scoring();
        balle.GetComponent<ImpulseBall>().Impulse(RaycastPos);
        setNumberOfShot(-1);
    }

}
