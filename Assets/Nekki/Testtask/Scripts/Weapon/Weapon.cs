using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : MonoBehaviour {
	private float lastShotTime;
	public string kind;
	public Projectile projectilePrototype;
	public Barrel barrel;
	public KeyCode activationKey;
	public float cooldown;
	public float projectileSpeed = 2000f;

	private void FixedUpdate()
    {
		if (Input.GetKey(KeyCode.X) && Time.realtimeSinceStartup >= lastShotTime + cooldown) {
			shot();
		}
    }

    private void shot() {
		lastShotTime = Time.realtimeSinceStartup;
		barrel.shoot(projectilePrototype, projectileSpeed);
    }

    public void activate() {
    	gameObject.SetActive(true);
    }

    public void deactivate() {
		gameObject.SetActive(false);
    }

    public bool isActive {
    	get {
    		return gameObject.activeSelf;
    	}
    }
}
