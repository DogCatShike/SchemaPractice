using System;
using UnityEngine;

namespace Practice.System_Game
{
    public static partial class RoleDomain
    {
        #region OnCollision
        static void Phx_Body_OnCollisionEnter(GameSystemContext ctx, RoleEntity role, Collision2D other)
        {
            role.EnterGround();
        }

        static void Phx_Body_OnCollisionStay(GameSystemContext ctx, RoleEntity role, Collision2D other)
        {

        }

        static void Phx_Body_OnCollisionExit(GameSystemContext ctx, RoleEntity role, Collision2D other)
        {

        }
        #endregion

        #region OnTrigger
        static void Phx_Body_OnTriggerEnter(GameSystemContext ctx, RoleEntity role, Collider2D other)
        {

        }

        static void Phx_Body_OnTriggerStay(GameSystemContext ctx, RoleEntity role, Collider2D other)
        {

        }

        static void Phx_Body_OnTriggerExit(GameSystemContext ctx, RoleEntity role, Collider2D other)
        {

        }
        #endregion
    }
}