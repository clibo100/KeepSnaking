using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSnake : MonoBehaviour
{
    public SnakeMovement movement;

    public SpawnObject SO;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            movement.AddBodyPart();

            Destroy(collision.gameObject);

            SO.SpawnFood();
        }

        else
        {
            if (collision.transform != movement.BodyParts[1] && movement.isAlive)
            {
                if(Time.time - movement.TimeFromLastRetry > 2)
                {
                    Debug.Log("collision with smth");
                    movement.Die();
                }
            }
        }
    }


}
