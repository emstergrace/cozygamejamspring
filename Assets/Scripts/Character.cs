using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{

    [SerializeField] 
    private float moveSpeed;

    [SerializeField]
    private float sprintSpeed;

    private bool sprint = false;

    private CharacterController controller;
    private Animator animator;
    private PlayerInputActions inputActions;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();
        inputActions.Player.Sprint.started += ToggleSprint;
        inputActions.Player.Sprint.canceled += ToggleSprint;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = inputActions.Player.Move.ReadValue<Vector2>();

        Move(inputVector);

        Rotate(inputVector);

        Animate(inputVector);
    }

    private void Move(Vector2 inputVector)
    {
        float speed = sprint ? sprintSpeed : moveSpeed;

        Vector3 moveVector = new Vector3(inputVector.x * speed * Time.deltaTime, 0, inputVector.y * speed * Time.deltaTime);
        controller.Move(moveVector);
    }

    private void Rotate(Vector2 inputVector)
    {
        if (inputVector == Vector2.zero) return;

        float rotation = Vector2.Angle(Vector2.up, inputVector) * Mathf.Sign(inputVector.x);
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, rotation, this.transform.eulerAngles.z);
    }

    private void Animate(Vector2 inputVector)
    {
        animator.SetBool("moving", inputVector != Vector2.zero);
        animator.SetBool("sprint", this.sprint);
    }

    private void ToggleSprint(InputAction.CallbackContext obj)
    {
        this.sprint = !this.sprint;
    }
}
