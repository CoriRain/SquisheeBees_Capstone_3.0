using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	private FadeManager fm;
	public CanvasGroup FadeInOutPanel;
	public CanvasGroup Introfade;
	public CanvasGroup texter;
	//public int previous;
	public int nextroom;
	public AudioSource ambient;
	public AudioSource ambient1;
	public bool skip = false;

	Coroutine fades;

	void Awake(){
		fm = GameObject.FindGameObjectWithTag ("FadeManager").GetComponent<FadeManager> ();
	}

	void Start(){

		fades = StartCoroutine (Fadeout ());
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Tab)) {

			//skip = true;
			StopCoroutine(fades);
			Introfade.alpha = 0f;
			ambient.playOnAwake = true;
			ambient1.mute = false;
		}
	}
		

	public void QuitGame(){
		Application.Quit ();
	}

	//public void StartGame(){
		//StartCoroutine (SGCorutine ());
	//}

	//void OnTriggerEnter(Collider other){
		//StartCoroutine (SGCorutine());

	//}


	public IEnumerator Transition(){
		fm.FadeIn (FadeInOutPanel, 60, 1f);
		ambient.Stop ();
		ambient1.mute = true;
		yield return new WaitForSeconds (5f);
		fm.FadeIn (FadeInOutPanel, 120f, 1f);
		yield return new WaitForSeconds (5f);
		SceneManager.LoadScene (nextroom);
	}

	//loading in to new room
	private IEnumerator Fadeout(){
		//if (skip == false) {
			fm.FadeOut (Introfade, 30f, 1f);
			ambient.PlayDelayed (5.75f);
			ambient1.mute = true;
			fm.FadeIn (texter, 10f, 1f);
			yield return new WaitForSeconds (5f);
			fm.FadeOut (Introfade, 1f);
			yield return new WaitForSeconds (1f);
			ambient1.mute = false;
		//} else {
			//Introfade.alpha = 0f;
	//	}
	}

	//moves to next room
	public IEnumerator SGCorutine(){
		//yield return new WaitForSeconds (3f);
		fm.FadeIn (FadeInOutPanel, 60f, 1f);
		yield return new WaitForSeconds (1f);
		ambient.Stop ();
		fm.FadeIn (texter, 60f, 1f);
		fm.FadeIn (FadeInOutPanel, 120f, 1f);
		yield return new WaitForSeconds (10f);
		SceneManager.LoadScene (nextroom);
	}

	private void Reset(){
		fm.CanvasGroupON (FadeInOutPanel, true);
	}

}
