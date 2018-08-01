using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_MirrorMoveScript : MonoBehaviour {

	public Sprite playerIdle;
	public Sprite playerUp;
	public Sprite playerLeft;
	public Sprite playerDown;
	public Sprite playerRight;

	public GameObject mirrorPlayer;
	public Sprite mirrorIdle;
	public Sprite mirrorUp;
	public Sprite mirrorLeft;
	public Sprite mirrorDown;
	public Sprite mirrorRight;

	SpriteRenderer playerSpRen;
	SpriteRenderer mirrorSpRen;

	public GameObject arrowPlayerInteractionObj;
	Mg_MirrorArrowPlayerInteractionScript aPScr;

	float idleTimer = 0;
	float maxTimeTilIdle = 1;

	// Use this for initialization
	void Start () {

		aPScr = arrowPlayerInteractionObj.GetComponent<Mg_MirrorArrowPlayerInteractionScript> ();
		playerSpRen = gameObject.GetComponent<SpriteRenderer> ();
		mirrorSpRen = mirrorPlayer.GetComponent<SpriteRenderer> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {
			if (aPScr.directionInput (ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_UP) == true) {
				changeSpriteFunc (ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_UP);
			}
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {
			if (aPScr.directionInput (ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_LEFT) == true) {
				changeSpriteFunc (ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_LEFT);
			}
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) {
			if (aPScr.directionInput (ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_DOWN) == true) {
				changeSpriteFunc (ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_DOWN);
			}
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {
			if (aPScr.directionInput (ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_RIGHT) == true) {
				changeSpriteFunc (ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_RIGHT);
			}
		}

		if (idleTimer > 0) {
			idleTimer -= Time.deltaTime;
		} else {
			playerSpRen.sprite = playerIdle;
			mirrorSpRen.sprite = mirrorIdle;
		}
			
	}

	void changeSpriteFunc(ARROW_DIRECTIONS_TUTORIAL changer)
	{
		switch (changer) {

		case ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_UP:
			playerSpRen.sprite = playerUp;
			mirrorSpRen.sprite = mirrorUp;
			idleTimer = maxTimeTilIdle;
			break;
		case ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_DOWN:
			playerSpRen.sprite = playerDown;
			mirrorSpRen.sprite = mirrorDown;
			idleTimer = maxTimeTilIdle;
			break;
		case ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_LEFT:
			playerSpRen.sprite = playerLeft;
			mirrorSpRen.sprite = mirrorLeft;
			idleTimer = maxTimeTilIdle;
			break;
		case ARROW_DIRECTIONS_TUTORIAL.TUTORIAL_RIGHT:
			playerSpRen.sprite = playerRight;
			mirrorSpRen.sprite = mirrorRight;
			idleTimer = maxTimeTilIdle;
			break;
		default:
			Debug.Log ("durn");
			break;


		}
	}
}
