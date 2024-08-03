using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClickableObject : ComponentBehavior
{
    [SerializeField] protected string entityType = "RangedWeapon";
    [SerializeField] protected string entityName = "Railgun Turret";
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private int numberClick = 0;

    public string EntityType => entityType;

    public string EntityName => entityName;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpriteRenderer();
    }
    protected virtual void LoadSpriteRenderer()
    {
        if(_spriteRenderer != null) return;
        _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        Debug.Log(transform.name + " LoadSpriteRenderer successful");
    }
    protected override void Awake()
    {
        base.Awake();
        numberClick = 0;
        _spriteRenderer.color = new Color(255, 255, 255, 255);
    }

    private void OnMouseDown()
    {
        ++numberClick;
        if (numberClick == 1)
        {
            _spriteRenderer.color = Color.grey;
            ItemManager.Instance.SetSelectedObject(this);
        }
        else
        {
            _spriteRenderer.color = Color.white;
            ItemManager.Instance.SetSelectedObject(null);
        }

        numberClick %= 2;
    }

    public void DestroyObject()
    {
        _spriteRenderer.color = new Color(255, 255, 255, 255);
        numberClick = 0;
        WeaponItemSpawner.Instance.DespawnObject(transform);
    }
}
