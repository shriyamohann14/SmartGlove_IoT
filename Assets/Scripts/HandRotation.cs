using UnityEngine;

public class HandRotation : MonoBehaviour
{
    public SerialReader receiver;

    public float smoothSpeed = 5f;

    private Quaternion targetRotation;

    void Start()
    {
        targetRotation = transform.localRotation;
    }

    void Update()
    {
        // Normalize accelerometer values
        float ax = receiver.ax / 16384f;
        float ay = receiver.ay / 16384f;
        float az = receiver.az / 16384f;

        // Calculate pitch and roll
        float pitch = Mathf.Atan2(ay, Mathf.Sqrt(ax * ax + az * az)) * Mathf.Rad2Deg;
        float roll = Mathf.Atan2(-ax, az) * Mathf.Rad2Deg;

        // Clamp unrealistic values
        pitch = Mathf.Clamp(pitch, -80f, 80f);
        roll = Mathf.Clamp(roll, -80f, 80f);

        // Adjust axes if required
        targetRotation = Quaternion.Euler(
            pitch,
            0,
            -roll
        );

        transform.localRotation = Quaternion.Slerp(
            transform.localRotation,
            targetRotation,
            smoothSpeed * Time.deltaTime
        );
    }
}