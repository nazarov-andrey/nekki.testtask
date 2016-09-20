using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour {
	private Weapon[] weapons;
	private Weapon activeWeapon;

	public Text activeWeaponText;

	private void Awake() {
		weapons = GetComponentsInChildren<Weapon>();

		for (int i = 1; i < weapons.Length; i++) {
			weapons[i].deactivate();
		}
		activate(weapons[0]);
	}

	private void activate(Weapon weapon) {
		if (activeWeapon != null) {
			activeWeapon.deactivate();
		}

		activeWeapon = weapon;
		activeWeapon.activate();
		activeWeaponText.text = activeWeapon.kind;
	} 

	private void Update() {
		foreach (var weapon in weapons) {
			if (Input.GetKeyUp(weapon.activationKey) && weapon != activeWeapon) {
				activate(weapon);
				break;
			}
		}
	}
}
