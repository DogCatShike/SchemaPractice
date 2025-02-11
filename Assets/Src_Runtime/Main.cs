using System;
using UnityEngine;
using Practice.System_Login;

namespace Practice.Main
{
    public class Main : MonoBehaviour
    {
        [SerializeField] Canvas screenCanvas;

        public static LoginSystem loginSystem;

        public static UICore uiCore;

        public static AssetsModule assetsModule;

        void Start()
        {
            loginSystem = GetComponentInChildren<LoginSystem>();
            loginSystem.Ctor();

            uiCore = GetComponentInChildren<UICore>();
            uiCore.Ctor();

            assetsModule = GetComponentInChildren<AssetsModule>();
            assetsModule.Ctor();

            // Inject
            loginSystem.Inject(uiCore);

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

        public void BindEvents_System_Login()
        {
            loginSystem.Login_Binding();
            
            var events = loginSystem.Events;

            events.OnStartHandle += () => {
                Debug.Log("Start Game");
            };
        }
    }
}