using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput input;
    NavMeshAgent agent;
    Animator animator;

    [Header("Movement")]
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;
    [SerializeField] LayerMask interactableLayers;

    float lookRotationSpeed = 8f;

    // New fields for delayed interaction
    bool isMovingToInteractable = false;
    IIteractable currentInteractable;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        input = new PlayerInput();
        AssignInputs();
    }

    private void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClickToMove();
        input.Main.Interact.performed += ctx => TryInteract();
    }

    void ClickToMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            // If it's not interactable, move to the clicked point
            if (!isMovingToInteractable)
            {
                agent.destination = hit.point;
                if (clickEffect != null)
                {
                    Instantiate(clickEffect, hit.point + new Vector3(0, 0.1f, 0), clickEffect.transform.rotation);
                }
            }
        }
    }

    void TryInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, interactableLayers))
        {
            // Check if the clicked object is an interactive object
            if (hit.transform.TryGetComponent<IIteractable>(out var interactable))
            {
                // Move to the interactable object before interacting
                isMovingToInteractable = true;
                currentInteractable = interactable;
                agent.destination = hit.point;
            }
        }
    }

    void Update()
    {
        FaceTarget();
        SetAnimations();

        // Check if reached the destination and trigger interaction
        if (isMovingToInteractable && !agent.pathPending && agent.remainingDistance < 0.1f)
        {
            // Interaction
            currentInteractable?.Interact();

            // Reset state
            isMovingToInteractable = false;
            currentInteractable = null;
        }
    }

    void FaceTarget()
    {
        // Check if the agent is currently moving
        if (agent.velocity.magnitude > 0.2f)
        {
            Vector3 direction = agent.velocity.normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
        }
    }

    void SetAnimations()
    {
        if (agent.velocity == Vector3.zero)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }
}
