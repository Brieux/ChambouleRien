using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public List<GameObject> levels;
    public List<int> nbCans;
    public List<GameObject> prefabs;
    public int activLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadFirstLevel()
    {
        prefabs[activLevel] = Instantiate(levels[activLevel]);
    }

    public void callNewLevel()
    {
        if (activLevel == 9)
        {
            GameManager.Instance.win = true;
        }
        else {
            activLevel += 1;
            prefabs[activLevel] = Instantiate(levels[activLevel]);
            if (activLevel > 2)
            {
                Destroy(prefabs[activLevel - 2]);
            }
        }

    }
}
