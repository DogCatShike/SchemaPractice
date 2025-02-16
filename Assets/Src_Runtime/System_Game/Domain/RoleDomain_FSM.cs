using System;
using UnityEngine;

namespace Practice.System_Game
{
    public static partial class RoleDomain
    {
        public static void Fsm_Apply(GameSystemContext ctx, RoleEntity role, float dt)
        {
            var fsm = role.FSMCom;
            var status = fsm.Status;

            if (status == RoleFSMStatus.Normal)
            {
                // Debug.Log("Role is in Normal state.");
                FSM_Any_Execute(ctx, role, dt);
            }
            else if (status == RoleFSMStatus.Dead)
            {

            }
        }

        public static void FSM_Any_Execute(GameSystemContext ctx, RoleEntity role, float dt)
        {
            Loco_Any_Execute(role, dt);
        }

        static void FSM_Normal_Enter(RoleEntity role)
        {
            var fsm = role.FSMCom;
            fsm.Normal_Enter();
        }
    }
}