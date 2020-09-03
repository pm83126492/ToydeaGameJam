using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToTitleButton : MonoBehaviour
{
    
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
        SceneManager.LoadScene("Start_Scene");
    }
}
