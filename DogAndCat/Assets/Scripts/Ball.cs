using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public LayerMask collisonMask;
    public LayerMask playerMask;
    public Transform blade;
    public float Speed = 15;
    public ParticleSystem particle;
    public GameObject ExploseEffect;
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
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Time.deltaTime * Speed + 1f, collisonMask))
        {
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
        }

        if (Physics.Raycast(ray, out hit, Time.deltaTime * Speed + 1f, playerMask)&&CanAttack)
        {
            if (hit.collider.name == "cat")
            {

            }
            Instantiate(ExploseEffect, transform.position, transform.rotation);
            Destroy(hit.collider.gameObject);
            StartCoroutine(Restart());
        }
        
    }

    IEnumerator StopVFX()
    {
        yield return new WaitForSeconds(5f);
        CanAttack = false;
        particle.Stop();
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("DogAndCat");
    }
}
