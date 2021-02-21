using UnityEngine;
using UnityEngine.InputSystem;


public class UnitGroupMovementController : MonoBehaviour {
    // Stores input from the PlayerInput
    private Vector2 movementInput;
    private Vector3 direction;
    private bool hasMoved;

    private void Update() {
        if (movementInput.x == 0) {
            hasMoved = false;
        } else if (movementInput.x != 0 && !hasMoved) {
            hasMoved = true;
            GetMovementDirection();
        }
    }
    private void GetMovementDirection() {
        if (movementInput.x < 0) {
            if (movementInput.y > 0) {
                direction = new Vector3(-0.5f, 0.5f);
            } else if (movementInput.y < 0) {
                direction = new Vector3(-0.5f, -0.5f);
            } else {
                direction = new Vector3(-1, 0, 0);
            }
            transform.position += direction;
        } else if (movementInput.x > 0) {
            if (movementInput.y > 0) {
                direction = new Vector3(0.5f, 0.5f);
            } else if (movementInput.y < 0) {
                direction = new Vector3(0.5f, -0.5f);
            } else {
                direction = new Vector3(1, 0, 0);
            }

            transform.position += direction;
        }
    }

    public void OnMove(InputAction.CallbackContext value) {
        movementInput = value.ReadValue<Vector2>();
    }


    /*
    private void OnCollisionEnter2D(Collision2D collision) {
        transform.position -= direction;
    }
    */
}
