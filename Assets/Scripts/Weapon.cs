using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 1.5f)]
    private float fireRate = 1;

    [SerializeField]
    [Range(1, 100)] private int damage = 1;

    Animator anim;

    [SerializeField]
    private ParticleSystem muzzleParticle;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private AudioSource gunFireSource;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if( timer >= fireRate)
        {
            if(Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();    
            }
            else
            {
                anim.SetBool("isFiring", false);
                gunFireSource.Stop();
            }
        }
    }

    private void FireGun()
    {
        anim.SetBool("isFiring", true);
        muzzleParticle.Play();
        gunFireSource.Play();

        //Debug.DrawRay(firePoint.position, firePoint.forward);
        Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);
        //Debug.DrawRay(transform.position, transform.forward * 100, Color.red, 2f);

        Ray ray = new Ray(firePoint.position, firePoint.forward);
        //Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        //Ray ray = Camera.main.ViewportPointToRay( new Vector3 (1, 1, 1));

        RaycastHit hitInfo;
        

        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<ZumbiHealth>();
            if(health != null)
            {
                Debug.Log("Acertou");
                health.TakeDamage(damage);
            }
        }
    }
}
