using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractShooterWeapon : AbstractWeapon {

	[SerializeField] protected StandardWeaponBullet BulletPrefab;
	[SerializeField] protected Transform BulletStart;

	public override bool Attack() {
		StandardWeaponBullet bullet = CreateBullet();
		bullet.Init();
		return true;
	}

	protected virtual StandardWeaponBullet CreateBullet() {
		StandardWeaponBullet bullet = Instantiate(BulletPrefab, BulletStart.position, transform.rotation);
		bullet.LifeTime = AttackRange / bullet.Speed;
		bullet.Damage = Damage;
		return bullet;
	}

	public override List<ChooseWindowRow> GenerateDescribe() {
		var describeList = new List<ChooseWindowRow>();
		describeList.Add(new ChooseWindowRow(sprite));
		describeList.Add(new ChooseWindowRow(Name, true));
		describeList.Add(new ChooseWindowRow($"Reload time: {ReloadTime}"));
		describeList.Add(SpeedPenaltyRow());
		var bullet = CreateBullet();
		describeList.AddRange(bullet.GenerateDescribe());
		Destroy(bullet.gameObject);
		return describeList;
	}

}