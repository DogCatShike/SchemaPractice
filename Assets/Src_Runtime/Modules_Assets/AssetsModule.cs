using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Practice
{
    public class AssetsModule : MonoBehaviour
    {
        // Assets
        public Dictionary<string, GameObject> entityDict;
        AsyncOperationHandle entityHandle;

        public Dictionary<string, GameObject> uiDict;
        AsyncOperationHandle uiHandle;

        public void Ctor()
        {
            entityDict = new Dictionary<string, GameObject>();
            uiDict = new Dictionary<string, GameObject>();
        }

        public async Task LoadAll()
        {
            #region Assets
            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = AssetLabelConst.ENTITY;
                var handle = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);
                var list = await handle.Task;

                foreach (var item in list)
                {
                    // 在这里加个检测是否 Add 成功
                    entityDict.Add(item.name, item);
                }
                entityHandle = handle;
            }
            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = AssetLabelConst.PANEL;
                var handle = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);
                var list = await handle.Task;
                
                foreach (var item in list)
                {
                    uiDict.Add(item.name, item);
                }
                uiHandle = handle;
            }
            #endregion

            #region TM
            {

            }
            #endregion
        }

        // 这名字比 UnLoadAll 顺眼
        public void ReleaseAll()
        {
            if (entityHandle.IsValid())
            {
                Addressables.Release(entityHandle);
            }

            if (uiHandle.IsValid())
            {
                Addressables.Release(uiHandle);
            }
        }

        #region Entity
        // 返回值 bool 或 GameObject, 暂时不考虑debug, 先用GameObject
        public GameObject Entity_GetRole()
        {
            entityDict.TryGetValue("Entity_Role", out GameObject prefab);
            return prefab;
        }
        #endregion

        #region UI
        // 这个感觉好, 用用看
        public bool UI_TryGet(string key, out GameObject panel)
        {
            return uiDict.TryGetValue(key, out panel);
        }
        #endregion
    }
}