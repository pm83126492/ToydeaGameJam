using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aiming2 : MonoBehaviour
{

    public float fRotateSpeed;
    GameObject character;
    GameObject aimer;

    public Image DogLive, DogLive2;
    public static int DogDieNumber;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("dog");
        aimer = GameObject.Find("aiming2");
        DogLive.enabled = DogLive2.enabled = false;
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

        if (DogDieNumber == 1)
        {
            DogLive.enabled = true;
        }
        else if (DogDieNumber >= 2)
        {
            DogLive2.enabled = true;
        }

    }


}
