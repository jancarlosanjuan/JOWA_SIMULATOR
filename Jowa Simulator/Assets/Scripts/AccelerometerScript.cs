using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private static AccelerometerScript _instance;

    public Action OnShake;
    [SerializeField] private float ShakeDetectionThreshold = 2.0f;
    private float accelerometerUpdateInterval = 1.0f / 60.0f;
    private float lowPassKernelWidthInSeconds = 1.0f;
    private float lowPassFilterFactor;
    private Vector3 lowPassValue;

    public static AccelerometerScript Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AccelerometerScript>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<AccelerometerScript>();
                }
            }
            return _instance;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        ShakeDetectionThreshold *= ShakeDetectionThreshold;
        lowPassValue = Input.acceleration;
    }

    private void Update()
    {
        Vector3 acceleration = Input.acceleration;
        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
        Vector3 deltaAcceleration = acceleration - lowPassValue;

        if (deltaAcceleration.sqrMagnitude >= ShakeDetectionThreshold)
            OnShake?.Invoke();
    }
}
