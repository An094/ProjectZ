using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button BtnStart;
    [SerializeField] private Button BtnContinue;
    private EventSystem EventSystem;

    private void Awake()
    {
        EventSystem = EventSystem.current;
    }

    private void OnEnable()
    {
        BtnContinue.onClick.AddListener(Continue);
        BtnStart.onClick.AddListener(NewGame);
    }

    private void OnDisable()
    {
        BtnContinue.onClick.RemoveAllListeners();
        BtnStart.onClick.RemoveAllListeners();
    }

    private void Start()
    {
        EventSystem.firstSelectedGameObject = BtnContinue.gameObject;
    }

    private void NewGame()
    {
        DataPersistenceManager.instance.NewGame();
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("Game");
    }

    private void Continue()
    {
        SceneManager.LoadSceneAsync("Game");
    }    
}
