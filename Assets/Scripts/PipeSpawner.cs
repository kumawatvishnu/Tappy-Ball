using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour {

    public float maxYpos;
    public float spwanTime;
    public GameObject pipe;
	// Use this for initialization
	void Start () {
        //StartSpawningPipes();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StopSpawningPipes()
    {
        CancelInvoke("SpawnPipe");
    }
    public void StartSpawningPipes()
    {
        InvokeRepeating("SpawnPipe", 0.2f, spwanTime);
    }
    public void SpawnPipe()
    {
        Instantiate(pipe, new Vector3(transform.position.x, transform.position.y+Random.Range(-maxYpos, maxYpos), transform.position.z), Quaternion.identity);
    }
}
