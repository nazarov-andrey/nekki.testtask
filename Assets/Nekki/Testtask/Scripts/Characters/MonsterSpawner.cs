using UnityEngine;
using System.Collections;

public class MonsterSpawner : MonoBehaviour {
	public static MonsterSpawner instance { private set; get; }

	public Monster[] monsterPrototypes;
	public int monstersOnStage = 10;
	private MeshRenderer[] floorMeshRenderer;
	public GameObject spawnArea;

	private void Awake() {
		instance = this;
		floorMeshRenderer = spawnArea.GetComponentsInChildren<MeshRenderer>();

	}

	public void spawn() {
		var monsterToSpawn = monsterPrototypes[Random.Range(0, monsterPrototypes.Length)];
		var monster = GameObject.Instantiate(monsterToSpawn);
		var position = pickSpawnPosition();

		monster.OnDie += monster_OnDie;
		monster.move(position);
		monster.target = Tank.instance;
	}

	private void monster_OnDie (Monster monster)
	{
		monster.OnDie -= monster_OnDie;
		spawn();
	}

	private Vector3 pickSpawnPosition(float radius = 0.1f) {
		var mesh = floorMeshRenderer[Random.Range(0, floorMeshRenderer.Length)];
		var bounds = mesh.bounds;

		var sourcePosition = new Vector3(
				Random.Range(bounds.center.x - bounds.extents.x, bounds.center.x + bounds.extents.x),
				0f,
				Random.Range(bounds.center.z - bounds.extents.z, bounds.center.z + bounds.extents.z)
			);

		return sourcePosition;
	}

	public void clear() {
		var monsters = GameObject.FindObjectsOfType<Monster>();
		foreach (var monster in monsters) {
			GameOver.Destroy(monster.gameObject);
		}
	}

	public void initialSpawn() {
		for (int i = 0; i < monstersOnStage; i++) {
			spawn();
		}
	}
}
