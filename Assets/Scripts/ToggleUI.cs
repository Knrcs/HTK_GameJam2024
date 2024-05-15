using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public GameObject _UI;
    public GameManager gameManager;
    public PlayerControler _PlayerControler;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !_PlayerControler.handSlot)
        {
            _UI.SetActive(true);
            gameManager.OpenMenu();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _UI.SetActive(false);
            gameManager.CloseMenu();
        }
    }
}
