using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class rulebutton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // OnClick code goes here ...
        Debug.Log("---------");
        SceneManager.LoadScene("Rule_Scene");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        audio.Play();
        transform.position += new Vector3(0, 30, 0);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.position -= new Vector3(0, 30, 0);
        Debug.Log("Mouse Exit");
    }
}
