using System;
using UnityEngine;

namespace Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController controller;
        public float movementSpeed = 4f;
        public float rotateSpeed = 6f;

        private void FixedUpdate()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            
            //movimento
            if(vertical != 0)
                controller.Move(transform.forward * (movementSpeed * Time.deltaTime * vertical));

            //rotacao
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                transform.Rotate(Vector3.up * (horizontal * rotateSpeed));

            //gravidade
            controller.Move(new Vector3(0, -9.81f, 0) * Time.deltaTime);
        }
    }
}