
using System.Collections.Generic;
using System;
using UnityEngine;

public class DefenseAction : IdleAction
{
    protected DamageReceiver _damageReceiver;
    protected SpriteRenderer _spriteRenderer;
    protected List<Sprite> _hurtSprites;

    public DefenseAction(DamageReceiver damageReceiver, SpriteRenderer spriteRenderer, List<Sprite> hurtSprites)
    {
        _damageReceiver = damageReceiver;
        _spriteRenderer = spriteRenderer;
        _hurtSprites = hurtSprites;
    }

    public override void UpdatePhysis()
    {
        int id = (int)Math.Floor(_hurtSprites.Count - _damageReceiver.CurHp / _damageReceiver.MaxHp * _hurtSprites.Count);
        id = Math.Min(_hurtSprites.Count - 1, id);
        _spriteRenderer.sprite = _hurtSprites[id];
    }
}
