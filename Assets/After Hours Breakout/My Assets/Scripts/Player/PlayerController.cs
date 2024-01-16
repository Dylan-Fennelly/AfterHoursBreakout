using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

//Script based on https://github.com/ItsPogle/Unity-Mouse-Click-Movement-Template/blob/main/Episode%201%20-%20Mouse%20Click%20Movement/Scripts/PlayerController.cs
public class PlayerController : MonoBehaviour
{
    PlayerInput input;
    NavMeshAgent agent;
    Animator animator;
    [Header("Movement")]
    [SerializeField]
    private float interactionDistanceThreashold = 1f;
    [SerializeField]
    private bool canMove = true;
    [SerializeField]
    ParticleSystem clickEffect;
    [SerializeField] 
    LayerMask clickableLayers;
    [SerializeField]
    LayerMask interactableLayers;

    float lookRotationSpeed = 8f;

    bool hasKey = false;

    bool isMovingToInteractable = false;
    IInteractable currentInteractable;


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
        // Check if movement is allowed
        if (canMove)
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
    }

    void TryInteract()
    {
        // Check if movement is allowed
        if (canMove)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, interactableLayers))
            {
                // Check if the clicked object is an interactive object
                if (hit.transform.TryGetComponent<IInteractable>(out var interactable))
                {
                    // Move to the interactable object before interacting
                    isMovingToInteractable = true;
                    currentInteractable = interactable;
                    agent.destination = hit.point;
                }
            }
        }
    }

    void Update()
    {
        FaceTarget();
        SetAnimations();

        // Check if reached the destination and trigger interaction
        if (isMovingToInteractable && !agent.pathPending && agent.remainingDistance < interactionDistanceThreashold)
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
        animator.SetBool("isWalking", agent.velocity != Vector3.zero);
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }
    public void setHasKey()
    {
        hasKey = true;
    }
}
