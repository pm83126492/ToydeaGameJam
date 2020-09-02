using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;

public class character1 : MonoBehaviour
{
    public float fMoveSpeed;
    public GameObject player;
    public int candash = 1;
    public float timer = 0;

    public GameObject Aiming;
    public GameObject ball;
    public Transform firepoint;
    public GameObject HeadBall;

    bool CanAttack;

    // Start is called before the first frame update
    void Start()
    {
        HeadBall.SetActive(false);
        CanAttack = false;
        player = GameObject.Find("Capsule");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal2");
        float y = Input.GetAxis("Vertical2");


        if (Input.GetKeyDown(KeyCode.RightShift) && CanAttack)
        {
            HeadBall.SetActive(false);
            Instantiate(ball, firepoint.position, Aiming.transform.rotation);
            CanAttack = false;
        }

        if (Input.GetKeyDown(KeyCode.RightControl) && candash == 1)
        {
            candash = 0;
            fMoveSpeed *= 8;
        }
        else if ((x != 0 || y != 0))

        {
           //Debug.Log(x);
            Vector3 target = transform.position + new Vector3(x, 0, y);
            transform.LookAt(target);
            transform.Rotate(0, 90, 0);
            transform.Translate(Vector3.left * Time.deltaTime * fMoveSpeed);
        }
        

        if (candash == 0)
        {
            timer += Time.deltaTime;

        }

        if (timer > 0.1f)
        {
            fMoveSpeed = 25;
        }
        if (timer > 2f)
        {
            timer = 0;
            candash = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (other.gameObject.GetComponent<Ball>().CanAttack == false)
            {
                HeadBall.SetActive(true);
                CanAttack = true;
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.CompareTag("BeginBall"))
        {
            HeadBall.SetActive(true);
            CanAttack = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Car"))
        {

            Destroy(other.gameObject);
        }
    }





}
