using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class PauseMenu : MonoBehaviour
{ 
    public EventReference musicEventReference;
    public EventReference atmoEventReference;
    public EventInstance musicEventInstance;
    public EventInstance atmoEventInstance;
    
    [SerializeField] private InputActionReference _esc1;
    [SerializeField] private InputActionReference _esc2;
    [SerializeField] private GameObject _content;

    public PlayerInput player;
    public bool isPaused;
    
    public bool controllerActive;
    public bool mouseActive;
    public bool keyboardActive;
    
    [Header("Buttons")]
    public Button startButton;
    public Slider masterSlider;
    
    [Header("Pause Menu")] 
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    
    private InputAction _openClosePauseMenu;
    private float _idleTime = 0f;
    private float _cursorHideDelay = 3f;
    
    private void Start()
    {
        isPaused = false;
        
        if (pauseMenu.activeSelf)
        {
            optionsMenu.SetActive(false);
            pauseMenu.SetActive(false);
        }
        
        musicEventInstance = RuntimeManager.CreateInstance(musicEventReference);
        musicEventInstance.start();
        atmoEventInstance = RuntimeManager.CreateInstance(atmoEventReference);
        atmoEventInstance.start();
    }
    
    
    
    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            _esc1.action.performed += PerformEsc;
            _esc2.action.performed += PerformEsc;
        }
    }

    private void OnDisable()
    {
        if (gameObject.activeInHierarchy)
        {
            _esc1.action.performed -= PerformEsc;
            _esc2.action.performed -= PerformEsc;
        }
    }

    private void Update()
    {
        if (isPaused || !GameManager.instance.isAllowedToPause || GameManager.instance.boxOpen)
        {
            if (!controllerActive && Gamepad.current != null && (Gamepad.current.leftStick.ReadValue() != Vector2.zero || Gamepad.current.rightStick.ReadValue() != Vector2.zero))
            {
                keyboardActive = false;
                mouseActive = false;
                controllerActive = true;
            }

            if (!mouseActive && Mouse.current != null && Mouse.current.delta.ReadValue() != Vector2.zero)
            {
                keyboardActive = false;
                mouseActive = true;
                controllerActive = false;
            }

            if (!keyboardActive && Keyboard.current != null && (Keyboard.current.anyKey.isPressed))
            {
                keyboardActive = true;
                mouseActive = false;
                controllerActive = false;
            }
        
            if (mouseActive)
            {
                ShowCursor();
                _idleTime = 0f;
            }
            else
            {
                _idleTime += Time.unscaledDeltaTime;
                if (_idleTime >= _cursorHideDelay) 
                {
                    HideCursor();
                }
            }

            if (keyboardActive || controllerActive)
            {
                HideCursor();
            }
        }
        
    }

    private void ShowCursor()
    {
        if (!Cursor.visible)
        {
            EventSystem.current.SetSelectedGameObject(null);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void HideCursor()
    {
        if (Cursor.visible)
        {
            if (optionsMenu.activeSelf || !GameManager.instance.isAllowedToPause)
            {
                if (!GameManager.instance.isAllowedToPause)
                {
                    GameManager.instance.retryButton.GetComponent<Button>().Select();
                }
                else if (GameManager.instance.isAllowedToPause)
                {
                    masterSlider.Select();
                }
            }
            else if (pauseMenu.activeSelf)
            {
                startButton.Select();
            }
            else if (GameManager.instance.stock.activeSelf)
            {
                GameManager.instance.stockButton.GetComponent<Button>().Select();
            }
            else if (GameManager.instance.barrel.activeSelf)
            {
                GameManager.instance.barrelButton.GetComponent<Button>().Select();
            }
            else if (GameManager.instance.bodyBox.activeSelf)
            {
                GameManager.instance.bodyButton.GetComponent<Button>().Select();
            }
            else if (GameManager.instance.magazine.activeSelf)
            {
                GameManager.instance.magazineButton.GetComponent<Button>().Select();
            }
            
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    
    public void NoButtonSelect()
    {
        if (Cursor.visible)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
        
    }
    
    public void StartGame()
    { 
        // Check if the PauseMenu instance is still valid
        if (this != null)
        {
            isPaused = !isPaused;
            
            pauseMenu?.SetActive(isPaused);

            if (isPaused)
            {
                _content.SetActive(false);
                optionsMenu.SetActive(false);
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Pause", 1);
                if (GameManager.instance.stock.activeSelf || GameManager.instance.barrel.activeSelf || GameManager.instance.bodyBox.activeSelf || GameManager.instance.magazine.activeSelf)
                {
                    if (controllerActive || keyboardActive)
                    {
                        startButton.Select();   
                    }
                }
                player.SwitchCurrentActionMap("UI");
            }
            else
            {
                optionsMenu.SetActive(false);
                _content.SetActive(true);
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Pause", 0);
                if (GameManager.instance.stock.activeSelf)
                {
                    GameManager.instance.stockButton.GetComponent<Button>().Select();
                }
                else if (GameManager.instance.barrel.activeSelf)
                {
                    GameManager.instance.barrelButton.GetComponent<Button>().Select();
                }
                else if (GameManager.instance.bodyBox.activeSelf)
                {
                    GameManager.instance.bodyButton.GetComponent<Button>().Select();
                }
                else if (GameManager.instance.magazine.activeSelf)
                {
                    GameManager.instance.magazineButton.GetComponent<Button>().Select();
                }
                else
                {
                    player.SwitchCurrentActionMap("Player");
                }
            }
            
            Time.timeScale = isPaused ? 0f : 1f; 
        }
    }
    
    private void PerformEsc(InputAction.CallbackContext obj)
    {
        if (GameManager.instance.isAllowedToPause)
        {
            StartGame(); 
        }
    }
    
    public void OpenCloseOptions()
    {
        if (isPaused)
        {
            if (!optionsMenu.activeSelf)
            {
                Debug.Log("Gets active");
                optionsMenu.SetActive(true);
                pauseMenu.SetActive(false);

                if (!Cursor.visible)
                {
                    masterSlider.Select();
                }
            }
            else
            {
                Debug.Log("Gets Inactive");
                optionsMenu.SetActive(false);
                pauseMenu.SetActive(true);

                if (!Cursor.visible)
                {
                    startButton.Select();
                }
            }
        }
    }

    public void QuitGame()
    {
        musicEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        atmoEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Pause", 0);
        StartCoroutine(MainMenuCoroutine());
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }

    private IEnumerator MainMenuCoroutine()
    {
        // Check if the PauseMenu instance is still valid
        if (this != null)
        {
            Time.timeScale = 1f;
            GameManager gameManager = GetComponentInParent<GameManager>();

            /*if (gameManager != null)
            { 
                gameManager.musicEventInstance.stop(STOP_MODE.IMMEDIATE);
            }*/

            if (player != null)
            {
                player.SwitchCurrentActionMap("MainMenu");
            }

            yield return new WaitForSeconds(0.1f);

            SceneManager.LoadScene("MainMenu");
        }
    }
}
