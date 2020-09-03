using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseOnCanvas : MonoBehaviour
{
    public GameObject GM;
    void OnEnable()
    {
        Time.timeScale = 0f;
    }

    void OnDisable()
    {
        //GameObject GM = GameObject.Find("GameManager");
        //GM.GetComponent <InstantiateCanvasOnClick> ().pause = false;
        Time.timeScale = 1f;
    }
}
