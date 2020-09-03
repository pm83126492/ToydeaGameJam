using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public LayerMask collisonMask;
    public LayerMask playerMask;
    public LayerMask PotMask;
    public LayerMask UpMask;
    public Transform blade;
    public float Speed=50;
    public ParticleSystem particle;
    public GameObject DogExploseEffect;
    public GameObject CatExploseEffect;
    public bool CanAttack;

    private void Start()
    {
        CanAttack = true;
        particle.Play();
        StartCoroutine(StopVFX());
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        transform.Rotate(Vector3.forward * 5);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Time.deltaTime * Speed + 1f, collisonMask))
        {
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
        }

        if (Physics.Raycast(ray, out hit, Time.deltaTime * Speed + 1f, playerMask)&&CanAttack && !GameManager.IsDie)
        {
            GameManager.IsDie = true;
            Destroy(hit.collider.gameObject);
            if (hit.collider.gameObject.tag == "Cat")
            {
                Instantiate(CatExploseEffect, transform.position, transform.rotation);
                aiming2.DogDieNumber += 1;
            }
            else if (hit.collider.gameObject.tag == "Dog")
            {
                Instantiate(DogExploseEffect, transform.position, transform.rotation);
                aiming.CatDieNumber += 1;
            }
        }

       /* if (Physics.Raycast(ray, out hit, Time.deltaTime * Speed + 1f, PotMask))
        {
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
            Speed = 20f;
        }
        if (Physics.Raycast(ray, out hit, Time.deltaTime * Speed + 1f, UpMask))
        {
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
            Speed = 60f;
        }*/
    }

    IEnumerator StopVFX()
    {
        yield return new WaitForSeconds(2f);
        Speed = 20f;
        CanAttack = false;
        particle.Stop();
    }
}
