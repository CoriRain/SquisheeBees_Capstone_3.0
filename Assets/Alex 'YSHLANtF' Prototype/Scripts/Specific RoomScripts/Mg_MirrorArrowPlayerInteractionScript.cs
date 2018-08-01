using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mg_MirrorArrowPlayerInteractionScript : MonoBehaviour {

	public GameObject ArrowMainObj;
	MG_MirrorArrowMainScript ArrowMainScr = new MG_MirrorArrowMainScript();
	ARROW_DIRECTIONS_TUTORIAL arrowPoint;
	SpriteRenderer ownSprite;

	// Use this for initialization
	void Start () {

		ArrowMainScr = ArrowMainObj.GetComponent<MG_MirrorArrowMainScript> ();
		ownSprite = gameObject.GetComponent<SpriteRenderer> ();

		ownSprite.enabled = false;

		arrowPoint = ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_NULL;


		
	}
	
	// Update is called once per frame
	void Update () {

		if (arrowPoint != ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_NULL) {
			ownSprite.enabled = true;
			arrowPoint = ArrowMainScr.giveCommandFunction ();
			setupDirection ();
		} else {
			ownSprite.enabled = false;
			arrowPoint = ArrowMainScr.giveCommandFunction ();
		}
		
	}

	void setupDirection()
	{
		Vector3 zSpin = new Vector3(0,0,0);
		if (arrowPoint == ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_UP) {
			zSpin.z = 0;
			gameObject.transform.localEulerAngles = zSpin;
		} else if (arrowPoint == ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_LEFT) {
			zSpin.z = 90;
			gameObject.transform.localEulerAngles = zSpin;
		} else if (arrowPoint == ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_DOWN) {
			zSpin.z = 180;
			gameObject.transform.localEulerAngles = zSpin;
		} else if (arrowPoint == ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_RIGHT) {
			zSpin.z = 270;
			gameObject.transform.localEulerAngles = zSpin;
		}

	}

	public bool directionInput(ARROW_DIRECTIONS_TUTORIAL playerInput)
	{
		if (playerInput == arrowPoint) {
			ArrowMainScr.commandFollowed ();

			arrowPoint = ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_NULL;

			ownSprite.enabled = false;

			arrowPoint = ArrowMainScr.giveCommandFunction ();



			return true;
		} else {
			return false;
		}
	}
}
