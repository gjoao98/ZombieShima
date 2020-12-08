using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emergency_Lights : MonoBehaviour
{
    bool desligado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DesligarLuzDeEmergencia()
    {
        Invoke("DesligarLuzMesmo", 1f);
    }

    void DesligarLuzMesmo()
    {
        if (!desligado)
        {
            gameObject.SetActive(false);
            desligado = false;
        }
    }
}
