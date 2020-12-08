using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Control_Gate_1 : MonoBehaviour
{
    Animator anim;
    public Botao_Gate_1 botao;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (botao.openDoor)
        {
            anim.SetBool("Open", true);
        }
    }
}