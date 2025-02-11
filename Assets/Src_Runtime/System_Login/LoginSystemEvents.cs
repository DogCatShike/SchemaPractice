using System;
using UnityEngine;

namespace Practice.System_Login
{
    public class LoginSystemEvents
    {
        public Action OnStartHandle;
        public void OnStart()
        {
            if (OnStartHandle != null)
            {
                OnStartHandle();
            }
        }
    }
}