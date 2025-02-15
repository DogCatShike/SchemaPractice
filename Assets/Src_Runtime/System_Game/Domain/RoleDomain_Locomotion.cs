using System;
using UnityEngine;

namespace Practice.System_Game
{
    public static partial class RoleDomain
    {
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