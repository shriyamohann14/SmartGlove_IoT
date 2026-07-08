using UnityEngine;

public class FingerController : MonoBehaviour
{
    [Header("References")]
    public Transform fingerBone;
    public SerialReader receiver;

    [Header("Finger")]
    public string fingerName;

    [Header("Calibration")]
    public int minFlex;
    public int maxFlex;
    public float maxAngle = 60f;

    [Header("Smoothing")]
    public float smoothSpeed = 12f;

    private Quaternion startRotation;

    void Start()
    {
        if (fingerBone == null)
        {
            Debug.LogError(gameObject.name + " : Finger Bone not assigned!");
            enabled = false;
            return;
        }

        if (receiver == null)
        {
            Debug.LogError(gameObject.name + " : SerialReader not assigned!");
            enabled = false;
            return;
        }

        startRotation = fingerBone.localRotation;
    }

    void Update()
    {
        int flexValue = GetFingerValue();

        float bend = Mathf.InverseLerp(minFlex, maxFlex, flexValue);
        bend = Mathf.Clamp01(bend);

        float angle = Mathf.Lerp(0f, maxAngle, bend);

        Quaternion targetRotation =
            startRotation *
            Quaternion.AngleAxis(angle, Vector3.right);

        fingerBone.localRotation = Quaternion.Slerp(
            fingerBone.localRotation,
            targetRotation,
            smoothSpeed * Time.deltaTime
        );

        if (fingerName.Trim() == "Ring")
        {
            Debug.Log(
                $"Ring -> Flex:{flexValue}  Bend:{bend:F2}  Angle:{angle:F1}"
            );
        }
    }

    int GetFingerValue()
    {
        switch (fingerName.Trim())
        {
            case "Thumb":
                return receiver.thumb;

            case "Index":
                return receiver.index;

            case "Middle":
                return receiver.middle;

            case "Ring":
                return receiver.ring;

            case "Little":
                return receiver.little;

            default:
                return 0;
        }
    }
}