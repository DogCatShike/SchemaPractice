using System;
using UnityEngine;

namespace Practice
{
    [Serializable]
    public class RoleInputComponent
    {
        Vector2 moveAxis;
        public Vector2 MoveAxis => moveAxis;
        public void Set_MoveAxis(Vector2 value) => moveAxis = value;
        public float Get_XAxis() => moveAxis.x;

        bool isJump;
        public bool IsJump => isJump;
        public void Set_Jump(bool value) => isJump = value;
        public bool Get_Jump() => isJump;

        InputKeyFlag key;
        public InputKeyFlag Key => key;

        public RoleInputComponent()
        {

        }

        public void RecoredCastKey(InputKeyFlag key)
        {
            if (key == InputKeyFlag.None) { return; }

            this.key = key;
        }
    }
}