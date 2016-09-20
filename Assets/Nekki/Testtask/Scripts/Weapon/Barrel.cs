using UnityEngine;
using System.Collections;

public class Barrel: MonoBehaviour {
	public virtual T shoot<T>(T projectilePrototype, float speed)
		where T: Projectile
	{
		var projectile = GameObject.Instantiate(projectilePrototype);
		projectile.transform.position = transform.position;
		projectile.transform.rotation = transform.rotation;
		projectile.shoot(speed);

		return projectile;
	}
}
