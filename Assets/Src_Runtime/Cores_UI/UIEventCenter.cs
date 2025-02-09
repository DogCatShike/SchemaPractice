using System;
using UnityEngine;

namespace Practice.Cores_UI
{
    public class UIEventCenter
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