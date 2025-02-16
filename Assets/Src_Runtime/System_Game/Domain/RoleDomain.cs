using System;
using UnityEngine;

namespace Practice.System_Game
{
    public static partial class RoleDomain
    {
        public static RoleEntity Spwan(GameSystemContext ctx, int typeID)
        {
            var role = GameSystemFactory.Role_Create(ctx.assetsModule, typeID);

            // Events
            role.OnBodyCollisionEnterHandle += (RoleEntity role, Collision2D other) =>
            {
                Phx_Body_OnCollisionEnter(ctx, role, other);
            };
            role.OnBodyCollisionStayHandle += (RoleEntity role, Collision2D other) =>
            {
                Phx_Body_OnCollisionStay(ctx, role, other);
            };
            role.OnBodyCollisionExitHandle += (RoleEntity role, Collision2D other) =>
            {
                Phx_Body_OnCollisionExit(ctx, role, other);
            };

            role.OnBodyTriggerEnterHandle += (RoleEntity role, Collider2D other) =>
            {
                Phx_Body_OnTriggerEnter(ctx, role, other);
            };

            role.OnBodyTriggerStayHandle += (RoleEntity role, Collider2D other) =>
            {
                Phx_Body_OnTriggerStay(ctx, role, other);
            };

            role.OnBodyTriggerExitHandle += (RoleEntity role, Collider2D other) =>
            {
                Phx_Body_OnTriggerExit(ctx, role, other);
            };

            ctx.roleRepo.Add(role);

            FSM_Normal_Enter(role);
            
            return role;
        }

        public static RoleEntity SpwanOwner(GameSystemContext ctx, int typeID)
        {
            var owner = Spwan(ctx, typeID);
            ctx.roleRepo.SetOwner(owner);
            return owner;
        }

        public static void UnSpwan(GameSystemContext ctx, RoleEntity role)
        {
            ctx.roleRepo.Remove(role);
            role.TearDown();
        }

        #region Input
        public static void Input_Record(GameSystemContext ctx, RoleEntity role)
        {
            var inputCom = role.InputCom;
            var input = ctx.inputModule;

            inputCom.Set_Jump(input.IsJump);
            inputCom.Set_MoveAxis(input.MoveAxis);
            inputCom.RecoredCastKey(input.Key);
        }
        #endregion
    }
}