using System;
using UnityEngine;

namespace Practice.System_Game
{
    public class GameSystem : MonoBehaviour
    {
        public SystemType systemType => SystemType.Game;

        GameSystemContext ctx;

        GameSystemEvents events;
        public GameSystemEvents Events => events;

        public void Ctor()
        {
            ctx = new GameSystemContext();
            events = new GameSystemEvents();
        }

        public void Inject(UICore uiCore, AssetsModule assetsModule, InputModule inputModule)
        {
            ctx.Inject(uiCore, assetsModule, inputModule);
        }

        public void Enter()
        {
            ctx.isRunning = true;

            RoleDomain.SpwanOwner(ctx, 1);
        }

        public void Exit()
        {
            ctx.isRunning = false;
        }

        public void Tick(float dt)
        {
            if (!ctx.isRunning)
            {
                return;
            }

            var game = ctx.gameEntity;

            PreTick(dt);

            ref float restFixTime = ref game.restFixTime;

            restFixTime += dt;

            const float FIX_INTERVAL = 0.020f;

            if (restFixTime <= FIX_INTERVAL)
            {
                LogicTick(restFixTime);

                restFixTime = 0;
            }
            else
            {
                while (restFixTime >= FIX_INTERVAL)
                {
                    LogicTick(FIX_INTERVAL);
                    restFixTime -= FIX_INTERVAL;
                }
            }

            LastTick(dt);
        }

        void PreTick(float dt)
        {

        }

        void LogicTick(float dt)
        {
            var game = ctx.gameEntity;

            //  Role
            RoleEntity owner = ctx.roleRepo.GetOwner();
            if (owner == null)
            {
                return;
            }

            // Player的逻辑
            RoleDomain.Input_Record(ctx, owner);
            RoleDomain.Fsm_Apply(ctx, owner, dt);
        }

        void LastTick(float dt)
        {

        }

        public void Game_Binding()
        {
            
        }
    }
}