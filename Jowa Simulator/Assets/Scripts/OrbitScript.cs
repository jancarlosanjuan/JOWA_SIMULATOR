using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbitScript : MonoBehaviour
{
	[SerializeField] Transform rotationCenter;
	[SerializeField] Joystick joystick;

	[SerializeField] private float angularSpeed = 0.0f;
	public float rotationRadius;

	float posX, posY, angle = 0f;
	private float oldWidth;
	private float height;
	private float width;
    void Start()
    {
		//rotationRadius =   (Screen.width)/ (Screen.width / 4);
		Camera cam = Camera.main;
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		rotationRadius = width / 4;
		oldWidth = width;
		
	}

	// Update is called once per frame
	void Update()
	{
		oldWidth = width;
		Camera cam = Camera.main;
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		if(oldWidth != width)
        {
			rotationRadius = width / 4;
		}
		
		posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
		posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
		transform.position = new Vector2(posX, posY);

		//rotation
		Vector3 diff = rotationCenter.position - transform.position;
		diff.Normalize();
		float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);

		if (Input.GetKey(KeyCode.A) || joystick.Horizontal < 0)
        {
			RotateClockwise();
		}
		else if (Input.GetKey(KeyCode.D) || joystick.Horizontal > 0)
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
