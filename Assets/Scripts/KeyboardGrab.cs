using UnityEngine;

public class KeyboardGrab : MonoBehaviour
{
    public Transform hand;

    private bool grabbed = false;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Grab
        if (Input.GetKeyDown(KeyCode.G) && !grabbed)
        {
            grabbed = true;

            transform.SetParent(hand);

            transform.localPosition = new Vector3(0f, 0f, 0.15f);

            transform.localRotation = Quaternion.identity;
        }

        // Release
        if (Input.GetKeyDown(KeyCode.R) && grabbed)
        {
            grabbed = false;

            transform.SetParent(null);
        }
    }
}