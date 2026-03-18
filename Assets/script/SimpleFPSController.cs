using UnityEngine;

public class SimpleFPSController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float runMultiplier = 1.8f;
    public float mouseSensitivity = 2f;
    public float gravity = -9.8f;

    float yRotation = 0f;
    float verticalVelocity;
    CharacterController controller;
    Transform cam;

    void Start()
    {
        controller = GetComponent<CharacterController>(); // ✅ แก้ตรงนี้
        cam = Camera.main.transform;

        if (Time.timeScale == 1f)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 100f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 100f * Time.deltaTime;

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -80f, 80f);
        cam.localRotation = Quaternion.Euler(yRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);

        // Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        float speed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = moveSpeed * runMultiplier;
        }

        // Gravity
        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 velocity = move * speed;
        velocity.y = verticalVelocity;

        controller.Move(velocity * Time.deltaTime);
    }
}
