using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationHandler : MonoBehaviour
{
    private System.TimeSpan interval;
    private void BuildDefaultNotifChannel()
    {
        string channel_id = "default";
        string title = "Default Channel";
        Importance importance = Importance.Default;
        string desc = "Default channel for this game";

        AndroidNotificationChannel channel = new AndroidNotificationChannel(channel_id, title, desc, importance);
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void Awake()
    {
        BuildDefaultNotifChannel();
    }

    private void Start()
    {
        interval = new System.TimeSpan(72, 0, 0);
    }

    public void ChangeInterval()
    {
        Debug.Log("Notification interval changed!");
        System.TimeSpan interval = new System.TimeSpan(0, 1, 0);
    }

    public void SendNotif()
    {
        string title = "Jowa in distress!";
        string text = "Your jowa is in trouble from your rivals! Play Jowa Simulator now!";

        System.DateTime firetime = System.DateTime.Now.AddSeconds(10);

        Debug.Log("Sending notification!");
        AndroidNotification notif = new AndroidNotification(title, text, firetime, interval);
        AndroidNotificationCenter.SendNotification(notif, "repeat");
    }

    private void OnApplicationQuit()
    {
        SendNotif();
    }
}
