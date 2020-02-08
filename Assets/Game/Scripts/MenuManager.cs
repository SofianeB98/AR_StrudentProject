﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class MenuManager : MonoBehaviour
{
    [Header("Buttons")] 
    [SerializeField] private Button[] niveauxButtons;
    private int[] activeNiveaux;
    
    [Header("Panels")] 
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject niveauxPanel;
    [SerializeField] private GameObject gameModePanel;

    [Header("Animations")] 
    [SerializeField] private Animator anim;
    [SerializeField] private string niveauTriggerName = "Niveau";
    [SerializeField] private string gameModeTriggerName = "Game mode";

    private void OnEnable()
    {
        if(DataManager.Instance != null)
            DataManager.Instance.onDataLoaded.AddListener(EnableButtonLevel);
    }

    private void OnDisable()
    {
        if(DataManager.Instance != null)
            DataManager.Instance.onDataLoaded.RemoveListener(EnableButtonLevel);
    }
    
    public void EnableNiveauPanel()
    {
        this.anim.SetTrigger(this.niveauTriggerName);
    }

    public void EnableGameModePanel()
    {
        this.anim.SetTrigger(this.gameModeTriggerName);
    }

    public void EnableCreditsPanel()
    {

    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void EnableButtonLevel(int index, bool value)
    {
        niveauxButtons[index].interactable = value;
    }
}