using UnityEngine;

public class FingerController : MonoBehaviour
{
    public Transform fingerBone;

    public SerialReader receiver;

    public string fingerName;

    public int minFlex;
    public int maxFlex;

    public float maxAngle = 60;

    Quaternion startRotation;

    void Start()
    {
        startRotation = fingerBone.localRotation;
    }

    void Update()
    {
        int flexValue = 0;

        switch(fingerName)
        {
            case "Thumb":
                flexValue = receiver.thumb;
                break;

            case "Index":
                flexValue = receiver.index;
                break;

            case "Middle":
                flexValue = receiver.middle;
                break;

            case "Ring":
                flexValue = receiver.ring;
                break;

            case "Little":
                flexValue = receiver.little;
                break;
        }

        float bend = Mathf.InverseLerp(
            minFlex,
            maxFlex,
            flexValue);

        float angle = Mathf.Lerp(
            0,
            maxAngle,
            bend);

        fingerBone.localRotation =
            startRotation *
            Quaternion.Euler(angle,0,0);
    }
}