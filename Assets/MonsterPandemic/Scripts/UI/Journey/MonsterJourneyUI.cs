using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterJourneyUI : ComponentBehavior
{
    private static MonsterJourneyUI instance;

    public static MonsterJourneyUI Instance => instance;
    [SerializeField] private Slider slider;
    protected override void Awake()
    {
        if(instance != null)
            Debug.LogError("Only 1 MonsterJourneyUI allow to exist");
        instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSlider();
    }

    private void LoadSlider()
    {
        if (slider != null) return;
        slider = transform.GetComponent<Slider>();
        if(slider != null)
            Debug.Log(transform.name + " Load Silder successful");
    }

    public void ResetMaxValue(int value)
    {
        slider.maxValue = value;
    }

    private void Update()
    {
        if (slider.value < LevelManager.Instance.CurWave) slider.value += Time.deltaTime/20;
    }
}
