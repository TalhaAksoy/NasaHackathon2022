using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float petMoveSpeed = 12f;
    public float jumpTime = 0; 

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    // Start is called before the first frame update

    [SerializeField]
    private GameObject pet;
  
    Vector3 offset;
    void Start()
    {
        offset = pet.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            if(jumpTime < Time.realtimeSinceStartup)
            {
                jumpTime = Time.realtimeSinceStartup + 1.5f;
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            }
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        Vector3 newPos = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, transform.position.z + offset.z);

        pet.transform.position = Vector3.Lerp(pet.transform.position, newPos, speed * Time.deltaTime * petMoveSpeed);

        if (x != 0 || z != 0)
        {
            if (pet.GetComponentInChildren<ParticleSystem>().isPlaying == false)
                pet.GetComponentInChildren<ParticleSystem>().Play();
        }
        else if(x == 0 && z == 0)
        {
            if (pet.GetComponentInChildren<ParticleSystem>().isPlaying == true)
                pet.GetComponentInChildren<ParticleSystem>().Stop();
        }

    }
}
