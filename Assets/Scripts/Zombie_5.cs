using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Zombie_5 : MonoBehaviour
{
    public Transform player;
    Animator anim;
    public AudioSource groaing;

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
            if (direction.magnitude > 3f)
            {
                anim.SetBool("isIdle", true);
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
    }
}
