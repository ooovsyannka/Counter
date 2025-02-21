using System;
using UnityEngine;
using UnityEngine.UI;

public class Tumbler : MonoBehaviour
{
    [SerializeField] private Image _switcher;
    [SerializeField] private Sprite _switchOn;
    [SerializeField] private Sprite _switchOff;

    public event Action Switching;
    public bool IsOn { get; private set; }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            IsOn = !IsOn;

            if (IsOn)
            {
                Switching?.Invoke();
                _switcher.sprite = _switchOn;
            }
            else
            {
                _switcher.sprite = _switchOff;
            }
        }
    }
}
