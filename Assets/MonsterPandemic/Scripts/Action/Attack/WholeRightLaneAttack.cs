using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WholeRightLaneAttack : Attack
{
    protected string _bulletName;
    protected Vector3 _position;
    
    public WholeRightLaneAttack(float attackSpeed, string bulletName, Vector3 position) : base(attackSpeed)
    {
        _bulletName = bulletName;
        _position = position;
    }

    protected override void OnAttack()
    {
        Transform projectile = ProjectileSpawner.Instance.Spawn(_bulletName, _position);
        projectile.tag = "Weapon Projectile";
        projectile.Find("Radar").tag = "Weapon Projectile";
    }
}
