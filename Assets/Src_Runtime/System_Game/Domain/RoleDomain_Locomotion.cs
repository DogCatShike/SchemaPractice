using System;
using UnityEngine;

namespace Practice.System_Game
{
    public static partial class RoleDomain_Locomotion
    {
        public static void Loco_Move(GameSystemContext ctx, RoleEntity role, float xAxis, float moveSpeed, float dt)
        {
            if (dt <= 0) { return; }

            role.Move(xAxis, moveSpeed);
        }
    }
}