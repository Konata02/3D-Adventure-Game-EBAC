using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
      public CharacterController characterController;    
      public float speed = 1f;    
      public float turnSpeed = 1f;    
      public float gravity = 9.8f;    
      private float vSpeed = 0f;    
      public Animator animator; 
      public float jumpSpeed = 15f;
      public int damage = 10;
      public HealthBase healthBase; 

      void Update()    
        {        
            
            transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);        
            var inputAxisVertical = Input.GetAxis("Vertical");        
            var speedVector = transform.forward * inputAxisVertical * speed;        
            
                if(characterController.isGrounded){
                  vSpeed = 0;
                  if(Input.GetKeyDown(KeyCode.Space)) vSpeed = jumpSpeed;            
                    
                }
            
               
            vSpeed -= gravity * Time.deltaTime;
            speedVector.y = vSpeed;        
            
            characterController.Move(speedVector * Time.deltaTime);
            
            if(inputAxisVertical !=0) animator.SetBool("Run", true);
            else animator.SetBool("Run", false);




        }


      

}
