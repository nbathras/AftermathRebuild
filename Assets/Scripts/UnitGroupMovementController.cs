using UnityEngine;

public class UnitGroupMovementController : MonoBehaviour {
    // Stores input from the PlayerInput
    private Vector2 movementInput;
    private Vector3 direction;
    private bool hasMoved;

    private void Awake() {
        movementInput = new Vector2(0, 0);
    }

    private void Update() {
        HandleMovementInput();
        Debug.Log(movementInput);

        if (movementInput.x == 0) {
            hasMoved = false;
        } else if (movementInput.x != 0 && !hasMoved) {
            hasMoved = true;
            GetMovementDirection();
        }
    }

    private void HandleMovementInput() {
        if (Input.GetKeyDown(KeyCode.W)) {
            movementInput += new Vector2(0, 1);
        }
        if (Input.GetKeyUp(KeyCode.W)) {
            movementInput = new Vector2(movementInput.x, 0);
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            movementInput -= new Vector2(0, 1);
        }
        if (Input.GetKeyUp(KeyCode.S)) {
            movementInput = new Vector2(movementInput.x, 0);
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            movementInput += new Vector2(1, 0);
        }
        if (Input.GetKeyUp(KeyCode.D)) {
            movementInput = new Vector2(0, movementInput.y);
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            movementInput -= new Vector2(1, 0);
        }
        if (Input.GetKeyUp(KeyCode.A)) {
            movementInput = new Vector2(0, movementInput.y);
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

    /*
    public void OnMove(InputAction.CallbackContext value) {
        movementInput = value.ReadValue<Vector2>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        transform.position -= direction;
    }
    */
}
