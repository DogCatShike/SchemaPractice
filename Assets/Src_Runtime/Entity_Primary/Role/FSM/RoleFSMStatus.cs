using System;

namespace Practice
{
    [Flags]
    public enum RoleFSMStatus
    {
        None,
        Normal = 1 << 0,
        Dead = 1 << 1,
    }
}