using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public Transform B;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(B.position, Vector3.up, Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
}
