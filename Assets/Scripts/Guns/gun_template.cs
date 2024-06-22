using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_template : MonoBehaviour
{
    public float damage = 10f;
    public float distance = 100f;
    public float fireSpeed = 1f;
    public float bulletForce = 30f;

    public Camera fpsCam;

    //public ParticleSystem ates;
    //public GameObject vurusEfekti;


    private float nextFire = 0f;
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFire)
        {
            nextFire = Time.time + 1f / fireSpeed;
            Shoot();
        }
    }

    void Shoot()
    {
        //ates.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, distance))
        {
            Debug.Log(hit.transform.name);

            if (hit.transform.TryGetComponent<health>(out health obj_health))
            {
                obj_health.takeDamage(1);
            }

            //if (hit.rigidbody != null)
            //{
            //    hit.rigidbody.AddForce(-hit.normal * bulletForce);
            //}
            
        }
    }
}
