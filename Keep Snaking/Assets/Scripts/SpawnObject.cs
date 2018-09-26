using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Vector3 center;

    public Vector3 size;

    public int amount;

    public GameObject objectPrefab;

    public GameObject snake;

	// Use this for initialization
	void Start () {
        SpawnFood();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void SpawnFood()
    {
        for (int i = 0; i < amount; ++i)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            bool canInstantiate = false;
            while (!canInstantiate)
            {
                if ((pos.x <= snake.transform.position.x + 2.5 && pos.x >= snake.transform.position.x - 2.5) && (pos.z <= snake.transform.position.z + 2.5 && pos.z >= snake.transform.position.z - 2.5))
                {
                    pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
                }
                else
                {
                    canInstantiate = true;
                }
            }
            Instantiate(objectPrefab, pos, Quaternion.identity);
        }
    }

    public void SpawnSingleObject()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        Instantiate(objectPrefab, pos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
