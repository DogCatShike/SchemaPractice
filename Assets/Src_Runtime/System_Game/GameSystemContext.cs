using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Practice.System_Game
{
    public class GameSystemContext
    {
        public bool isRunning;

        public UICore uiCore;
        public AssetsModule assetsModule;
        public InputModule inputModule;

        public GameEntity gameEntity;

        public RoleRepo roleRepo;

        public GameSystemContext()
        {
            gameEntity = new GameEntity();
            roleRepo = new RoleRepo();
        }

        public void Inject(UICore uiCore, AssetsModule assetsModule, InputModule inputModule)
        {
            this.uiCore = uiCore;
            this.assetsModule = assetsModule;
            this.inputModule = inputModule;
        }
    }
}