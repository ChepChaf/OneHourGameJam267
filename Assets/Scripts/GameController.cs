using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public delegate void LostGame();
    public static event LostGame lostGame;

    [SerializeField]
    Cube topCube;

    [SerializeField]
    Cube bottomCube;

    bool levelWon = false;
    bool lost = false;

    public bool LevelWon { get => levelWon; }

    private void Start()
    {
        Cube.collidedWithObstacle += Lost;
    }

    private void Lost()
    {
        Debug.Log("Lost");
        if (lostGame != null)
            lostGame();

        this.lost = true;
    }

    // Update is called once per frame
    void Update()
    {
        levelWon = topCube.OnGoal && bottomCube.OnGoal;

        if (lost)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }

        if (LevelWon)
            Time.timeScale = 0;
    }
}
