using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour
{
    private Collider2D other;
    private bool hit = false;
    private bool collided = false;
    private GameManager gameManager;

    void Awake() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (collided)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                Debug.Log("key was pressed");
                gameManager.successfulHit(other);
                
            }
        }
    }

    // FixedUpdate is called oncer per fixed frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(horizontal, vertical, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collided = true;
        other = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collided = false;
        other = null;
    }

    public Collider2D getOther()
    {
        return other;
    }

    public bool wasHit()
    {
        return hit;
    }

    public void setHit(bool h)
    {
        hit = h;
    }

}