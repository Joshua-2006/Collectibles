using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float camSensitivity;
    [SerializeField] private float thrust;
    [SerializeField] private float jumpForce;
    public bool isGrounded;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump") && isGrounded)
        {
            rb.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
       
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(cam.transform.forward);
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * thrust;

        rb.AddRelativeForce(movement, ForceMode.Impulse);

        

        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        cam.transform.Rotate(Vector3.up, h * camSensitivity, Space.World);

        cam.transform.Rotate(Vector3.right, v * camSensitivity, Space.Self);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
