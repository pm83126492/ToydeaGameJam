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

    private float timer2;
    public Image filledImage;
    private bool isStartTimer;

    public GameObject Aiming;
    public GameObject ball;
    public Transform firepoint;
    public GameObject HeadBall;
    public GameObject ExploseEffect;
    public ParticleSystem SpeedEffect;

    bool CanAttack;
    bool HaveBall;

    AudioSource audioSource;
    public AudioClip Bomb, Speed,Fire;
    // Start is called before the first frame update
    void Start()
    {
        HeadBall.SetActive(false);
        CanAttack = false;
        HaveBall = false;
        player = GameObject.Find("Capsule");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal2");
        float y = Input.GetAxis("Vertical2");

        
        if (isStartTimer)
        {
            timer2 += Time.deltaTime;
            filledImage.fillAmount = (2 - timer2) / 2;
        }
        if (timer2 >= 2)
        {
            filledImage.fillAmount = 0;
            timer2 = 0;
            isStartTimer = false;
        }


        if (!GameManager.IsDie)
        {
            if (Input.GetKeyDown(KeyCode.RightShift) && CanAttack)
            {
                HeadBall.SetActive(false);
                audioSource.PlayOneShot(Fire);
                Instantiate(ball, firepoint.position, Aiming.transform.rotation);
                HaveBall = false;
                CanAttack = false;
            }

            if (Input.GetKeyDown(KeyCode.RightControl) && candash == 1)
            {
                isStartTimer = true;
                audioSource.PlayOneShot(Speed);
                candash = 0;
                fMoveSpeed *= 5;
                SpeedEffect.Play();
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (other.gameObject.GetComponent<Ball>().CanAttack == false&&!HaveBall)
            {
                audioSource.PlayOneShot(Bomb);
                HeadBall.SetActive(true);
                CanAttack = true;
                HaveBall = true;
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.CompareTag("BeginBall"))
        {
            if (!HaveBall)
            {
                audioSource.PlayOneShot(Bomb);
                HeadBall.SetActive(true);
                HaveBall = true;
                CanAttack = true;
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.CompareTag("Car"))
        {
            if (!GameManager.IsDie)
            {
                GameManager.IsDie = true;
                aiming.CatDieNumber += 1;
                Instantiate(ExploseEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }





}
