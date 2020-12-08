using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{
    public AudioSource manDeath;
    public Damage dano;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dano.healthBar.value <= 0)
        {
            manDeath.Play();
        }
        else
        {
            manDeath.Stop();
        }
    }
}
