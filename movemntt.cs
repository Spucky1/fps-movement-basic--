using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movemntt : MonoBehaviour
{
    [Header("Movment")]
  public float movespeed = 6f;
  public float movespeedX = 10f;
  float rbdrag = 6f;
  float playerheight = 2f;
  [Header("Keybinds")]
  [SerializeField] KeyCode jumpkey = KeyCode.Space;
  [Header("Jump")]
  public float jumpforce = 5f;
   [Header("Ground Detection")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float groundDistance = 0.2f;
    public bool isGrounded { get; private set; }
   
  [SerializeField] float airdrag = 0.4f;

  float horizontalMovement;
  float VerticalMovement;
 

  Vector3 moveDirection;
  Rigidbody rb;
   private void Start() 
   {
     rb = GetComponent<Rigidbody>();
     rb.freezeRotation = true;
     
    

  }
  private void Update() {
     MyInput();
      isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
     if (Input.GetKeyDown(jumpkey) && isGrounded)
     {
        jump();
     }
  }
  void Controldrag(){
    
    if(isGrounded)
    {
     rb.drag = rbdrag;
    }
    else
    {
      rbdrag = airdrag;
    }
  }
  void MyInput()
  {
    horizontalMovement = Input.GetAxisRaw("Horizontal");
    VerticalMovement = Input.GetAxisRaw("Vertical");

    moveDirection = transform.forward * VerticalMovement + transform.right * horizontalMovement;
  }
  private void FixedUpdate() {
     
     rb.AddForce(moveDirection.normalized * movespeed * movespeedX, ForceMode.Acceleration);
    
  }
  void jump()
  { 
    rb.AddForce(transform.up * jumpforce, ForceMode.Impulse);
  }
  
   
}
