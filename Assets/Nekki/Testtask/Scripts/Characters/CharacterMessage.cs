using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterMessage : MonoBehaviour {
	private Text _text;
	private RectTransform rectTransform;
	public float heightToFlyTo;
	public float lifetime;

	private void Awake() {
		_text = GetComponentInChildren<Text>();
		rectTransform = transform as RectTransform;
	}

	private IEnumerator Start() {
		var startTime = Time.realtimeSinceStartup;
		var initialPosition = rectTransform.anchoredPosition;
		var targetPosition = new Vector2(initialPosition.x, initialPosition.y + heightToFlyTo);
		var initialColor = _text.color;
		var targetColor = initialColor;
		targetColor.a = 0f;
		float timePassed;
		do {
			timePassed = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / lifetime);
			_text.color = Color.Lerp(initialColor, targetColor, timePassed);
			rectTransform.anchoredPosition = Vector2.Lerp(initialPosition, targetPosition, timePassed);

			yield return null;
		} while (timePassed < 1f);

		GameObject.Destroy(gameObject);
	}

	public string text	{
		set {
			_text.text = value;	
		}
	}
}
