using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class Tank : Character<Tank> {
	private float lastMonstertCollisionTime;
	public float monsterAttackCooldown;
	public static Tank instance { private set; get; }

	protected override void internalAwake ()
	{
		base.internalAwake ();
		instance = this;
		GetComponent<CarController>().MaxSpeed *= this.speed;
	}

	protected override void die ()
	{
		var camera = GetComponentInChildren<Camera>();
		camera.transform.SetParent(null, true);

		base.die ();
	}

	private void checkCollision(Collider collider) {
		var monster = collider.GetComponent<Monster>();
		if (monster != null && Time.realtimeSinceStartup >= lastMonstertCollisionTime + monsterAttackCooldown) {
			lastMonstertCollisionTime = Time.realtimeSinceStartup;
			applyDamage(monster.damage);
		}
	}

	private void OnTriggerEnter(Collider collider) {
		Debug.Log("OnTriggerEnter");
		checkCollision(collider);
	}

	private void OnTriggerStay(Collider collider) {
		Debug.Log("OnTriggerStay");
		checkCollision(collider);
	}
}
