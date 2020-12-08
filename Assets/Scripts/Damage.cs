using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    public Slider healthBar;
    Animator anim;
    //public AudioSource manDeath;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            healthBar.value -= 10;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.value <= 0)
        {
            //manDeath.Play();
            anim.SetBool("isDead", true);
            Die();
        }
    }

    void Die()
    {
        StartCoroutine(Death(5f));
    }

    IEnumerator Death(float time)
    {
        yield return new WaitForSeconds(2);
        this.GetComponent<Weapon>().enabled = false;
        this.GetComponent<Control>().enabled = false;
        this.GetComponent<CharacterAiming>().enabled = false;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
