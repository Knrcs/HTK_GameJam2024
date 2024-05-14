using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private InputActionReference _esc;
    private GameObject _optionsMenu;
    public Button audioButton;
    public Button germanAudioButton;
    public Button optionsButton;
    public Button startButton;
    public Button germanStartButton;
    public bool controllerActive;
    public bool mouseActive;
    public bool keyboardActive;
    public GameObject germanButtons;
    public GameObject englishButtons;
    public EventReference musicEventReference;
    public EventInstance musicEventInstance;
    
    private float _idleTime = 0f;
    private float _cursorHideDelay = 3f;

    public Texture2D cursorTex;

    private void Awake()
    {
        if (PlayerPrefs.GetFloat("masterValue") < 0.1f)
        {
            PlayerPrefs.SetFloat("masterValue", 0.5f);
            PlayerPrefs.SetFloat("musicValue", 0.5f);
            PlayerPrefs.SetFloat("sfxValue", 0.5f);
            PlayerPrefs.SetFloat("ambienceValue", 0.5f);   
        }
    }

    private void Start()
    {
        musicEventInstance = RuntimeManager.CreateInstance(musicEventReference);
        musicEventInstance.start();

        RuntimeManager.CreateInstance("event:/GameState").start();
        RuntimeManager.CreateInstance("event:/GameState").start();
        
        Cursor.SetCursor(cursorTex, Vector2.zero, CursorMode.ForceSoftware);
        _optionsMenu = GameObject.Find("OptionsMenu");
        _optionsMenu.SetActive(false);
        HideCursor();
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("Language") == 0)
        {
            germanButtons.SetActive(false);
            englishButtons.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Language") == 1)
        {
            englishButtons.SetActive(false);
            germanButtons.SetActive(true);
        }
        
        if (!controllerActive && Gamepad.current != null && (Gamepad.current.leftStick.ReadValue() != Vector2.zero || Gamepad.current.rightStick.ReadValue() != Vector2.zero))
        {
            keyboardActive = false;
            mouseActive = false;
            controllerActive = true;
            Debug.Log("Controller movement detected");
        }

        if (!mouseActive && Mouse.current != null && Mouse.current.delta.ReadValue() != Vector2.zero)
        {
            keyboardActive = false;
            mouseActive = true;
            controllerActive = false;
            Debug.Log("Mouse movement detected");
        }

        if (!keyboardActive && Keyboard.current != null && (Keyboard.current.anyKey.isPressed))
        {
            keyboardActive = true;
            mouseActive = false;
            controllerActive = false;
            Debug.Log("Keyboard movement detected");
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
                Debug.Log("WORKS(MOUSE DOESNT MOVE)");
                HideCursor();
            }
        }

        if (keyboardActive || controllerActive)
        {
            HideCursor();
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

    private void HideCursor()
    {
        if (Cursor.visible)
        {
            if (PlayerPrefs.GetInt("Language") == 0)
            {
                if (startButton != null){ startButton.Select(); }
            }
            else if (PlayerPrefs.GetInt("Language") == 1)
            {
                if (germanStartButton != null){ germanStartButton.Select(); }
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
        musicEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void OpenCloseOptions()
    {
        _optionsMenu.SetActive(_optionsMenu.activeSelf ? false : true);
        
        if (_optionsMenu.activeSelf && !Cursor.visible)
        {
            if (PlayerPrefs.GetInt("Language") == 0)
            {
                audioButton.Select();
            }
            else if (PlayerPrefs.GetInt("Language") == 1)
            {
                germanAudioButton.Select();
            }
            
        }
    }

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            _esc.action.performed += PerformEsc;
        }
    }

    private void PerformEsc(InputAction.CallbackContext obj)
    {
        if (_optionsMenu.activeSelf)
        {
            OpenCloseOptions();
        } 
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator CursorInvisibleAfterFewSeconds()
    {
        yield return new WaitForSeconds(3.0f);

        Cursor.visible = false;
    }
    
    public void PlayThisOneShot(string oneShot)
    {
        RuntimeManager.PlayOneShot(oneShot);
        
    }
}
