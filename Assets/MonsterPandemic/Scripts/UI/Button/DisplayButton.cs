using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayButton : ComponentBehavior
{
    public Button displayBtn;
    public Transform displayTransform;
    protected override void Awake()
    {
        base.Awake();
        displayBtn.onClick.AddListener(() =>
        {
            SpeedGameCtrl.Instance.StopGame();
            displayTransform.gameObject.SetActive(true);
        });
    }
}
