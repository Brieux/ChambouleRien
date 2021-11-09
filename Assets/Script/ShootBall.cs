using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    public int numberOfShot = 4;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform spawnPoint;
    private Vector3 RaycastPos;
    public GameObject balle;
    [SerializeField] bool activeBall = false;
    [SerializeField] bool GameOver = false;
    [SerializeField] GameObject rain;

    // Start is called before the first frame update
    void Start()
    {
        resetBall();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (GetComponent<ScoreScript>().nbCanhit == GetComponent<LevelLoader>().nbCans[GetComponent<LevelLoader>().activLevel])
        {
            if (balle == null)
            {
                Debug.Log("salut");
                resetBall();
            }
            GameOver = false;
            rain.SetActive(false);
            GameManager.Instance.state = 1;
            GetComponent<ScoreScript>().finalScoring();
            numberOfShot = 4;
            GetComponent<ScoreScript>().nbCanhit = 0;
            GetComponent<LevelLoader>().callNewLevel();
        }
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
            if (!availableShot() && GetComponent<ScoreScript>().nbCanhit != GetComponent<LevelLoader>().nbCans[GetComponent<LevelLoader>().activLevel])
            {
                
                rain.SetActive(true);
                GameManager.Instance.state = 2;
                GameOver = true;
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
