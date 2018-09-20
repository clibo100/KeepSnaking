using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour {

    //https://www.youtube.com/watch?v=xz8Ga9er3_8 
    //source for snake script

    public List<Transform> BodyParts = new List<Transform>();

    public float mindistance = 0.25f;
    public int beginsize; 

    public float speed = 1;
    public float rotationspeed = 50;

    public float TimeFromLastRetry;

    //public Text currScore;
    //public Text scoreText;

    public GameObject bodyprefab;

    private float distance;
    private Transform currBodyPart;
    private Transform prevBodyPart;

    //public GameObject deathscreen;

    public bool isAlive;

	// Use this for initialization
	void Start ()
    {
        StartLevel();
	}

    public void StartLevel()
    {
        isAlive = true;

        TimeFromLastRetry = Time.time;

        //deathscreen.SetActive(false);

        for (int i = BodyParts.Count - 1; i > 1; --i)
        {
            Destroy(BodyParts[i].gameObject);

            BodyParts.Remove(BodyParts[i]);
        }


        BodyParts[0].position = new Vector3(8, 0.16f, -2);

        BodyParts[0].rotation = Quaternion.identity;

        //currScore.gameObject.SetActive(true);

        //currScore.text = "Score: 0";

        


        for (int i = 0; i < beginsize - 1; ++i)
        {
            AddBodyPart();
        }

        BodyParts[0].position = new Vector3(10, 0.16f, -2);

    }
	
	// Update is called once per frame
	void Update () {
        if (isAlive)
        {
            Move();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            AddBodyPart();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartLevel();
        }
    }

    public void Move()
    {
        float curspeed = speed;

        if(Input.GetKey(KeyCode.W))
        {
            curspeed *= 2;
        }

        BodyParts[0].Translate(BodyParts[0].forward * curspeed * Time.smoothDeltaTime, Space.World);

        if(Input.GetAxis("Horizontal") != 0)
        {
            BodyParts[0].Rotate(Vector3.up * rotationspeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        }

        for(int i = 1; i < BodyParts.Count; ++i)
        {
            currBodyPart = BodyParts[i];
            prevBodyPart = BodyParts[i - 1];

            distance = Vector3.Distance(prevBodyPart.position, currBodyPart.position);

            Vector3 newpos = prevBodyPart.position;

            newpos.y = BodyParts[0].position.y;

            float T = Time.deltaTime * distance / mindistance * curspeed;

            if (T > 0.5f)
            {
                T = 0.5f;
            }

            currBodyPart.position = Vector3.Slerp(currBodyPart.position, newpos, T);
            currBodyPart.rotation = Quaternion.Slerp(currBodyPart.rotation, prevBodyPart.rotation, T);

        }
    }

    public void AddBodyPart()
    {
        Transform newpart = (Instantiate(bodyprefab, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation) as GameObject).transform;

        newpart.SetParent(transform);

        BodyParts.Add(newpart);

        //currScore.text = "Score: " + (BodyParts.Count - beginsize).ToString();
    }

    public void Die()
    {
        isAlive = false;

        //scoreText.text = "Your Score: " + (BodyParts.Count - beginsize).ToString();

        //currScore.gameObject.SetActive(false);

        //deathscreen.SetActive(true);
    }
}
