using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CarStop"))
        {
            if (!GameManager.IsDie)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
