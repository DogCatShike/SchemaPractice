using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Practice.System_Game
{
    public class GameSystemContext
    {
        public bool isRunning;

        public UICore uiCore;

        public GameSystemContext()
        {

        }

        public void Inject(UICore uiCore)
        {
            this.uiCore = uiCore;
        }
    }
}