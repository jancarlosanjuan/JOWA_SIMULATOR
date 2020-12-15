using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOutofBounds : MonoBehaviour
{
    [SerializeField] private GameObject _gamemanager;
    private GameManager gamemanager;
    [SerializeField] private GameObject _text;
    private ChangeText text;
    [SerializeField] private GameObject _playerVariables;
    private PlayerVariables playervariables;

    private void Start()
    {
        gamemanager = _gamemanager.GetComponent<GameManager>();
        text = _text.GetComponent<ChangeText>();
        playervariables = _playerVariables.GetComponent<PlayerVariables>();
    }
    void Update()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x < 0 || screenPosition.x > Screen.width)
        {
            int health = playervariables.health - 1;
            playervariables.health = health - 1;
            Debug.Log("Health is: " + health);
            text.changeCurrencyText(health);

            if (health <= 0)
            {
                playervariables.gameObject.GetComponent<SceneChanger>().onButtonClicked();
            }
            gamemanager.destroyBoss(this.gameObject);
        }

    }
}
