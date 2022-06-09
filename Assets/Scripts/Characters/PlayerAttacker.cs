using System.Collections;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour, IAttackable {

    public Transform WeaponParent;
    public AbstractWeapon weapon { get; private set; }

    private void Awake() {
        GameLoopEvents.OnWeaponChosen += ApplyWeapon;
    }

    public void Attack() {
        if (weapon != null)
            weapon.Attack();
    }

    private void ApplyWeapon(AbstractWeapon newWeapon) {
        if (weapon!=null) Destroy(weapon.gameObject);
        weapon = newWeapon;
        Transform weaponTransform = weapon.transform;
        weaponTransform.parent = WeaponParent;
        weaponTransform.localPosition = weapon.BasePosition;
        weaponTransform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    
}