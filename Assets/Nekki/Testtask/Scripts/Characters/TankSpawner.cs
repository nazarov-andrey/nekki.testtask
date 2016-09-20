using UnityEngine;
using System.Collections;

public class TankSpawner : MonoBehaviour {
	public Tank tankPrototype;

	private void Start() {
		initialSpawn();
		GameOver.instance.onRestart += gameOver_onRestart;
	}

	private void initialSpawn() {
		var camera = GameObject.FindObjectOfType<Camera>();
		if (camera != null) {
			GameOver.Destroy(camera.gameObject);	
		}

		spawn();
		MonsterSpawner.instance.initialSpawn();
	}

	private void gameOver_onRestart ()
	{
		initialSpawn();
		GameOver.instance.hide();
	}

	private void spawn() {
		var tank = GameObject.Instantiate(tankPrototype);
		tank.transform.position = transform.position;
		tank.transform.rotation = transform.rotation;
		tank.OnDie += tank_OnDie;
	}

	private void tank_OnDie (Tank tank)
	{
		tank.OnDie -= tank_OnDie;
		MonsterSpawner.instance.clear();
		GameOver.instance.display();
	}
}
