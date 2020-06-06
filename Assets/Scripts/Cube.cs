using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public delegate void CollidedWithObstacle();
    public static event CollidedWithObstacle collidedWithObstacle;

    [SerializeField]
    float c_speed = 200;

    bool m_onGoal = false;
    bool m_isMoving = false;
    Vector2 m_direction;

    public bool OnGoal
    {
        get
        {
            return m_onGoal;
        }
    }
    private void Update()
    {
        if (m_isMoving && m_direction != Vector2.zero)
        {
            transform.position += new Vector3(m_direction.x, 0, m_direction.y) * c_speed * Time.deltaTime; 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            return;

        if (collision.gameObject.tag == "Obstacle")
        {
            if (collidedWithObstacle != null)
                collidedWithObstacle();
        }

        Debug.Log("Collided");
        if (m_isMoving)
            m_isMoving = false;
        transform.position -= new Vector3(m_direction.x, 0, m_direction.y) / 4;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            return;
            transform.position -= new Vector3(m_direction.x, 0, m_direction.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
            m_onGoal = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Goal")
            m_onGoal = false;
    }
    public void SetDirection(Vector2 direction)
    {
        if (!m_isMoving)
        {
            m_isMoving = true;
            m_direction = direction;
        }
    }

}
