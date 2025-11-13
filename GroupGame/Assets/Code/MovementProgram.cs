using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;

public class MovementProgram : MonoBehaviour
{
    public float horizontal;
    public float speed = 8f;
    public bool isFacingRight = true;
    Vector2 movement = Vector2.zero;
    public Vector2 movementDirection;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask Checkpoint;

    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (SceneManager.GetActiveScene().name == "SecretArea")
        {
            StartCoroutine(ChangeAfter4SecondsCoroutine());
        }

        GameObject ShopUI = GameObject.FindWithTag("Shop");
        if (ShopUI != null)
        {
            speed = 0;
        }
        else
        {
            speed = 8;
        }
        Flip();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Checkpoint"))
        {
            Debug.Log("On Checkpoint");
        }
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("GameLevel");
    }

    IEnumerator ChangeAfter4SecondsCoroutine()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("GameLevel");
    }

}
