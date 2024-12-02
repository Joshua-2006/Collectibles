using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float camSensitivity;
    [SerializeField] private float thrust;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * thrust;

        rb.AddRelativeForce(movement, ForceMode.Impulse);

        transform.rotation = Quaternion.LookRotation(cam.transform.forward);

        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        cam.transform.Rotate(Vector3.up, h, Space.World);

        cam.transform.Rotate(Vector3.right, v, Space.Self);

    }
}
