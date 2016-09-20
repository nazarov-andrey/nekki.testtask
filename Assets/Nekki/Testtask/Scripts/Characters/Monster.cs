using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Monster : Character<Monster> {	
	private AICharacterControl AICharacterControl;
	private NavMeshAgent navMeshAgent;

	public float damage;

	protected override void internalAwake ()
	{
		base.internalAwake ();
		AICharacterControl = GetComponentInChildren<AICharacterControl>();
		navMeshAgent = GetComponentInChildren<NavMeshAgent>();
	}

	protected override void internalStart ()
	{
		base.internalStart ();
		navMeshAgent.speed = speed;
	}

	public void move(Vector3 position) {
		transform.position = Vector3.zero;
		navMeshAgent.Move(position);
	}

	public Component target {
		set {
			AICharacterControl.target = value.transform;
		}
	}
}
