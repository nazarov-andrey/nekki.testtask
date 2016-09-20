using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour {
	public Image progress;

	public float percentage {
		set {
			progress.fillAmount = Mathf.Clamp01(value);
		}
	}
}
