using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleScript : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _countText;
    [SerializeField] private Button _showButton;
    [SerializeField] private Button _hideButton;
    [SerializeField] private Button _addCountButton;

    private AndroidJavaObject mViewController;

    private int mCount = 0;

    private void Awake()
    {
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
        mViewController = new AndroidJavaObject("com.khlee.androidview.ViewController", unityActivity);

        _showButton.onClick.AddListener(delegate
        {
            mViewController.Call("show");
        });
        _hideButton.onClick.AddListener(delegate
        {
            mViewController.Call("hide");
        });
        _addCountButton.onClick.AddListener(delegate
        {
            mViewController.Call("addCount");
        });

        mCount = 0;
        SetCountText(mCount);
        NativeMessageReceiver.OnAddCount += delegate
        {
            mCount++;
            SetCountText(mCount);
        };
    }

    private void SetCountText(int count)
    {
        _countText.text = "unity count: " + count.ToString();
    }
}
