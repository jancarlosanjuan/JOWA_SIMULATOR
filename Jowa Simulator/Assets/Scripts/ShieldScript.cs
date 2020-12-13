using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private GameManager gamemanager;
    [SerializeField] private GameObject gamemanagerObject;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = gamemanagerObject.GetComponent<GameManager>();
        AccelerometerScript.Instance.OnShake += Begone;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Begone();
        }
    }

    private void OnDestroy()
    {
        AccelerometerScript.Instance.OnShake -= Begone;
    }

    public void Begone()
    {
        if(GlobalManager.Instance.Shields > 0)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < gameObjects.Length; i++)
            {
                gamemanager.enemyContainer.Remove(gameObjects[i]);
                Destroy(gameObjects[i]);
            }
            GlobalManager.Instance.Shields--;
            Debug.Log("Enemies: " + gamemanager.enemyContainer.Count);
        }
    }

}
