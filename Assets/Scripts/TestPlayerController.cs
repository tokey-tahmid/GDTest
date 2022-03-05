using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestPlayerController : MonoBehaviour
{
    [Range(0.1f, 10f)]
    public float jumpVelocity;
    public float movementSpeed = 10f;
    public float forwardMoveSpeed = 0.1f;
    public float distToGround = 0.3f;
    Rigidbody rb;
    public Joystick joystick;
    public GameObject gameOver;
    public GameObject gameLevel;
    private int gemNum = 0;
    public float fallMultiplier = 2.5f;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();  
    }

    private void Update()
    {
        float hMovement = joystick.Horizontal * movementSpeed;
        transform.Translate(new Vector3(hMovement, 0, 0) * Time.deltaTime);
        
        transform.Translate(Vector3.forward * Time.deltaTime * forwardMoveSpeed, Space.World);

        
        if (isGrounded)
        {
            rb.velocity += (Vector3.up * jumpVelocity);
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        if (gemNum > 3)
        {
            Time.timeScale = 1.3f;
        } 
        else if (gemNum > 5) 
        {
            Time.timeScale = 1.5f;
        }
        else if (gemNum > 10)
        {
            Time.timeScale = 2f;
        }

    }

    private void FixedUpdate() 
    {
        GroundCheck();
    }

    public bool isGrounded = false;

    void GroundCheck ()
    {
        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f))
        {
            isGrounded = true;
        } else 
        {
            isGrounded = false;
        }
    }

    public AudioSource PointFX;
    public AudioSource GemFX;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            PointFX.Play();
            GemUI.pointCount += 1;
        }
        if (other.tag == "Gem")
        {
            GemFX.Play();
            GemUI.gemCount += 1;
            gemNum++;
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Respawn")
        {
            GameReset();
        }
    }
    public void GameReset()
    {
        gemNum = 0;
        gameOver.SetActive(true);
        gameLevel.SetActive(false);
    }
}
