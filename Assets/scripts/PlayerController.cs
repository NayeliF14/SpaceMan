using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables del movimiento de personaje
    public float jumpForce = 13f;
    public float runningSpeed = 2f;
    private Rigidbody2D rigidBody;
    Animator animator;

    private const string STATE_ALIVE = "isAlive";
    private const string STATE_ON_THE_GROUND = "isOnTheGround";

    public LayerMask groundMask;

    private void Awake()
    {
        rigidBody = GetComponent <Rigidbody2D>();
        animator = GetComponent <Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, false);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Jump();
       }

        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());

        Debug.DrawRay(this.transform.position, Vector2.down * 1.45f, Color.red);
    }

    void FixedUpdate() 
    {
        if(rigidBody.velocity.x < runningSpeed){
            rigidBody.velocity = new Vector2(runningSpeed, //x
                                            rigidBody.velocity.y //y
                                            );
        }
    }

    void Jump()
    {
        if(IsTouchingTheGround())
        {

        rigidBody.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
    }
    //nos indica si el personaje esta o no tocando el suelo
    bool IsTouchingTheGround(){
        if(Physics2D.Raycast(this.transform.position,
                             Vector2.down,
                             1.45f, groundMask)){
                            //TODO: programar logica de contacto con el suelo
                           
                            return true;
                        }else {
                            //TODO: programar logica de no contacto
                            
                            return false;
                        }
    }

}
