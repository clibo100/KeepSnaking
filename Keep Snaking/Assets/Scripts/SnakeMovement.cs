using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {

    public List<Transform> BodyParts = new List<Transform>();

    public float mindistance = 0.25f;

    public float speed = 1;
    public float rotationspeed = 50;

    public GameObject bodyprefab;

    private float distance;
    private Transform currBodyPart;
    private Transform prevBodyPart;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddBodyPart()
    {
        Transform newpart = (Instantiate(bodyprefab, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation) as GameObject).transform;
    }
}
