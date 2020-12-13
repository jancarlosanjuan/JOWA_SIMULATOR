using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbitScript : MonoBehaviour
{
	[SerializeField] Rigidbody2D character;
	[SerializeField] Transform rotationCenter;
	[SerializeField] Button aButton;
	[SerializeField] Button dButton;

	[SerializeField] float rotationRadius = 100.0f, angularSpeed = 0.0f;

	float posX, posY, angle = 0f;

    void Start()
    {
		
	}

	// Update is called once per frame
	void Update()
	{

		posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
		posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
		transform.position = new Vector2(posX, posY);

		if (Input.GetKey(KeyCode.A))
        {
			RotateClockwise();
		}
		else if (Input.GetKey(KeyCode.D))
        {
			RotateCounterClockwise();
		}
		
	}

	public void RotateClockwise()
    {
		angularSpeed = -1.0f * GlobalManager.Instance.SpeedMultiplier;
		angle = angle + Time.deltaTime * angularSpeed;
	} 

	public void RotateCounterClockwise()
    {
		angularSpeed = 1.0f * GlobalManager.Instance.SpeedMultiplier;
		angle = angle + Time.deltaTime * angularSpeed;
	}
}
