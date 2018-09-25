using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnsureNoCollision : MonoBehaviour {

    public GameManager gm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionStay(Collision collision)
    {
        Debug.Log("collision with food");
        if (collision.transform.tag == "Obstacle" || collision.transform.tag == "Food")
        {
            gm.SpawnSingleFood();
            Destroy(gameObject);
        }
    }
}
