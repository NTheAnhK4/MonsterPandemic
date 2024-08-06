using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : ComponentBehavior
{
    public Button exitButton;
    public Transform exitTransform;
    protected override void Awake()
    {
        exitButton.onClick.AddListener(() =>
        {
            SpeedGameCtrl.Instance.ContinuePreviousSpeed();
            exitTransform.gameObject.SetActive(false);
        });
    }
}
