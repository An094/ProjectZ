using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject MenuObj;
    [SerializeField] private Image Background;
    [SerializeField] private Button BtnContinue;
    [SerializeField] private Button BtnMenu;
    [SerializeField] private Player player;

    private void OnEnable()
    {
        BtnContinue.onClick.AddListener(OnBtnContinueClicked);
        BtnMenu.onClick.AddListener(OnBtnMenuClicked);
    }

    private void OnDisable()
    {
        BtnContinue.onClick.RemoveAllListeners();
        BtnMenu.onClick.RemoveAllListeners();
    }

    private void Start()
    {
        IsMenuShowing = false;
        HideMenu();
    }

    private bool IsMenuShowing = false;
    public void ShowMenu(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            ShowHideMenu();
        }
    }

    public void ShowHideMenu()
    {
        if(!IsMenuShowing)
        {
            ShowMenu();  
        }
        else
        {
            HideMenu();
        }
        IsMenuShowing = !IsMenuShowing;
    }

    private void ShowMenu()
    {
        MenuObj.SetActive(true);
        Time.timeScale = 0f;
        player.enabled = false;
    }

    private void HideMenu()
    {
        MenuObj.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
    }

    private void OnBtnContinueClicked()
    {
        if(IsMenuShowing)
        {
            player.InputHandler.UseJumpInput();
            HideMenu();
        }
    }

    private void OnBtnMenuClicked()
    {
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
