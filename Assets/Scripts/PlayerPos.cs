﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        gm.lastCheckPointPos.y = transform.position.y;
        transform.position = gm.lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
