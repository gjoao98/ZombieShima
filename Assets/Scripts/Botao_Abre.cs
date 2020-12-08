using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Botao_Abre : MonoBehaviour
{
    public Gerador gerador;
    public bool openDoor;
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public GameObject message;
    public GameObject messagePowerOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            message.SetActive(true);
            if (gerador.isTurnedOn)
            {
                message.SetActive(false);
                messagePowerOn.SetActive(true);
                if (!openDoor)
                {
                    if (Input.GetKey(interactKey))
                    {
                        interactAction.Invoke();
                    }
                }
            }
        }
        else
        {
            message.SetActive(false);
            messagePowerOn.SetActive(false);
        }
    }

    public void OpenDoor()
    {
        if (!openDoor)
        {
            openDoor = true;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player is On Trigger now");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player is not On Trigger now");
        }
    }
}
