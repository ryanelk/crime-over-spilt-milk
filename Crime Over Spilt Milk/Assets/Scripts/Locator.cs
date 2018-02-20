using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locator : MonoBehaviour {

	public GameObject particle;
    public GameObject flashlight;
    Coroutine _TurnOffObjs;

	// Use this for initialization
	void Start () {
		particle = Instantiate(particle, transform.position, transform.rotation);
		particle.SetActive(false); // TO-DO: Disable mesh renderer instead
        flashlight.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray)) {
                if (!particle.activeInHierarchy) {
                    particle.SetActive(true);
                }
                Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pz.z = -1;
                particle.transform.position = pz;
                pz.z = -10;
                flashlight.transform.position = pz;
                flashlight.SetActive(true);
                if (_TurnOffObjs != null) {
                    StopCoroutine("TurnOffObjs");
                }
                _TurnOffObjs = StartCoroutine("TurnOffObjs");
            }
		}
	}

    IEnumerator TurnOffObjs()
    {
        yield return new WaitForSeconds(2);
        flashlight.SetActive(false);
        particle.SetActive(false);
    }
}
