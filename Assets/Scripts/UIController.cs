﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameController _gameController;
    // Start is called before the first frame update

    [SerializeField]
    Text wonText;

    [SerializeField]
    Text loseText;

    private void OnEnable()
    {
        GameController.lostGame += Lose;
    }

    private void OnDisable()
    {
        GameController.lostGame -= Lose;
    }

    void Lose()
    {
        if (!loseText.enabled)
            loseText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameController.LevelWon && !wonText.enabled)
            wonText.enabled = true;
    }
}
