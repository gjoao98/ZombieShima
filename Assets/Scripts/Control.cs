using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class Control : MonoBehaviour
{
    private Animator anim;
    public float moveSpeed = 0.3f;
    public float SideMoveSpeed = 0.1f;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim == null) return;

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        Move(x, y);

        if (Input.GetKey(interactKey))
        {
            interactAction.Invoke();
        }
        else
        {
            anim.SetBool("isInteracting", false);
        }
    }

    private void Move(float x, float y)
    {
        anim.SetFloat("Walk", y);
        anim.SetFloat("SideWalk", x);

        y *= Time.deltaTime * moveSpeed;
        transform.Translate(0, 0, y);

        x *= Time.deltaTime * SideMoveSpeed;
        transform.Translate(x, 0, 0);
    }

    public void InteractAction()
    {
        anim.SetBool("isInteracting", true);
    }
}
