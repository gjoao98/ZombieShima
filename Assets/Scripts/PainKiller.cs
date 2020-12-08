using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PainKiller : MonoBehaviour
{
    public Slider HealthBar;
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
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
            if (Input.GetKey(interactKey))
            {
                interactAction.Invoke();
            }
        }
    }

    public void UsePainKiller()
    {
        if (HealthBar.value < 100)
        {
            HealthBar.value += 30;
            Destroy(gameObject);
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
