using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    Animator anim;
    public AudioSource groaing;
    public ZumbiHealth health;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        groaing.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 50)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                        Quaternion.LookRotation(direction), 0.11f);


            anim.SetBool("isIdle", false);
            if (direction.magnitude > 1.3f)
            {
                agent.SetDestination(player.position);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }

        if (health.currentHealth <= 0)
        {
            StartCoroutine(Death(0.1f));
        }
    }

    IEnumerator Death(float time)
    {
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<Zombie>().enabled = false;
    }
}
