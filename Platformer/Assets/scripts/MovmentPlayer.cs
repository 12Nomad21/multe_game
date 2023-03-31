using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentPlayer : MonoBehaviour
{
    [SerializeField] private float RunningSpeed = 250f;
    [SerializeField] private float ForceJump = 10;
    [SerializeField] private float ForceFall = 0.1f;
    [SerializeField] private float CameraChangingSpeed = 4f;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private Transform RightWallCheck;
    [SerializeField] private Transform LeftWallCheck;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Transform PointOfAttackSystem;

    private float _Horizontal;
    static public bool IsFacingRight = true;
    private bool CanJumpFromWall = false;

    private bool IsDashing = false;
    private bool CanDash = true;
    [SerializeField] private float ForceDash=5f;
    [SerializeField] private float DashingTime = 1f;
    [SerializeField] private float DashingCooldown = 2f;
    void Update()
    {
        if (IsDashing)
        {
            return;
        }
        _Horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        if ((IsGrounded() || CanJumpFromWall) && Input.GetButtonDown("Jump"))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, ForceJump);
        }
        if ((!IsGrounded() || CanJumpFromWall) && Input.GetKey(KeyCode.S))
        {
            _rb.velocity += new Vector2(0, -ForceFall);
        }
        if (Input.GetKey(KeyCode.LeftShift) && CanDash && Mathf.Abs(_rb.velocity.x) >0f)
        {
            StartCoroutine(Dash());          
        }
        if (IsTouchingRightWall() && Input.GetKey(KeyCode.D) || IsTouchingLeftWall() && Input.GetKey(KeyCode.A))
        {
            CanJumpFromWall = true;
            if (!Input.GetKey(KeyCode.Space))
            {
                _rb.velocity = new Vector2(_rb.velocity.x, 0);
            }
        }
        else
        {
            CanJumpFromWall = false;
        }
    }
    void FixedUpdate()
    {
        if (IsDashing || CanJumpFromWall == true)
        {
            return;
        }
        _rb.velocity = new Vector2(_Horizontal * RunningSpeed * Time.deltaTime, _rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position,0.2f,GroundLayer);
    }
    private bool IsTouchingRightWall()
    {
        return Physics2D.OverlapCircle(RightWallCheck.position, 0.2f, GroundLayer);
    }
    private bool IsTouchingLeftWall()
    {
        return Physics2D.OverlapCircle(LeftWallCheck.position, 0.2f, GroundLayer);
    }
    void Flip()
    {
        if(!IsFacingRight && Mathf.Abs(UseWeapon.PlayerWeaponRotation)<90 ||
            IsFacingRight && Mathf.Abs(UseWeapon.PlayerWeaponRotation) > 90)
        {
            IsFacingRight = !IsFacingRight;
            sr.flipX = !sr.flipX;
            PointOfAttackSystem.localPosition = new Vector2(PointOfAttackSystem.localPosition.x*-1,-0.19f);
        }
    }
    private IEnumerator Dash()
    {
        CanDash = false;
        IsDashing = true;
        float CurrentGravity = _rb.gravityScale;
        _rb.gravityScale = 0f;
        CameraController.CameraSpeed += CameraChangingSpeed; 
        _rb.velocity = new Vector2(_rb.velocity.x * ForceDash, 0f);
        yield return new WaitForSeconds(DashingTime);
        _rb.gravityScale = CurrentGravity;
        CameraController.CameraSpeed -= CameraChangingSpeed;
        IsDashing = false;
        yield return new WaitForSeconds(DashingCooldown);
        CanDash = true;
    }   
}
