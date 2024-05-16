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

  [Header("UI")] [SerializeField] 
  private TMP_Text _score;

  [Header("Pause")] 
  public bool paused;

  [Header("DinerTables")] 
  public bool table01 = false;
  public bool table02 = false;
  public bool table03 = false;


  private void Awake()
  {
    instance = this;
  }

  private void Start()
  {
    ShowInteractUI(false);
  }
  
  public void ShowInteractUI(bool show)
  {
    _interactUI.SetActive(show);
  }

  public void UpdateScore(int score)
  {
    
    _score.text = score.ToString();
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
