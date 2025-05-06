using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;

public class Movement : MonoBehaviourPunCallbacks {

    // This script is to make movement for the player possible (Multiplayer)

    PhotonView view;

    [Header ("Values")]
    // Speed and max velocity
    public float walkSpeed = 8f;
    public float sprintSpeed = 14f;
    public float maxVelocityChange = 10f;

    // Control of player while in air
    public float airControlWalking = 0.4f;
    public float airControlRunning = 0.25f;

    public float jumpHeight = 5; // How high you can jump

    [Header("Essentials")]
    private Vector2 input;
    private Rigidbody rb;

    [Header("Bools")]
    private bool sprinting; // Check if sprinting
    private bool jumping; // Check if jumping

    [Header("Grounded")]
    private bool grounded = false; // Auto sets grounded at false

    void Start() {

        // Get the components so they work properly
        rb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();
    }

    void Update() {

        if (view.IsMine) {

            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // Get both horizontal and vertical axis, makes movement possible
            input.Normalize();

            // Button to:
            sprinting = Input.GetButton("Sprint");
            jumping = Input.GetButton("Jump");

        }
    }

    private void OnTriggerStay(Collider other) {

            grounded = true; // Sets grounded to true if trigger collider touches smt
    }

    void FixedUpdate() {

        if (view.IsMine) {

            if (grounded) {

                if (jumping) {

                    rb.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange); // If grounded and jumping you can jump (pretty much what it says XD)
                } else if (input.magnitude > 0.5f) {

                    rb.AddForce(CalculateMovement(sprinting ? sprintSpeed : walkSpeed), ForceMode.VelocityChange); // Calculate walk and sprint speed depending on what your doing
                } else {

                    var velocity1 = rb.angularVelocity;
                    velocity1 = new Vector3(velocity1.x * 0.2f * Time.fixedDeltaTime,
                        velocity1.y,
                        velocity1.z * 0.2f * Time.fixedDeltaTime);

                    rb.angularVelocity = velocity1;
                }
            } else {

                if (input.magnitude > 0.5f) {

                    rb.AddForce(CalculateMovement(sprinting ? sprintSpeed * airControlRunning : walkSpeed * airControlWalking), ForceMode.VelocityChange); // Calculate walk and sprint aircontrol depending on what your doing
                } else {

                    var velocity1 = rb.angularVelocity;
                    velocity1 = new Vector3(velocity1.x * 0.2f * Time.fixedDeltaTime,
                        velocity1.y,
                        velocity1.z * 0.2f * Time.fixedDeltaTime);

                    rb.angularVelocity = velocity1;
                }
            }

            grounded = false;
        }
    }

    Vector3 CalculateMovement(float _speed) { // All of this is pretty much to calculate movement and speed

            Vector3 targetVelocity = new Vector3(input.x, 0, input.y);
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= _speed;

            Vector3 velocity = rb.linearVelocity;

            if (input.magnitude > 0.5f) {

                Vector3 velocityChange = targetVelocity - velocity;

                velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
                velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
                velocityChange.y = 0;

                return velocityChange;
            } else {

                return new Vector3();
        }
    }
}
