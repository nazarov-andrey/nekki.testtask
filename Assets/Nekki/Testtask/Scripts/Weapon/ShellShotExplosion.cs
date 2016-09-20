using UnityEngine;
using System.Collections;

public class ShellShotExplosion : MonoBehaviour {
	private IEnumerator Start() {
		yield return new WaitForSeconds(1f);
		GameObject.Destroy(gameObject);
	}
}
