﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefHolder : MonoBehaviour
{


    public static RefHolder instance;



    public PlayerController playerController;
    public LevelGenaration levelGenaration;
    public Gameplay gameplay;
    public UICon uiCon;
    public BendingManager bendingManager;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
