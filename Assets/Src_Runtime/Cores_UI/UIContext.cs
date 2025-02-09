using System;
using UnityEngine;

namespace Practice.Cores_UI
{
    public class UIContext
    {
        public Canvas screenCanvas;
        public UIEventCenter events;
        public AssetsModule assetsModule;

        // Panels
        public Panel_LoginGame panel_LoginGame;

        public UIContext()
        {
            events = new UIEventCenter();
        }

        // 现在比较少, 注入东西多了写一个 UIContextInjectionArgs
        public void Inject(Canvas screenCanvas, AssetsModule assetsModule)
        {
            this.screenCanvas = screenCanvas;
            this.assetsModule = assetsModule;
        }

        // TODO: 加字典, 通过字典获取panel
    }
}