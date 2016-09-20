using UnityEngine;
using System.Collections;

public delegate void OnGameRestart();

public class GameOver : MonoBehaviour {
	public event OnGameRestart onRestart;

	public static GameOver instance { private set; get; }

	private void Awake() {
		instance = this;
	}

	private void Start() {
		hide();
	}

	public void display() {
		gameObject.SetActive(true);
	}

	public void hide() {
		gameObject.SetActive(false);
	}

	private void Update() {
		if (Input.GetKeyUp(KeyCode.R)) {
			if (onRestart != null) {
				onRestart();
			}
		}
	}
}
