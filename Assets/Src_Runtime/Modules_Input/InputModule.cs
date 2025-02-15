using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Practice
{
    public class InputModule : MonoBehaviour
    {
        InputControls input;
        public InputControls Input => input;

        InputKeyFlag key;
        public InputKeyFlag Key => key;

        Vector2 moveAxis;
        public Vector2 MoveAxis => moveAxis;

        bool isJump;
        public bool IsJump => isJump;
        public void ResetJump() => isJump = false;

        public void Ctor()
        {
            input = new InputControls();
            input.Enable();
        }

        public void Process()
        {
            var player = input.Player;

            // Move
            {
                moveAxis.x = player.Left.ReadValue<float>() + player.Right.ReadValue<float>();

                if (player.Left.WasPerformedThisFrame()) // 检测被执行
                {
                    key |= InputKeyFlag.Left;
                }
                else if (player.Right.WasPerformedThisFrame())
                {
                    key |= InputKeyFlag.Right;
                }
            }

            // Jump
            {
                bool isJumpDown = player.Jump.WasPressedThisFrame(); // 检测被按下
                isJump = isJumpDown;
                if (isJumpDown)
                {
                    key |= InputKeyFlag.Jump;
                }
            }
        }
    }
}