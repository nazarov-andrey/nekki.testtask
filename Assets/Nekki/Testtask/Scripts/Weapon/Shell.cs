using UnityEngine;
using System.Collections;

public class Shell : Projectile {
	public ShellShotExplosion shellShotExplosionPrototype;

	private void explode() {
		var sheelShotExplostion = GameObject.Instantiate(shellShotExplosionPrototype);
		sheelShotExplostion.transform.position = transform.position;
		sheelShotExplostion.transform.rotation = transform.rotation;
	}

	public override void shoot (float speed)
	{
		base.shoot(speed);
		explode();
	}

	protected override void preDestruct ()
	{
		explode();
	}
}
