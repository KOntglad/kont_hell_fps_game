using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_template : MonoBehaviour
{
    public float damage = 10f;
    public float distance = 100f;
    public float fireSpeed = 1f;
    public float bulletForce = 30f;

    public int bullet_now, bullet_max;

    public Camera fpsCam;
    public Animator gun_animation;

    public interface_manager gun_ui;

    //public ParticleSystem ates;
    //public GameObject vurusEfekti;


    private void Start()
    {
        gun_ui.UI_texts[1].text = bullet_now.ToString("0");
        gun_ui.UI_texts[2].text = bullet_max.ToString("0");
    }

    private float nextFire = 0f;
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFire && bullet_now > 0)
        {
            gun_ui.UI_texts[1].text = bullet_now.ToString("0");
            nextFire = Time.time + 1f / fireSpeed;

            Shoot();
        }
        if(bullet_now <= 0) 
        {
            gun_animation.ResetTrigger("shoot");
            gun_animation.SetBool("isEmpty", true);
            nextFire = Time.time + 1f / 3 * fireSpeed;
            bullet_now = bullet_max;
        }
        if(bullet_now == bullet_max && Time.time >= nextFire) 
        {
            gun_animation.SetBool("isEmpty", false);
            gun_ui.UI_texts[1].text = bullet_now.ToString("0");
            --bullet_now;
        }
    
    }

    void Shoot()
    {
        //ates.Play();
        
        gun_animation.SetTrigger("shoot");
        --bullet_now;

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
