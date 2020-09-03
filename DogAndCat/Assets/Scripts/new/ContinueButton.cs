using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ContinueButton : MonoBehaviour
{
    
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            ClickEvent();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    

    void ClickEvent()
    {
        Debug.Log("++++++++");
        Destroy(canvas);
    }
}
