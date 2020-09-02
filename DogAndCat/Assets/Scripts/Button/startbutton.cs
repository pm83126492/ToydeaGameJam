using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class startbutton : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClick()
    {
       
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // OnClick code goes here ...
        Debug.Log("---------");
        Application.LoadLevel("DogAndCat");
    }

}
