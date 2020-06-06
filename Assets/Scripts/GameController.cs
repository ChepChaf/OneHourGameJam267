using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Cube topCube;

    [SerializeField]
    Cube bottomCube;

    bool levelWon = false;

    public bool LevelWon { get => levelWon; }

    // Update is called once per frame
    void Update()
    {
        levelWon = topCube.OnGoal && bottomCube.OnGoal;

        if (LevelWon)
            Debug.Log("Level WON!");
    }
}
