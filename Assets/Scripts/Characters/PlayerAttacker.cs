using System;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour, IAttackable {

    public Transform WeaponParent;
    private AbstractWeapon weapon { get; set; }

    public Transform Target { get; set; }
    public float Damage {
        get => weapon.Damage;
        set => weapon.Damage = value;
    }
    public float AttackRange {
        get => weapon.AttackRange;
        set => weapon.AttackRange = value;
    }
    public float ReloadTime {
        get => weapon.ReloadTime;
        set => weapon.ReloadTime = value;
    }
    
    public bool IsAttacking { get => weapon.IsAttacking; }
    public bool IsReloaded { get => weapon.IsReloaded; }

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