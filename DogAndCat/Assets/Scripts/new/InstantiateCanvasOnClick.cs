using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstantiateCanvasOnClick : MonoBehaviour
{
    //要產生的canvas
    public GameObject canvasPrefab;
    public bool pause;

    void Start()
    {
        pause = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == false)
            {
                pause = true;
                ClickEvent();
            }
            
        }
    }


    void ClickEvent()
    {
        //生產canvasPrefab
        Instantiate(canvasPrefab, Vector2.zero, Quaternion.identity);
    }
}