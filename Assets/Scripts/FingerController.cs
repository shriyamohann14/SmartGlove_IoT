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


        if(fingerName == "Thumb")
            flexValue = receiver.thumb;


        if(fingerName == "Index")
            flexValue = receiver.index;


        if(fingerName == "Middle")
            flexValue = receiver.middle;


        if(fingerName == "Ring")
            flexValue = receiver.ring;


        if(fingerName == "Little")
            flexValue = receiver.little;



        float bend =
        Mathf.InverseLerp(
            minFlex,
            maxFlex,
            flexValue
        );



        float angle =
        Mathf.Lerp(
            0,
            maxAngle,
            bend
        );



        fingerBone.localRotation =
        startRotation *
        Quaternion.AngleAxis(
            angle,
            Vector3.right
        );

    }
}