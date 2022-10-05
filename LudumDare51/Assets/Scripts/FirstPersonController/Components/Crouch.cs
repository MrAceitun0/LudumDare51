using System.Collections;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    public float crouchYLocalPosition = 1;
    public Transform head;
    [HideInInspector]
    public float defaultHeadYLocalPosition;
    public float crouchTime = 0.2f;

    [Tooltip("Capsule collider to lower when we crouch.\nCan be empty.")]
    public CapsuleCollider capsuleCollider;
    [HideInInspector]
    public float defaultCapsuleColliderHeight;

    [SerializeField]
    GroundCheck groundCheck;

    public KeyCode[] keys = new KeyCode[] { KeyCode.LeftControl, KeyCode.RightControl };
    public bool IsCrouched { get; private set; }
    public event System.Action CrouchStart, CrouchEnd;


    void Reset()
    {
        head = GetComponentInChildren<Camera>().transform;

        capsuleCollider = GetComponentInChildren<CapsuleCollider>();

        // Get or create the groundCheck object.
        groundCheck = GetComponentInChildren<GroundCheck>();
        if (!groundCheck)
            groundCheck = GroundCheck.Create(transform);
    }

    void Start()
    {
        defaultHeadYLocalPosition = head.localPosition.y;
        if (capsuleCollider)
            defaultCapsuleColliderHeight = capsuleCollider.height;
    }

    void LateUpdate()
    {
        if (IsKeyPressed(keys))
        {
            // Enforce crouched y local position of the head.
            StartCoroutine(LerpFunction(crouchYLocalPosition, crouchTime));

            // Lower the capsule collider.
            if (capsuleCollider)
            {
                capsuleCollider.height = defaultCapsuleColliderHeight - (defaultHeadYLocalPosition - crouchYLocalPosition);
                capsuleCollider.center = Vector3.up * capsuleCollider.height * .5f;
            }

            // Set state.
            if (!IsCrouched)
            {
                IsCrouched = true;
                CrouchStart?.Invoke();
            }
        }
        else if (IsCrouched)
        {
            // Reset the head to its default y local position.
            StartCoroutine(LerpFunction(defaultHeadYLocalPosition, crouchTime));

            // Reset the capsule collider's position.
            if (capsuleCollider)
            {
                capsuleCollider.height = defaultCapsuleColliderHeight;
                capsuleCollider.center = Vector3.up * capsuleCollider.height * .5f;
            }

            // Reset state.
            IsCrouched = false;
            CrouchEnd?.Invoke();
        }
    }

    static bool IsKeyPressed(KeyCode[] keys)
    {
        // Return true if any of the keys are down.
        for (int i = 0; i < keys.Length; i++)
            if (Input.GetKey(keys[i]))
                return true;
        return false;
    }

    IEnumerator LerpFunction(float endValue, float duration)
    {
        float time = 0;
        float startValue = head.localPosition.y;

        while (time < duration)
        {
            head.localPosition = new Vector3(head.localPosition.x, Mathf.Lerp(startValue, endValue, time / duration), head.localPosition.z);
            time += Time.deltaTime;
            yield return null;
        }

        head.localPosition = new Vector3(head.localPosition.x, endValue, head.localPosition.z);
    }
}
