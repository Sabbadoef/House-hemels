using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_V2 : MonoBehaviour
{
    [Header("Layer masks: ")]
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private LayerMask wallLayerMask;

    [Header("Physics: ")]
    public float runningDelay;
    public float runningSpeed;
    public float jumpingSpeed;
    public float minFallingSpeed;
    public float maxFallingSpeed;
    public float coyoteTime;
    public float dashTime;
    public float gravityModifier;
    public float jumpApexThreshold;
    public float apexBonusX;
    public float fallClampX;

    [Header("Powers: ")]
    public int totalJumps;
    public bool kickFromWalls;
    public bool dash;

    [Header("Sounds: ")]
    [SerializeField] AudioSource dashSound;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource landSound;

    private Vector2 initialScale;
    private float horizontalInput;
    private float coyoteCounter;
    private float moveTimer;
    private float xSpeed;
    private float downSpeed;
    private float dashCooldown;
    private float dashTimer;
    private float interpolator;
    private float apexPoint;
    private int jumpCount;
    private bool dashing;

    private int memories;

    private BoxCollider2D boxCollider2D;
    private Rigidbody2D body;
    private Animator anim;

    
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        initialScale = transform.localScale;

        dashCooldown = 0;
        jumpCount = totalJumps;
        moveTimer = runningDelay;

        body.gravityScale = 0;

        dashing = false;

        interpolator = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //Play Landing sound
        if(IsGrounded() && body.velocity.y < 0)
        {
            landSound.Play();
        }
        //Print frame/second
        //Debug.Log("Frames per second: " + (1f / Time.deltaTime));

        //Register left/right input from player
        horizontalInput = Input.GetAxis("Horizontal");

        //Cooldown of Dash
        dashCooldown = (dashCooldown <= 0)? 0 : dashCooldown - Time.deltaTime;

        // Flip character left/right when moving left/right
        if (horizontalInput > 0)
            transform.localScale = new Vector2(initialScale.x, initialScale.y);
        else if (horizontalInput < 0)
            transform.localScale = new Vector2(-initialScale.x, initialScale.y);


        //Movement control Grounded - inAir
        if (IsGrounded() && body.velocity.y <= 0.01f)
        {
            //Reset counters and states
            ResetCounters();

            //Walk
            Walk();
        }
        else
        {
            //Falling + apex
            apexPoint = Mathf.InverseLerp(jumpApexThreshold, -1f, Mathf.Abs(body.velocity.y));
            interpolator = (horizontalInput * Mathf.Sign(transform.localScale.x) < 0)
                ? interpolator = 0
                : interpolator + Time.deltaTime;

            xSpeed = body.velocity.x + horizontalInput * Mathf.Abs(Mathf.Lerp(0f, 1.5f*runningSpeed - Mathf.Abs(body.velocity.x), interpolator));
            xSpeed = xSpeed - Mathf.Sign(xSpeed) * Mathf.Lerp(0f, Mathf.Abs(body.velocity.x), .7f * interpolator);// + horizontalInput * apexBonusX * apexPoint;

            downSpeed = (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
                ?  Mathf.Lerp(minFallingSpeed, maxFallingSpeed, apexPoint) * gravityModifier
                :  Mathf.Lerp(minFallingSpeed, maxFallingSpeed, apexPoint) ;
            downSpeed = (body.velocity.y < -maxFallingSpeed)
                ? -maxFallingSpeed
                : body.velocity.y - downSpeed;

            body.velocity = new Vector2(xSpeed, downSpeed );

            coyoteCounter -= Time.deltaTime;
        }

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsOnWall() != 0 && !IsGrounded() && kickFromWalls)
            {
                interpolator = -15 * Time.deltaTime;
                body.velocity = new Vector2(-IsOnWall() * .6f * runningSpeed, 1.1f * jumpingSpeed );
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                jumpSound.Play();
            }
            else if (jumpCount > 0 && totalJumps > 1)
                Jump();
            else if (jumpCount > 0 && coyoteCounter > 0)
                Jump();
        }


        //Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && dash && dashCooldown <= 0)
        {
            dashing = true;
            dashCooldown += 2;
            dashTimer = dashTime;
        }

        if (dashing && dashTimer > 0)
        {
            dashTimer -= Time.deltaTime;
            dashSound.Play();
            body.velocity = new Vector2(Mathf.Sign(transform.localScale.x) * 3 * runningSpeed , 0);

            if (dashTimer < 0.1)
                coyoteCounter = coyoteTime;
        }

        


        //Set animator control parameters
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("IsGrounded", IsGrounded());
        anim.SetFloat("Velocity_y", body.velocity.y);
    }

    private bool IsGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D rayHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);
        return rayHit.collider != null;
    }

    private int IsOnWall()
    {
        float extraGap = 0.1f;
        int wall = 0;
        RaycastHit2D rayHitL = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.left, extraGap, wallLayerMask);
        RaycastHit2D rayHitR = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.right, extraGap, wallLayerMask);
        if (rayHitL.collider != null)
            wall -= 1;
        else if (rayHitR.collider != null)
            wall += 1;
        return wall;
    }

    private void ResetCounters()
    {
        interpolator = 0;
        dashCooldown = 0;
        coyoteCounter = coyoteTime;
        jumpCount = totalJumps;
    }

    private void Walk()
    {
        moveTimer = (horizontalInput == 0)
            ? runningDelay
            : moveTimer - Time.deltaTime;
        body.velocity = (moveTimer <= 0)
            ? new Vector2(horizontalInput * runningSpeed , 0f)
            : new Vector2(0f, 0f);
    }

    private void Jump()
    {
        interpolator = 0;
        jumpCount--;
        body.velocity = new Vector2(body.velocity.x , jumpingSpeed );
        jumpSound.Play();
    }

    void OnEnable()
    {
        MemorySystem.OnMemoryAdded += UpdateMemories;
    }


    void OnDisable()
    {
        MemorySystem.OnMemoryAdded -= UpdateMemories;
    }

    private void UpdateMemories()
    {
        memories++;
        switch (memories)
        {
            case 4:
                totalJumps = 2;
                break;
            case 3:
                kickFromWalls = true;
                break;
            case 2:
               dash = true;
                break;
            case 1:
                totalJumps = 1;
                break;
            case 0:
                totalJumps = 0;
                kickFromWalls = false;
                dash = false;
                break;
        }

    }




}
