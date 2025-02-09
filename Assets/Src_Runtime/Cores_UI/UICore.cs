using System;
using UnityEngine;
using Practice.Cores_UI;
using Practice.Cores_UI.Domain;

namespace Practice
{
    public class UICore : MonoBehaviour
    {
        public UIContext ctx;
        public UIEventCenter events;

        public void Ctor()
        {
            ctx = new UIContext();
            events = new UIEventCenter();
        }

        public void Inject(Canvas screenCanvas, AssetsModule assetsModule)
        {
            ctx.Inject(screenCanvas, assetsModule);
        }

        public void Panel_LoginGame_Show()
        {
            UILoginDomain.Open(ctx);
        }

        public void Panel_LoginGame_Close()
        {
            UILoginDomain.Close(ctx);
        }
    }
}