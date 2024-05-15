using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    [SerializeField] private InputActionReference _interact;
    
        public bool isInRange;
        public UnityEvent interactAction;

        public PlayerControler notify;
        // Start is called before the first frame update

        // Update is called once per frame
        
        private void OnEnable()
        {
            if (gameObject.activeInHierarchy)
            {
                _interact.action.performed += PerformInteract;
            }
        }

        private void OnDisable()
        {
            if (gameObject.activeInHierarchy)
            {
                _interact.action.performed -= PerformInteract;
            }
        }
        private void Update()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.gameObject.CompareTag("Player"))
            {
                isInRange = true;
            
            }
        }

        private void OnTriggerExit2D(Collider2D other) 
        {
            if(other.gameObject.CompareTag("Player"))
            {
                isInRange = false;
            }
        }

        public void PerformInteract(InputAction.CallbackContext obj)
        {
            if (!isInRange) return;
            if(isInRange)
            {
                Debug.Log("Interact Pressed");
                interactAction.Invoke();
            }
        }
}
