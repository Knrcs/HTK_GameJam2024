using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScore : MonoBehaviour
{
    private GameManager _gameManager;
    private CustomerLogic _customerLogic;
    private PlayerControler _playerController;
    public float maxScore;
    public int score;
    private float scoreDrain;
    public float timeTilMad;
    private float _timeTilMadDefault;

    public void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>();
        _customerLogic = gameObject.GetComponent<CustomerLogic>();
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        _timeTilMadDefault = timeTilMad;
        scoreDrain = maxScore / timeTilMad;
    }

    private void Update()
    {
        timeTilMad -= Time.deltaTime;
        maxScore -= scoreDrain * Time.deltaTime;
        if (timeTilMad <= 0)
        {
            _playerController.health--;
            _customerLogic._leaveTheStore = true;
            timeTilMad = _timeTilMadDefault;
        }
    }

    public void QuestCompleted()
    {
        score = (int)Math.Round(maxScore, 0);
        _gameManager.customerServed++;
        _gameManager.scorePoints += score;
        _customerLogic._leaveTheStore = true;
    }

    public void CheckOrder()
    {
        if (_playerController.bananaCanRay && _customerLogic.bananaCanRay)
        {
            QuestCompleted();
            _playerController.ClearHand();
            Debug.Log("Customor Order is Correct, proceed leaving");
            //TODO: Play sound
        }
        if (_playerController.bananaBatterySniperShovel && _customerLogic.bananaBatterySniperShovel)
        {
            QuestCompleted();
            _playerController.ClearHand();
            Debug.Log("Customor Order is Correct, proceed leaving");

            //TODO: Play sound
        }
        if (_playerController.bananaBatterySniper && _customerLogic.bananaBatterySniper)
        {
            QuestCompleted();
            _playerController.ClearHand();
            Debug.Log("Customor Order is Correct, proceed leaving");

            //TODO: Play sound
        }
        if (_playerController.bananaCanGatlin && _customerLogic.bananaCanGatlin)
        {
            QuestCompleted();
            _playerController.ClearHand();
            Debug.Log("Customor Order is Correct, proceed leaving");

            //TODO: Play sound
        }
        if (_playerController.drillToasterSniperSpring && _customerLogic.drillToasterSniperSpring)
        {
            QuestCompleted();
            _playerController.ClearHand();
            Debug.Log("Customor Order is Correct, proceed leaving");

            //TODO: Play sound
        }
        if (_playerController.drillCanRay && _customerLogic.drillCanRay)
        {
            QuestCompleted();
            _playerController.ClearHand();
            Debug.Log("Customor Order is Correct, proceed leaving");

            //TODO: Play sound
        }
        if (_playerController.drillGatlinShovel && _customerLogic.drillGatlinShovel)
        {
            QuestCompleted();
            _playerController.ClearHand();
            Debug.Log("Customor Order is Correct, proceed leaving");

            //TODO: Play sound
        }
        if (_playerController.drillRayShovel && _customerLogic.drillRayShovel)
        {
            QuestCompleted();
            _playerController.ClearHand();
            Debug.Log("Customor Order is Correct, proceed leaving");

            //TODO: Play sound
        }
        if (_playerController.dryerGatlinShovel && _customerLogic.dryerGatlinShovel)
        {
            QuestCompleted();
            _playerController.ClearHand();
            Debug.Log("Customor Order is Correct, proceed leaving");

            //TODO: Play sound
        }
        if (_playerController.dryerCanSniperSpring && _customerLogic.dryerCanSniperSpring)
        {
            QuestCompleted();
            _playerController.ClearHand();
            Debug.Log("Customor Order is Correct, proceed leaving");

            //TODO: Play sound
        }
        if (_playerController.dryerCanRaySpartula && _customerLogic.dryerCanRaySpartula)
        {
            QuestCompleted();
            _playerController.ClearHand();
            Debug.Log("Customor Order is Correct, proceed leaving");
            //TODO: Play sound
        }
        else
        {
            //TODO: Error Sound
            Debug.Log("Customor Order is Incorrect");
        }
        Debug.Log("Script works");
    }

}
