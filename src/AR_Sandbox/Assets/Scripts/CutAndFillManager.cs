﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //Need this for calling UI scripts

public class CutAndFillManager : MonoBehaviour {

    [SerializeField]
    Transform UIPanel; //Will assign our panel to this variable so we can enable/disable it

    void Start()
    {
        UIPanel.gameObject.SetActive(false); //make sure our pause menu is disabled when scene starts
    }

    void Update()
    {

    }

    public void Pause()
    {
        UIPanel.gameObject.SetActive(true); //turn on the pause menu
    }

    public void UnPause()
    {
        UIPanel.gameObject.SetActive(false); //turn off pause menu
    }
}
