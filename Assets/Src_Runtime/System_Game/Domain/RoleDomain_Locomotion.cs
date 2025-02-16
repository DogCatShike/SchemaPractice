using System;
using UnityEngine;

namespace Practice.System_Game
{
    public static partial class RoleDomain
    {
        public static void Loco_Any_Execute(RoleEntity role, float dt)
        {
            var attr = role.AttrCom;
            var input = role.InputCom;

            float xAxis = input.Get_XAxis();
            float moveSpeed = attr.moveSpeed;
            Loco_Move(role, xAxis, moveSpeed, dt);

            bool isJump = input.Get_Jump();
            float jumpForce = attr.jumpForce;
            Loco_Jump(role, isJump, jumpForce);
        }

        public static void Loco_Move(RoleEntity role, float xAxis, float moveSpeed, float dt)
        {
            if (dt <= 0) { return; }

            role.Move(xAxis, moveSpeed);
        }

        public static void Loco_Jump(RoleEntity role, bool isJumpDown, float jumpForce)
        {
            role.Jump(isJumpDown, jumpForce);
        }
    }
}