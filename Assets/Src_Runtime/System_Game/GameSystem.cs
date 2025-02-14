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

        public void Inject(UICore uiCore)
        {
            ctx.Inject(uiCore);
        }

        public void Enter()
        {
            ctx.isRunning = true;
        }

        public void Exit()
        {
            ctx.isRunning = false;
        }

        
    }
}