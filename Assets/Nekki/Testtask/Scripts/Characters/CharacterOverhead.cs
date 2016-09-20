using UnityEngine;
using System.Collections;

public class CharacterOverhead : MonoBehaviour {
	private Camera mainCamera;
	public Progressbar hpProgress;
	public CharacterMessageEmitter messageEmitter;

	private void Awake() {
		mainCamera = Camera.main;
	}

	public void align() {
		if (mainCamera != null) {
			transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward, mainCamera.transform.up);
		}
	}
}
