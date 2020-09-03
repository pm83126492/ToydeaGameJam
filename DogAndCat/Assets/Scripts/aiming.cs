using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aiming : MonoBehaviour
{

    public float fRotateSpeed;
    GameObject character;
    GameObject aimer;

    public Image CatLive, CatLive2;
    public static int CatDieNumber;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("cat");
        aimer = GameObject.Find("aiming");
        CatLive.enabled = CatLive2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.IsDie)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * fRotateSpeed);
            Vector3 target = new Vector3(character.transform.position.x, transform.position.y, character.transform.position.z);
            aimer.transform.position = target;
        }

        if (CatDieNumber == 1)
        {
            CatLive.enabled = true;
        }
        else if (CatDieNumber >= 2)
        {
            CatLive2.enabled = true;
        }
    }

    
}
