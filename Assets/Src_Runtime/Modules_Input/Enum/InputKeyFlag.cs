using System;

namespace Practice
{
    [Flags] // 枚举可组合
    public enum InputKeyFlag
    {
        None = 0,
        Left = 1 << 0,
        Right = 1 << 1,
        Jump = 1 << 2,
    }
}