using System;
using UnityEngine;

namespace Practice.System_Login
{
    public class LoginSystemContext
    {
        public bool isRunning;

        public UICore uiCore;

        public LoginSystemContext()
        {

        }

        public void Inject(UICore uiCore)
        {
            this.uiCore = uiCore;
        }
    }
}