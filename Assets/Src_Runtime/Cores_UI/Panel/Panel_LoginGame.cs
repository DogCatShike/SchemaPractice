using System;
using UnityEngine;
using UnityEngine.UI;

namespace Practice.Cores_UI
{
    public class Panel_LoginGame : MonoBehaviour
    {
        [SerializeField] Button btn_Start;
        public Action OnStartClickHandle;

        public void Ctor()
        {
            btn_Start.onClick.AddListener(() => {
                if (OnStartClickHandle != null)
                {
                    OnStartClickHandle.Invoke();
                }
            });
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void TearDown()
        {
            Destroy(gameObject);
        }
    }
}