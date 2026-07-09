using UnityEngine;

public class SimpleGrab : MonoBehaviour
{
    public Transform hand;
    private bool grabbed = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            grabbed = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            grabbed = false;
        }

        if (grabbed)
        {
            transform.position = hand.position;
        }
    }
}