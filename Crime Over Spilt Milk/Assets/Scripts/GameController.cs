using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour {
    // Controls the game.
    // Big ol' TO-DO:
    // Add # of clicks, when 0, you lose --> be able to restart game
    // Add a point counter
    // Adjust size of the cube/sprite when you find it and have it respawn

    int tries;
    int init = 20;
    public TextMeshProUGUI countText;
    GameObject criminal;
    Vector3 countPos;
    Coroutine _Replay;



	// Use this for initialization
	void Start () {
		tries = init;	
		countText.SetText("Clicks left: " + tries);
		criminal = GameObject.FindWithTag("Target");
		countPos = countText.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			tries--;
			countText.SetText("Clicks left: " + tries);
		}

		if (tries == 0) {
			countText.SetText("GAME OVER");
			countText.transform.position = new Vector3(450, 225, 0);

			if (_Replay != null) {
                StopCoroutine("Replay");
            }
			_Replay = StartCoroutine("Replay", 0);
		} else if (!criminal.activeInHierarchy) {
			countText.SetText("Caught the Criminal!");
			countText.transform.position = new Vector3(450, 225, 0);
			criminal.SetActive(true);

			if (_Replay != null) {
                StopCoroutine("Replay");
            }
			_Replay = StartCoroutine("Replay", 1);

			
		}
		
	}

	IEnumerator Replay(int win)
    {
        yield return new WaitForSeconds(3);
        init = init - win;
        tries = init;
		criminal.transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-6f, 6f));
		countText.transform.position = countPos;
		countText.SetText("Clicks left: " + tries);
    }
}
