using System;
using UnityEngine;

namespace Practice.Cores_UI
{
    internal static class UIFactory
    {
        public static T CreatePanel<T>(UIContext ctx, Transform parent) where T : MonoBehaviour
        {
            var type = typeof(T);
            var panelName = type.Name;

            // 创建
            bool has = ctx.assetsModule.UI_TryGet(panelName, out GameObject prefab);
            if (!has)
            {
                Debug.Log("Panel not found: " + panelName);
                return null;
            }

            GameObject go = GameObject.Instantiate(prefab, parent);

            var panel = go.GetComponent<T>();
            return panel as T;
        }
    }
}