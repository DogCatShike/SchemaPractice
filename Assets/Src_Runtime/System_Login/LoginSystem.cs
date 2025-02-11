using System;
using UnityEngine;

namespace Practice.System_Login
{
    public class LoginSystem : MonoBehaviour
    {
        public SystemType systemType => SystemType.Login;

        LoginSystemContext ctx;

        LoginSystemEvents events;
        public LoginSystemEvents Events => events;

        public void Ctor()
        {
            ctx = new LoginSystemContext();
            events = new LoginSystemEvents();
        }

        public void Inject(UICore uiCore)
        {
            ctx.Inject(uiCore);
        }

        public void Enter()
        {
            ctx.isRunning = true;

            var ui = ctx.uiCore;
            ui.Panel_LoginGame_Show();
        }

        public void Exit()
        {
            ctx.isRunning = false;

            var ui = ctx.uiCore;
            ui.Panel_LoginGame_Close();
        }

        public void Tick(float dt)
        {
            // LoginSystem感觉不用计算刷新率还是什么的
            if (!ctx.isRunning) { return; }
        }

        public void Login_Binding()
        {
            var uiCore = ctx.uiCore;
            var eventCenter = uiCore.events;

            eventCenter.OnStartHandle += () => {
                events.OnStart();
            };
        }
    }
}