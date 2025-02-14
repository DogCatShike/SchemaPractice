using System;
using UnityEngine;

namespace Practice
{
    public class RoleMoveComponent
    {
        Rigidbody2D rb;
        
        public Vector2 velocity => rb.velocity; // 给外部调用

        bool isGround;
        public bool IsGround => isGround;

        public int jumpTimes;

        public RoleMoveComponent()
        {

        }

        public void Inject(Rigidbody2D rb)
        {
            this.rb = rb;
        }

        public void Move(float xAxis, float moveSpeed)
        {
            var velo = rb.velocity;
            velo.x = xAxis * moveSpeed;
            rb.velocity = velo;
        }

        public void Jump(float jumpForce)
        {
            if (jumpTimes > 0)
            {
                var velo = rb.velocity;
                velo.y = jumpForce;
                rb.velocity = velo;
                jumpTimes -= 1;
            }
        }

        public void Ground_Enter(int jumpTimes)
        {
            isGround = true;
            this.jumpTimes = jumpTimes;
        }

        public void Ground_Exit()
        {
            isGround = false;
        }
    }
}