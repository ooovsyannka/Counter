using System;
using UnityEngine;

public class Tumbler : MonoBehaviour
{
    public event Action Switching;

    public bool IsOn { get; private set; }

    private void Update()
    {
        Turn();
    }

    private void Turn()
    {
        if (Input.GetMouseButtonUp(0))
        {
            IsOn = !IsOn;

            Switching?.Invoke();
        }
    }
}
