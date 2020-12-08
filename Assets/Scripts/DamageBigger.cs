using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class DamageBigger : MonoBehaviour
{
    public Slider healthBar;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Zombie2"))
        {
            healthBar.value -= 30;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
