using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public LayerMask collisonMask;
    public Transform blade;
    public float Speed = 15;
    public ParticleSystem particle;

    private void Start()
    {
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
    }

    IEnumerator StopVFX()
    {
        yield return new WaitForSeconds(5f);
        particle.Stop();
    }
}
