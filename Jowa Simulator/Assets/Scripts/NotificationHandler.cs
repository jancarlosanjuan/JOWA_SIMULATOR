using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationHandler : MonoBehaviour
{
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

    /*public void SendNotif(int score)
    {
        string title = "Your Score";
        string text = "Your score in your previous run was: " + score;

        System.DateTime firetime = System.DateTime.Now.AddSeconds(10);

        Debug.Log("Sending Notification. Previous score: " + score);
        AndroidNotification notif = new AndroidNotification(title, text, firetime);
        AndroidNotificationCenter.SendNotification(notif, "default");
    }*/
}
