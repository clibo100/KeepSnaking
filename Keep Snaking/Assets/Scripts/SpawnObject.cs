using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Vector3 center;

    public Vector3 size;

    public int amount;

    public char keybind;

    public GameObject objectPrefab;

	// Use this for initialization
	void Start () {
        SpawnFood();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (keybind == 'e')
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SpawnFood();
            }
        }
        else if (keybind == 'f')
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SpawnFood();
            }
        }
	}

    public void SpawnFood()
    {
        for (int i = 0; i < amount; ++i)
        {

            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

            Instantiate(objectPrefab, pos, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
