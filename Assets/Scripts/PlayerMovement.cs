using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rigidbodyPlayer;
    public BoxCollider2D boxColliderPlayer;
    public Animator animator;

    public static PlayerMovement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is already a PlayerMovement instance.");
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.fixedDeltaTime;

        MovePlayer(horizontalMovement, verticalMovement);
    }

    public void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity = new(_horizontalMovement, _verticalMovement);
        float neededMagnitude = 8 / moveSpeed;

        if (Math.Abs(targetVelocity.magnitude) > neededMagnitude)
        {
            float oldMagnitude = Math.Abs(targetVelocity.magnitude);
            targetVelocity.x = targetVelocity.x / oldMagnitude * neededMagnitude;
            targetVelocity.y = targetVelocity.y / oldMagnitude * neededMagnitude;
        }
        rigidbodyPlayer.velocity = targetVelocity;

        animator.SetFloat("velocityX", rigidbodyPlayer.velocity.x);
        animator.SetFloat("velocityY", rigidbodyPlayer.velocity.y);
    }
}
