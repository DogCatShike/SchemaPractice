using System;
using UnityEngine;

namespace Practice.Cores_UI.Domain
{
    // Domain写的很乱, 目前只是为Factory而存在的
    public static class UILoginDomain
    {
        public static void Open(UIContext ctx)
        {
            var panel = ctx.panel_LoginGame;
            if (panel == null)
            {
                panel = UIFactory.CreatePanel<Panel_LoginGame>(ctx, ctx.screenCanvas.transform);
                panel.Ctor();

                panel.OnStartClickHandle = () =>
                {
                    ctx.events.OnStart();
                };
            }
            ctx.panel_LoginGame = panel;
            panel.Show();
        }

        public static void Close(UIContext ctx)
        {
            var panel = ctx.panel_LoginGame;

            if (panel == null) { return; }

            panel.TearDown();
            ctx.panel_LoginGame = null;
        }
    }
}