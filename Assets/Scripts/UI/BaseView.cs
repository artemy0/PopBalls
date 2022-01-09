using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class BaseView : MonoBehaviour
{
    public void OpenView()
    {
        gameObject.SetActive(true);
    }

    public void CloseView()
    {
        gameObject.SetActive(false);
    }
}
