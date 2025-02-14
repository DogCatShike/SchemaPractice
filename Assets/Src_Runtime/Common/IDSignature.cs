// TODO: 整个IDSig都要理解

using System;
using System.Runtime.InteropServices;

namespace Practice
{

    [Serializable]
    [StructLayout(LayoutKind.Explicit)] // 叠加
    public struct IDSignature
    {

        [FieldOffset(0)]
        [UnityEngine.HideInInspector]
        public ulong value; // 0~8

        [FieldOffset(0)]
        public EntityType entityType; // 0~4

        [FieldOffset(4)]
        public int typeID; // 4~8

        public IDSignature(EntityType entityType, int typeID)
        {
            this.value = 0;
            this.entityType = entityType;
            this.typeID = typeID;
        }

        public IDSignature(ulong value)
        {
            this.entityType = EntityType.None;
            this.typeID = 0;
            this.value = value;
        }

        public static bool operator ==(IDSignature a, IDSignature b)
        {
            return a.value == b.value;
        }

        public static bool operator !=(IDSignature a, IDSignature b)
        {
            return a.value != b.value;
        }

        public override bool Equals(object obj)
        {
            if (obj is IDSignature)
            {
                return this == (IDSignature)obj;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}