using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public GameObject ball;
    public Transform spawnPosition;
    private RectTransform canvas;
    private GameObject canvasObject;


    private float currentTime = 0f;
    private float spawnInterval = Constants.SPAWN_INTERVAL;

    // Start is called before the first frame update
    void Start()
    {
        canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        canvas = canvasObject.GetComponent<RectTransform>();

        SpawnBall();
    }



    // Update is called once per frame
    void Update()
    {

        currentTime += Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            SpawnBall();
            currentTime = 0;
        }
        else if (currentTime > spawnInterval)
        {
            SpawnBall();
            currentTime = 0;
            currentTime = 0;
        }
    }

    private void SpawnBall()
    {

        //Debug.Log("Spawning Ball at " + spawnPosition.localPosition);
        GameObject newBall = Instantiate(ball, spawnPosition.localPosition, Quaternion.identity);

        newBall.transform.SetParent(canvas, false);
        newBall.SetActive(true);


    }
}
