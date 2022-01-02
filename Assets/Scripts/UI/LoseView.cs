using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseView : BaseView
{
    public event Action OnRestartButtonClicked;

    [SerializeField] private Button restartButton;


    private void Start()
    {
        restartButton.onClick.AddListener(RestartButtonClick);
    }


    private void RestartButtonClick()
    {
        OnRestartButtonClicked?.Invoke();
    }
}
