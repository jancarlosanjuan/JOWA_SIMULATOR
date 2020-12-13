using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnOutofBounds : MonoBehaviour
{
    [SerializeField] GameObject _gamemanager;
    private GameManager gamemanager;

    private void Start()
    {
        gamemanager = _gamemanager.GetComponent<GameManager>();
    }
    void Update()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x < 0 || screenPosition.x > Screen.width)
            gamemanager.destroyBullet(this.gameObject);
    }
    
}
