using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject obj;

	// Use this for initialization
	void Start () {

		obj = Instantiate(obj, new Vector3(Random.Range(-10f, 10f), Random.Range(-6f, 6f)), Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
	}
}
