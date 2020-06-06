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

    private void OnEnable()
    {
        Cube.collidedWithObstacle += Lost;
    }

    private void OnDisable()
    {
        Cube.collidedWithObstacle -= Lost;
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
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (LevelWon)
            Time.timeScale = 0;
    }
}
