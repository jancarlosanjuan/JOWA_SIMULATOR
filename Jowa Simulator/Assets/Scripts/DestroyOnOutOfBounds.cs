using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnOutOfBounds : MonoBehaviour
{
    [SerializeField] private GameObject gamemanagerObject;
    private GameManager gamemanager;
    // Start is called before the first frame update
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        gamemanager.onEnemyDestroy();
        gamemanager.onBulletDestroy();
    }
}
