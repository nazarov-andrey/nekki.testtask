using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterMessageEmitter : MonoBehaviour {
	private Queue<string> messagesQueue;
	public CharacterMessage messagePrototype;
	public float nextMessageDelay;

	private void Awake() {
		messagesQueue = new Queue<string>();
	}

	private IEnumerator Start() {
		while (true) {
			if (messagesQueue.Count > 0) {
				internalEmit(messagesQueue.Dequeue());
				yield return new WaitForSeconds(nextMessageDelay);
			} else {
				yield return null;
			}
		}
	}

	private void internalEmit(string text) {
		var message = GameObject.Instantiate(messagePrototype);
		message.transform.SetParent(transform, false);
		message.text = text;		
	}
 
	public void emit(string text) {
		messagesQueue.Enqueue(text);
	}
}
