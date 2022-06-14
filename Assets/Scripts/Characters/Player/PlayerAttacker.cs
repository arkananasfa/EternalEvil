using System;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour, IAttackable {

    public Transform WeaponParent;
    private AbstractWeapon weapon { get; set; }
    private AbstractWeapon oldWeapon { get; set; }

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
    
    public bool IsAttacking => weapon.IsAttacking;
    public bool IsReloaded => weapon.IsReloaded;

    private void OnEnable() {
        GameLoopEvents.OnWeaponChosen += ApplyWeapon;
        GameLoopEvents.OnRoundEnded += TrashOldWeapon;
    }

    private void OnDisable() {
        GameLoopEvents.OnWeaponChosen -= ApplyWeapon;
        GameLoopEvents.OnRoundEnded -= TrashOldWeapon;
    }

    public void Attack() {
        if (weapon != null)
            weapon.Attack();
    }

    private void TrashOldWeapon() {
        Destroy(weapon.gameObject);
    }

    private void ApplyWeapon(AbstractWeapon newWeapon) {
        weapon = newWeapon;
        Transform weaponTransform = weapon.transform;
        weaponTransform.parent = WeaponParent;
        weaponTransform.localPosition = weapon.BasePosition;
        weaponTransform.localRotation = Quaternion.Euler(0, 0, 0);
        float parentRotation = WeaponParent.localRotation.eulerAngles.z;
        if (parentRotation >= 90 || parentRotation <= -90) {
            weaponTransform.Rotate(180, 0, 0);
        }
    }
    
}