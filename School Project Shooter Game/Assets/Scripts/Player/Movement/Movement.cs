using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;

public class Movement : MonoBehaviour {

    PhotonView view;

    public float walkSpeed = 4f;
    public float maxVelocityChange = 10f;

    private Vector2 input;
    private Rigidbody rb;

    void Start() {

        rb = GetComponent<Rigidbody>();
        view.GetComponent<PhotonView>();
    }

    void Update() {

        if (view.IsMine) {

            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            input.Normalize();
        }
    }

    void FixedUpdate() {

        if (view.IsMine) {
            rb.AddForce(CalculateMovement(walkSpeed), ForceMode.VelocityChange);
        }
    }

    Vector3 CalculateMovement(float _speed) {

        if (view.IsMine) {
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
}
