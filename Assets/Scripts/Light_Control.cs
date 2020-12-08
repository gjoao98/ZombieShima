using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Control : MonoBehaviour
{
    bool ligado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LigarLuz()
    {
        Invoke("LigarLuzMesmo", 1f);
    }

    void LigarLuzMesmo()
    {
        if (!ligado)
        {
            gameObject.SetActive(true);
            ligado = true;
        }
    }
}
