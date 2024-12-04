using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Movement : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    public Transform move;
    [SerializeField] private float camSensitivity;
    public float thrust;
    [SerializeField] private float jumpForce;
    public bool isGrounded;
    private Rigidbody rb;
    private Clock clock;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        clock = GetComponent<Clock>();
        gm = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
       
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(move.forward);
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0, 0, vertical) * thrust;

        //rb.AddRelativeForce(movement, ForceMode.Impulse);

        transform.position = transform.position + Camera.main.transform.forward * vertical * thrust * Time.deltaTime;
        //rb.AddRelativeForce(transform.position * vertical * thrust, ForceMode.Impulse);

        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        //cam.transform.Rotate(Vector3.up, h * camSensitivity, Space.World);

       // cam.transform.Rotate(Vector3.right, vertical * camSensitivity, Space.Self);

       // if(Input.GetButtonDown(""))
        //{

       // }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Cookie"))
        {
            thrust += 1;
        }
    }
}
