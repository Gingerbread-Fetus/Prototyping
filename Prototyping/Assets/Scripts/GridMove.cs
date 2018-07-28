using System.Collections;
using UnityEngine;

class GridMove : MonoBehaviour
{
    public bool allowDiagonals = false;
    private float moveSpeed = 3f;
    private float gridSize = 1f;
    private enum Orientation
    {
        Horizontal,
        Vertical
    };
    private Orientation gridOrientation = Orientation.Horizontal;
    private bool correctDiagonalSpeed = true;
    private Vector2 input;
    private bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Quaternion startRotation;
    private Quaternion endRotation;
    RaycastHit objectHitForward;
    RaycastHit objectHitBackward;
    RaycastHit objectHitLeft;
    RaycastHit objectHitRight;
    private float t;
    private float factor;
    private float rotation;

    //TODO: Raycast hits on enemies count as collisions and trigger battle.
    public void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 backward = transform.TransformDirection(-Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 left = transform.TransformDirection(Vector3.left);
        Debug.DrawRay(transform.position, forward, Color.green);
        Debug.DrawRay(transform.position, backward, Color.green);
        Debug.DrawRay(transform.position, left, Color.green);
        Debug.DrawRay(transform.position, right, Color.green);
        if (Physics.Raycast(transform.position, forward, out objectHitForward, 1)){}
        if (Physics.Raycast(transform.position, backward, out objectHitBackward, 1)){}
        if (Physics.Raycast(transform.position, left, out objectHitLeft, 1)){}
        if (Physics.Raycast(transform.position, right, out objectHitRight, 1)){}
        if (!isMoving)
        {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            rotation = Input.GetAxis("Turn");
            if (!allowDiagonals)
            {
                if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                {
                    input.y = 0;
                }
                else
                {
                    input.x = 0;
                }
            }

            if (input.y != 0)
            {
                ForwardMovement();
            }

            if (input.x != 0)
            {
                SideMovement(); 
            }

            if (input == Vector2.zero && rotation != 0f)
            {
                StartCoroutine(Rotate(Vector3.up * 90 * Mathf.Sign(rotation), 0.8f));
            }
        }
    }

    private void SideMovement()
    {
        if (objectHitLeft.collider == null && objectHitRight.collider == null)
        {
            StartCoroutine(Sidestep(transform));
        }
        else if (objectHitRight.collider != null && input.x > 0)//Something to right, moving right
        {
            switch (objectHitRight.collider.tag)
            {
                case "Wall": //Player should bounce back
                    StartCoroutine(BounceBack(transform));
                    break;
                case "Enemy"://Player should move normally
                    Debug.Log("Enemy detected, but this isn't implemented yet");
                    StartCoroutine(Sidestep(transform));
                    break;
                default:
                    Debug.Log("Unknown tag detected");
                    break;
            }
        }
        else if (objectHitRight.collider != null && input.x < 0)//Something to right, moving left
        {
            if (objectHitLeft.collider == null) { StartCoroutine(Sidestep(transform)); }//If opposite collider is null move normally
            else
            {
                switch (objectHitLeft.collider.tag)
                {
                    case "Wall": //Player should bounce back
                        StartCoroutine(BounceBack(transform));
                        break;
                    case "Enemy"://Player should move normally
                        Debug.Log("Enemy detected, but this isn't implemented yet");
                        StartCoroutine(Sidestep(transform));
                        break;
                    default:
                        Debug.Log("Unknown tag detected");
                        break;
                }
            }
        }
        else if (objectHitLeft.collider != null && input.x < 0)//Something to left moving left
        {
            switch (objectHitLeft.collider.tag)
            {
                case "Wall":
                    StartCoroutine(BounceBack(transform));
                    break;
                case "Enemy"://Player should move normally
                    Debug.Log("Enemy detected, but this isn't implemented yet");
                    StartCoroutine(Sidestep(transform));
                    break;
                default:
                    Debug.Log("Unknown tag detected");
                    break;
            }
        }
        else if (objectHitLeft.collider != null && input.x > 0)//Something to left, moving right
        {
            if (objectHitRight.collider == null) { StartCoroutine(Sidestep(transform)); }//If opposite collider is null move normally
            else
            {
                switch (objectHitRight.collider.tag)
                {
                    case "Wall"://Player should bounce back
                        StartCoroutine(BounceBack(transform));
                        break;
                    case "Enemy"://Player should move normally
                        Debug.Log("Enemy detected, but this isn't implemented yet");
                        StartCoroutine(Sidestep(transform));
                        break;
                    default:
                        Debug.Log("Unknown tag detected");
                        break;
                }
            }
        }
    }

