using UnityEngine;
using System.Collections;

public delegate void OnCharacterDie<T>(T character) where T:Character<T>;

public abstract class Character<T> : MonoBehaviour
	where T:Character<T>
{
	public event OnCharacterDie<T> OnDie;

	private CharacterOverhead characterOverhead;

	protected float hpMax;
	protected float accumulatedDamage;

	public float hp;
	public float block;
	public float speed;

	protected virtual void internalAwake() {
		hpMax = hp;
		characterOverhead = GetComponentInChildren<CharacterOverhead>();
		InvokeRepeating("emitAccumulatedDamageMessage", 0f, 0.5f);
	}

	protected virtual void internalStart() {
		refreshHpProgress();
	}

	private void Awake() {
		internalAwake();
	}

	private void Start() {
		internalStart();
	}

	protected void refreshHpProgress() {
		characterOverhead.hpProgress.percentage = hp / hpMax;
	}

	protected void emitMessage(string message) {
		characterOverhead.messageEmitter.emit(message);
	}

	private void Update() {
		if (transform.hasChanged) {
			characterOverhead.align();
		}
	}

	protected virtual void die ()
	{
		fireOnDie();
		GameObject.Destroy(gameObject);	
	}

	public void applyDamage(float damage) {
		var actualDamage = damage * (1 - block);
		hp -= actualDamage;
		if (hp <= 0) {
			die();
			return;
		}

		refreshHpProgress();
		accumulatedDamage += actualDamage;
	}

	private void emitAccumulatedDamageMessage() {
		if (accumulatedDamage > 0f) {
			emitMessage(Mathf.FloorToInt(accumulatedDamage).ToString());
			accumulatedDamage = 0f;
		}
	}

	private void fireOnDie() {
		if (OnDie != null) {
			OnDie(this as T);
		}
	}
}
