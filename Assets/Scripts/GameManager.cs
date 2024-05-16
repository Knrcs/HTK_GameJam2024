using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using FMOD.Studio;
using FMODUnity;

public class GameManager : MonoBehaviour
{
  
  [SerializeField] private PlayerInput _playerInput;
  public PlayerControler player;
  
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
  


  private void Awake()
  {
    instance = this;
  }

  private void Start()
  {
    ShowInteractUI(false);
  }

  private void Update()
  {
    UpdateScore(scorePoints);
  }

  public void EndScreenValues()
  {
    _gameOverScreen.SetActive(true);
    _scoreTextEnd.text = scorePoints.ToString();
    _highScoreText.text = highScore.ToString();
    _customerServedText.text = customerServed.ToString();
  }
  public void NewGame()
  {
    if (highScore >= scorePoints)
    {
      highScore = scorePoints;
    }
    customerServed = 0;
    scorePoints = 0;
    _gameOverScreen.SetActive(false);
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
    Cursor.lockState = CursorLockMode.Confined;
    _playerInput.SwitchCurrentActionMap("UI");
  }
  
  public void CloseMenu()
  {
    Cursor.lockState = CursorLockMode.Locked;
    _playerInput.SwitchCurrentActionMap("Player");
  }
  
  public void PlayThisOneShot(string oneShot)
  {
    RuntimeManager.PlayOneShot(oneShot);
        
  }
  
}
