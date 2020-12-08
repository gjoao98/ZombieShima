using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class Gerador : MonoBehaviour
{
    public GameObject gerador;
    public bool isTurnedOn = false;
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public Light_Control luzes;
    public Emergency_Lights luzesDeEmergencia;
    public GameObject message;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (!isTurnedOn)
            {
                if (Input.GetKey(interactKey))
                {
                    interactAction.Invoke();
                }
            }
        }
    }

    public void TurnOnEnergy()
    {
        if (!isTurnedOn)
        {
            isTurnedOn = true;
            luzes.LigarLuz();
            luzesDeEmergencia.DesligarLuzDeEmergencia();
            Debug.Log("Energy is now turned On");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            message.SetActive(true);
            isInRange = true;
            Debug.Log("Player is On Trigger now");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            message.SetActive(false);
            isInRange = false;
            Debug.Log("Player is not On Trigger now");
        }
    }
}
