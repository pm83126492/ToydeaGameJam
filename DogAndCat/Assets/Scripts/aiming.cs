using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiming : MonoBehaviour
{

    public float fRotateSpeed;
    GameObject character;
    GameObject aimer;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("cat");
        aimer = GameObject.Find("aiming");

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * fRotateSpeed);
        Vector3 target = new Vector3(character.transform.position.x, transform.position.y, character.transform.position.z);
        aimer.transform.position = target;
    }

    
}
