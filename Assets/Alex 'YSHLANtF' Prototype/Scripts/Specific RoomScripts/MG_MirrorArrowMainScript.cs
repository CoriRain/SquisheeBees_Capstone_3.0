using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ARROW_DIRECTIONS_TUTORIAL
{
	TUTORIAL_UP,
	TUTORIAL_DOWN,
	TUTORIAL_LEFT,
	TUTORIAL_RIGHT,
	TUTORIAL_NULL
}

public class MG_MirrorArrowMainScript : MonoBehaviour {

	public List<ARROW_DIRECTIONS_TUTORIAL>patternList = new List<ARROW_DIRECTIONS_TUTORIAL>();
	int listMarker = 0;
	bool commandReady = false;
	public float nextCommandTimer = 2.0f;
	float timerHidden;
	ARROW_DIRECTIONS_TUTORIAL commandCurrent;

	// Use this for initialization
	void Start () {

		timerHidden = nextCommandTimer;
		commandCurrent = ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_NULL;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (commandReady == false)
			commandCurrent = ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_NULL;

		if (timerHidden >= 0) {
			timerHidden -= Time.deltaTime;
		} else {
			commandCurrent = patternList [listMarker];
			commandReady = true;
		}
		
	}

	public ARROW_DIRECTIONS_TUTORIAL giveCommandFunction()
	{
		switch(commandCurrent)
		{
		case ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_UP:
			return ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_UP;

		case ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_DOWN:
			return ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_DOWN;

		case ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_LEFT:
			return ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_LEFT;

		case ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_RIGHT:
			return ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_RIGHT;

		default:
			return ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_NULL;

			
			
		}
	}
	public void commandFollowed()
	{
		
		commandReady = false;
		listMarker++;
		if(listMarker>=patternList.Count)
			SceneManager.LoadScene ("Basement0");

		timerHidden = nextCommandTimer;
	}
}
