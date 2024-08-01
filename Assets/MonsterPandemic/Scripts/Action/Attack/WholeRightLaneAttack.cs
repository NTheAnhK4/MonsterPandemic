using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WholeRightLaneAttack : Attack
{
    protected string _bulletName;
    protected Vector3 _position;
    protected int _level;
    
    public WholeRightLaneAttack(float attackSpeed, string bulletName, Vector3 position,int level) : base(attackSpeed)
    {
        _bulletName = bulletName;
        _position = position;
        _level = level;
    }

    protected override void OnAttack()
    {
        Transform projectile = ProjectileSpawner.Instance.Spawn(_bulletName, _position);
        projectile.tag = "Weapon Projectile";
        projectile.Find("Radar").tag = "Weapon Projectile";
        projectile.GetComponent<EntityCtrl>().ResetLevel(_level);
    }
}
