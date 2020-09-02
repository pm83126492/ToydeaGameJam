using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiming2 : MonoBehaviour
{

    public float fRotateSpeed;
    GameObject character;
    GameObject aimer;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("dog");
        aimer = GameObject.Find("aiming2");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * fRotateSpeed);     
        Vector3 target = new Vector3(character.transform.position.x, transform.position.y, character.transform.position.z);
        aimer.transform.position = target;
    }
    

}
