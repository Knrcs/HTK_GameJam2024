using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private InputAction _interactAction;
    public Interactable _currentInteractable;
    private Animator _animator;
    
    private void Interact(InputAction.CallbackContext obj)
    {
        if (_currentInteractable == null) {return;}

        if (_currentInteractable.interactAnimation != "")
        {
            _animator.Play(_currentInteractable.interactAnimation);
        }
        
        _currentInteractable.onInteract.Invoke();
    }
    
    
}
