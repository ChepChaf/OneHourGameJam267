using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    Cube topCube;

    [SerializeField]
    Cube bottomCube;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x != 0)
        {
            if (x > 0)
                x = 1;
            else
                x = -1;

            topCube.SetDirection(new Vector2(x, 0));
            bottomCube.SetDirection(new Vector2(x, 0));
        }
        else if (y != 0)
        {
            if (y > 0)
                y = 1;
            else
                y = -1;

            topCube.SetDirection(new Vector2(0, -y));
            bottomCube.SetDirection(new Vector2(0, y));
        }
    }
}
