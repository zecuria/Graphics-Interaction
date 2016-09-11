using UnityEngine;
using System.Collections;

public class CamMove : MonoBehaviour
{

    // bool to determine whether it has collided or not

    public float mouseSensitivity = 300.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    // Use this for initialization
    void Start ()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

    }
	
	// Update is called once per frame
	void Update ()
    {
        var rotateSpeed = 25.0f;
        var speed = 50.0f;

        var transAmount = speed * Time.deltaTime;
        var rotateAmount = rotateSpeed * Time.deltaTime;

        // rotate cam clockwise
        if (Input.GetKey("q"))
        {
            transform.Rotate(0, 0, rotateAmount);
        }

        // rotate cam anticlockwise
        if (Input.GetKey("e"))
        {
            transform.Rotate(0, 0, -rotateAmount);
        }

        // move camera forward
        if (Input.GetKey("w"))
        {
            transform.Translate(0, 0, transAmount);
        }

        // reverse camera
        if (Input.GetKey("s"))
        {
            transform.Translate(0, 0, -(transAmount));
        }

        // move cam left
        if (Input.GetKey("a"))
        {
            transform.Translate(-(transAmount), 0, 0);
        }

        // move cam right
        if (Input.GetKey("d"))
        {
            transform.Translate(transAmount, 0, 0);
        }

        // controls mouse movement: pitch and yaw

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

    }

    void onCollisionEnter(Collider col)
    {
        Debug.Log("True");
    }
}