    private void ForwardMovement()
    {
        if (objectHitForward.collider == null && objectHitBackward.collider == null)//move normally if both are null
        {
            StartCoroutine(PlayerMove(transform));
        }
        else if (objectHitForward.collider != null && input.y > 0)//Something in front, moving forward
        {
            switch (objectHitForward.collider.tag)
            {
                case "Wall": //Player should bounce back
                    StartCoroutine(BounceBack(transform));
                    break;
                case "Enemy"://Player should move normally
                    Debug.Log("Enemy detected, but this isn't implemented yet");
                    StartCoroutine(PlayerMove(transform));
                    break;
                default:
                    Debug.Log("Unknown tag detected");
                    break;
            }
        }
        else if (objectHitForward.collider != null && input.y < 0)//Something in front, moving backward
        {
            if (objectHitBackward.collider == null) { StartCoroutine(PlayerMove(transform)); }//If opposite collider is null move normally
            else
            {
                switch (objectHitBackward.collider.tag)
                {
                    case "Wall": //Player should bounce back
                        StartCoroutine(BounceBack(transform));
                        break;
                    case "Enemy"://Player should move normally
                        Debug.Log("Enemy detected, but this isn't implemented yet");
                        StartCoroutine(PlayerMove(transform));
                        break;
                    default:
                        Debug.Log("Unknown tag detected");
                        break;
                }
            }
        }
        else if (objectHitBackward.collider != null && input.y < 0)//Something behind and moving back
        {
            switch (objectHitBackward.collider.tag)
            {
                case "Wall":
                    StartCoroutine(BounceBack(transform));
                    break;
                case "Enemy"://Player should move normally
                    Debug.Log("Enemy detected, but this isn't implemented yet");
                    StartCoroutine(PlayerMove(transform));
                    break;
                default:
                    Debug.Log("Unknown tag detected");
                    break;
            }
        }
        else if (objectHitBackward.collider != null && input.y > 0)
        {
            if (objectHitForward.collider == null) { StartCoroutine(PlayerMove(transform)); }//If opposite collider is null move normally
            else
            {
                switch (objectHitForward.collider.tag)
                {
                    case "Wall"://Player should bounce back
                        StartCoroutine(BounceBack(transform));
                        break;
                    case "Enemy"://Player should move normally
                        Debug.Log("Enemy detected, but this isn't implemented yet");
                        StartCoroutine(PlayerMove(transform));
                        break;
                    default:
                        Debug.Log("Unknown tag detected");
                        break;
                }
            }
        }
    }

    public IEnumerator Rotate(Vector3 byAngles, float inTime)
    {
        isMoving = true;
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        transform.rotation = toAngle;
        isMoving = false;
        yield return 0;
    }

    public IEnumerator PlayerMove(Transform transform)
    {
        isMoving = true;
        startPosition = transform.position;
        t = 0;

        if (gridOrientation == Orientation.Horizontal)
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);
            endPosition = transform.forward * System.Math.Sign(input.y) + startPosition;
        }
        else
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
        }

        if (allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0)
        {
            factor = 0.7071f;
        }
        else
        {
            factor = 1f;
        }
        while (t < 1f)
        {
            t += Time.deltaTime * (moveSpeed / gridSize) * factor;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        isMoving = false;
        yield return 0;
    }

    private IEnumerator BounceBack(Transform transform)
    {
        isMoving = true;
        startPosition = transform.position;
        t = 0;

        endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);
        endPosition = transform.forward * System.Math.Sign(input.y) + startPosition;
        endPosition = (transform.forward * System.Math.Sign(input.y) * .1f) + startPosition;

        while (t < 1f)
        {
            t += Time.deltaTime * (moveSpeed / gridSize) * factor;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            transform.position = Vector3.Lerp(endPosition, startPosition, t);
            yield return null;
        }

        isMoving = false;
        yield return 0;
    }

    public IEnumerator Sidestep(Transform transform)
    {
        isMoving = true;
        startPosition = transform.position;
        t = 0;

        endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);
        endPosition = transform.right * System.Math.Sign(input.x) + startPosition;

        while (t < 1f)
        {
            t += Time.deltaTime * (moveSpeed / gridSize) * factor;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        isMoving = false;
        yield return 0;
    }
}