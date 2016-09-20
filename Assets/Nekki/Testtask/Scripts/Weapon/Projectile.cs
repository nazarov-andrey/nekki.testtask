using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {
	public float damage;

	protected new Rigidbody rigidbody;

	private void Awake() {
		rigidbody = GetComponentInChildren<Rigidbody>();
	}

	public virtual void shoot(float speed) {
		rigidbody.AddForce(transform.forward * speed);
	}

	protected abstract void preDestruct();

	private void OnTriggerEnter(Collider collider) {
		var monster = collider.GetComponent<Monster>();
		if (monster != null) {
			monster.applyDamage(damage);	
		}

		preDestruct();
		GameObject.Destroy(gameObject);
	}
}
