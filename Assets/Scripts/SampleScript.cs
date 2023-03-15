using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleScript : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(delegate
        {
            AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject myTest = new AndroidJavaObject("com.khlee.androidview.MyTest", unityActivity);
            //AndroidJavaClass myClass = new AndroidJavaClass("com.khlee.androidview.MyKotlin");
            //AndroidJavaObject myObject = myClass.GetStatic<AndroidJavaObject>("Companion").Call<AndroidJavaObject>("getInstance", unityActivity);
            //myObject.Call("showToast", "hellos");
        });
    }
}
