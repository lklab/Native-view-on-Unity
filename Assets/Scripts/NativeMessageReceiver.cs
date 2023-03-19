using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NativeMessageReceiver : MonoBehaviour
{
    public static event System.Action OnAddCount;

    public void AddCount(string message)
    {
        OnAddCount?.Invoke();
    }
}
