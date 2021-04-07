using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            rb.AddForce(Vector2.right);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            rb.AddForce(Vector2.left);
        }
        animator.SetFloat("PosX", rb.velocity.normalized.x);
        animator.SetFloat("PosY", rb.velocity.normalized.y);
        animator.SetFloat("Speed", rb.velocity.magnitude);
        BoundsCheck();
    }

    private void BoundsCheck()
    {
        if(transform.position.x > 1.75f)
        {
            transform.position = new Vector3(1.75f, transform.position.y, 0.0f);
        }
        else if (transform.position.x < -1.75f)
        {
            transform.position = new Vector3(-1.75f, transform.position.y, 0.0f);
        }
        else if (transform.position.y > 0.9f)
        {
            transform.position = new Vector3(transform.position.x, 0.9f, 0.0f);
        }
        else if (transform.position.y < -0.9f)
        {
            transform.position = new Vector3(transform.position.x, -0.9f, 0.0f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Red"))
        {
            transform.position = new Vector3(1.5f, 0.0f, 0.0f); //restart
        }
        else if (collision.gameObject.CompareTag("Key"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
