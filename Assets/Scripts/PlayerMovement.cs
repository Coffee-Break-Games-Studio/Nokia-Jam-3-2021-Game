using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float thrust = 2000.0f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 horizontal = transform.right * Input.GetAxisRaw("Horizontal");
        Vector3 vertical = transform.up * Input.GetAxisRaw("Vertical");

        rb.AddForce((horizontal + vertical) * thrust);
    }
}
