using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleScript : MonoBehaviour
{
    [SerializeField] private Button _button;

    private AndroidJavaObject mViewController;

    private void Awake()
    {
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
        mViewController = new AndroidJavaObject("com.khlee.androidview.ViewController", unityActivity);

        _button.onClick.AddListener(delegate
        {
            mViewController.Call("show");
        });
    }
}
