using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ZumbiHealth : MonoBehaviour
{
    [SerializeField]
    public int startingHealth = 100;

    public int currentHealth = 100;

    Animator anim;
    public AudioSource death;

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
        death.Stop();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            anim.SetBool("isDead", true);
            Die();
        }
    }

    public void Die()
    {
        death.Play();
        Destroy(gameObject, 5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
