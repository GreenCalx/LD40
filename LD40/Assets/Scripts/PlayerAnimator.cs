using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : StateMachineBehaviour {

    private GameObject __player;

    
    public bool isWalking   = false;
    public bool isRunning   = false;
    public bool isJumping   = false;
    public bool isInAir     = false;
    public bool playerFacingRight = true;
    public bool isMoving = false;
    public bool hasYMotion = false;
    public bool hasXMotion = false;
    public bool doubleJump = false;

    private readonly int paramIsWalking     = Animator.StringToHash("isWalking");
    private readonly int paramIsRunning     = Animator.StringToHash("isRunning");
    private readonly int paramIsJumping     = Animator.StringToHash("isJumping");
    private readonly int paramIsInAir       = Animator.StringToHash("isInAir");
    private readonly int paramDoubleJump    = Animator.StringToHash("DoubleJump");

    private bool __spriteIsFacingRight = true;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        __player = GameObject.Find("player");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        // Update from player
        if (__player != null)
        {
            JumpBehaviour jumpBehaviour = __player.GetComponent<JumpBehaviour>();
            PlayerBehaviour playerBehaviour = __player.GetComponent<PlayerBehaviour>();
          
            Rigidbody2D rb2D = __player.GetComponent<Rigidbody2D>();
            SpriteRenderer sr = __player.GetComponent<SpriteRenderer>();
            Vector2 input = jumpBehaviour.getInput();
            if ( jumpBehaviour && playerBehaviour && rb2D )
            {
                hasYMotion = rb2D.velocity.y != 0f;
                //hasXMotion = rb2D.velocity.x != 0f;
                hasXMotion = input.x != 0;
                isMoving = hasXMotion || hasYMotion;

                // check walking
                isWalking = (jumpBehaviour.IsGrounded()) && hasXMotion && !hasYMotion;

                // check running
                isRunning = (jumpBehaviour.IsGrounded()) && hasXMotion && !hasYMotion && (playerBehaviour.PlayerSpeed >= playerBehaviour.PlayerMaxSpeed);

                isJumping = Input.GetKey(KeyCode.UpArrow);

                // check in air
                isInAir = (!jumpBehaviour.IsGrounded()) && !(jumpBehaviour.AskedForJump) && hasYMotion;

                // Update animator
                animator.SetBool(paramIsJumping, isJumping);
                animator.SetBool( paramIsWalking, isWalking);
                animator.SetBool( paramIsRunning, isRunning);

                animator.SetBool( paramIsInAir, isInAir);
                animator.SetBool( paramDoubleJump,       jumpBehaviour.CanDoubleJump);

                // Flip if needed
                if (__spriteIsFacingRight && jumpBehaviour.getInput().x < 0)
                {
                    flip(sr);
                }
                else if ((!__spriteIsFacingRight) && jumpBehaviour.getInput().x > 0)
                {
                    flip(sr);
                }
            }
        }


    }


    private void flip( SpriteRenderer iSR )
    {
        iSR.flipX = !iSR.flipX;
        __spriteIsFacingRight = !__spriteIsFacingRight;
    }

    private void rotate( SpriteRenderer iSR )
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    
    }

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    
    }
}
