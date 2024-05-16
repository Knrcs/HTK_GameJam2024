using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class GameManager : MonoBehaviour
{
  
  [SerializeField] private PlayerInput _playerInput;
  public PlayerControler player;
  public GameObject pauseMenu;
  
  public static GameManager instance;
  [Header("Interaction")] [SerializeField]
  private GameObject _interactUI;

  [Header("UI")] 
  [SerializeField] private TMP_Text _scoreText;
  [SerializeField] private TMP_Text _scoreTextEnd;
  [SerializeField] private TMP_Text _highScoreText;
  [SerializeField] private TMP_Text _customerServedText;
  [SerializeField] private GameObject _gameOverScreen;

  [Header("Pause")] 
  public bool paused;

  [Header("DinerTables")] 
  public bool table01 = false;
  public bool table02 = false;
  public bool table03 = false;

  [Header("Score Stuff")] 
  public int scorePoints;
  public int customerServed;
  public int highScore;

  public bool isAllowedToPause;
  public GameObject retryButton;
  


  private void Awake()
  {
    instance = this;
  }

  private void Start()
  {
    pauseMenu.GetComponent<PauseMenu>().musicEventInstance.setParameterByName("Parameter 1", 0);
    pauseMenu.GetComponent<PauseMenu>().atmoEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    ShowInteractUI(false);
    isAllowedToPause = true;
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
  }

  private void Update()
  {
    UpdateScore(scorePoints);
  }
  

  public void EndScreenValues()
  {
    pauseMenu.GetComponent<PauseMenu>().musicEventInstance.setParameterByName("Parameter 1", 1);
    isAllowedToPause = false;
    _gameOverScreen.SetActive(true);
    _scoreTextEnd.text = scorePoints.ToString();
    _customerServedText.text = customerServed.ToString();
    pauseMenu.GetComponent<PauseMenu>().HideCursor();
  }
  public void NewGame()
  {
    SceneManager.LoadScene(1);
  }
  
  public void ShowInteractUI(bool show)
  {
    _interactUI.SetActive(show);
  }

  public void UpdateScore(int score)
  {
    
    _scoreText.text = score.ToString();
  }
  
  public void PauseGame()
  {
    paused = true;
    _playerInput.SwitchCurrentActionMap("UI");
  }
  
  public void ResumeGame()
  {
    paused = false;
    _playerInput.SwitchCurrentActionMap("Player");
  }

  public void OpenMenu()
  {
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.Confined;
    _playerInput.SwitchCurrentActionMap("UI");
  }
  
  public void CloseMenu()
  {
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
    _playerInput.SwitchCurrentActionMap("Player");
  }
  
  public void PlayThisOneShot(string oneShot)
  {
    RuntimeManager.PlayOneShot(oneShot);
        
  }
  
}
