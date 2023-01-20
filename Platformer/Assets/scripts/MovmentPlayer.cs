using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float ForceJump = 1;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;
    private float _Horizontal;
    private bool IsFacingRight = true;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _Horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, ForceJump);
        }
    }
    void FixedUpdate()
    {
        _rb.velocity = new Vector2(_Horizontal * speed * Time.deltaTime, _rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position,0.2f,GroundLayer);
    }
    void Flip()
    {
        if(IsFacingRight && _Horizontal < 0f || !IsFacingRight && _Horizontal>0f)
        {
            IsFacingRight = !IsFacingRight;
            Vector3 flip = transform.localScale;
            flip.x *= -1f;
            transform.localScale = flip;
        }
    }
}
