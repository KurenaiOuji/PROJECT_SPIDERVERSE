using System;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    public static Action OnPastUnlock;
    public static Action OnFutureUnlock;

    public void PastUnlock()
    {
        OnPastUnlock?.Invoke();
    }

    public void FutureUnlock()
    {
        OnFutureUnlock?.Invoke();
    }
}
