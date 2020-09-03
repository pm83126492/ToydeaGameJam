using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class startbutton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        SceneManager.LoadScene("DogAndCat");
    }

    
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.Play();
        transform.position += new Vector3(0, 30, 0);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.position -= new Vector3(0, 30, 0);
        Debug.Log("Mouse Exit");
    }
}
