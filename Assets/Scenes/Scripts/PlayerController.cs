using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f; // how fast we will make player move towards the point 
    public Transform movePoint; // the player will move towards this movePoint

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        // https://docs.unity3d.com/ScriptReference/Vector3.MoveTowards.html
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        // https://docs.unity3d.com/ScriptReference/Vector3.Distance.html
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f) {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal")*10f, 0f, 0f); //before... 1f, 0f, 0f
        } else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical")*10f, 0f);
            }
        }

    }
}
