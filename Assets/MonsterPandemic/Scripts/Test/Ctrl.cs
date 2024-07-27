using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl : ComponentBehavior
{

    [SerializeField] protected Animator _animator;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        _animator = transform.GetComponentInChildren<Animator>();
    }

    private AnimMachine _animMachine;
    protected override void Start()
    {
        base.Start();
        _animMachine = new AnimMachine();
    }
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _animMachine.ChangeAnim(new BasicAttackAnim(_animator));
        }
        if(Input.GetKeyDown(KeyCode.M))
            _animMachine.ChangeAnim(new BasicMoveAnim(_animator));
        if(Input.GetKeyDown(KeyCode.D))
            _animMachine.ChangeAnim(new BasicDeadAnim(_animator));
       
    }
}
