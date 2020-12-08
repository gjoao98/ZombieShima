using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MedBox : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public GameObject message;
    public PainKiller pain;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pain.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKey(interactKey))
            {
                interactAction.Invoke();
                message.SetActive(false);
                pain.gameObject.SetActive(true);
                StartCoroutine(TurnOffTrigger(2f));
            }
        }
    } 
    
    public void Open()
    {
        anim.SetBool("OpenBox", true);
    }

    IEnumerator TurnOffTrigger(float time)
    {
        yield return new WaitForSeconds(2);
        GetComponent<Collider>().enabled = false;
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
