using System;
using UnityEngine;
using Practice.System_Login;
using Practice.System_Game;

namespace Practice.Main
{
    public class Main : MonoBehaviour
    {
        [SerializeField] Canvas screenCanvas;

        public static LoginSystem loginSystem;
        public static GameSystem gameSystem;

        public static UICore uiCore;

        public static AssetsModule assetsModule;
        public static InputModule inputModule;

        void Start()
        {
            loginSystem = GetComponentInChildren<LoginSystem>();
            loginSystem.Ctor();

            gameSystem = GetComponentInChildren<GameSystem>();
            gameSystem.Ctor();

            uiCore = GetComponentInChildren<UICore>();
            uiCore.Ctor();

            assetsModule = GetComponentInChildren<AssetsModule>();
            assetsModule.Ctor();

            inputModule = GetComponentInChildren<InputModule>();
            inputModule.Ctor();

            // Inject
            loginSystem.Inject(uiCore);
            gameSystem.Inject(uiCore, assetsModule, inputModule);

            uiCore.Inject(screenCanvas, assetsModule);

            // Binding
            BindEvents_System_Login();


            Action action = async () =>
            {

                await assetsModule.LoadAll();

                // Enter
                loginSystem.Enter();
            };

            action.Invoke();

        }

        void Update()
        {
            float dt = Time.deltaTime;

            inputModule.Process();

            gameSystem.Tick(dt);
            loginSystem.Tick(dt);
        }

        void OnApplicationQuit()
        {
            TearDown();
        }

        void OnDestroy()
        {
            TearDown();
        }

        // 这里有点问题
        void TearDown()
        {
            assetsModule.ReleaseAll();
        }

        #region Binding_LoginSystem
        public void BindEvents_System_Login()
        {
            loginSystem.Login_Binding();

            var events = loginSystem.Events;

            events.OnStartHandle += () =>
            {
                Debug.Log("Start Game");
                loginSystem.Exit();
                gameSystem.Enter();
            };
        }
        #endregion

        #region Binding_GameSystem
        public void BindEvents_System_Game()
        {
            gameSystem.Game_Binding();
        }
        #endregion
    }
}