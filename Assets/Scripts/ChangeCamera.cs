using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public CinemachineVirtualCamera activeCamera;
    public CinemachineVirtualCamera inactiveCamera;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collisison happened");

        if (other.gameObject.CompareTag("Player"))
        {
            activeCamera.Priority = 10;
            inactiveCamera.Priority = 0;
        }
    }
}
