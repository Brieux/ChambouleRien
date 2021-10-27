using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    [SerializeField] Texture2D cursorTexture;
    private void Awake()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(0, 0), CursorMode.Auto);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
