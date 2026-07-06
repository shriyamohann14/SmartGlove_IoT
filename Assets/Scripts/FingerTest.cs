using UnityEngine;

public class FingerTest : MonoBehaviour
{
    public Transform fingerBone;

    public ESP32Receiver receiver;

    public float minFlex = 300f;
    public float maxFlex = 800f;

    public float minAngle = 0f;
    public float maxAngle = 60f;

    private Quaternion initialRotation;


    void Start()
    {
        initialRotation = fingerBone.localRotation;
    }


    void Update()
    {
        if(receiver != null)
        {
            float flexValue = receiver.flexValue;


            float angle = Mathf.Lerp(
                minAngle,
                maxAngle,
                Mathf.InverseLerp(minFlex, maxFlex, flexValue)
            );


            fingerBone.localRotation =
                initialRotation *
                Quaternion.AngleAxis(angle, Vector3.up);
        }
    }
}