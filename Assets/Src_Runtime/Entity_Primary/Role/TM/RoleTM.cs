using System;
using UnityEngine;

namespace Practice.Template
{
    [Serializable]
    public class RoleTM
    {
        public int typeID;
        public string typeName;
        public RoleType roleType;

        // Attribute
        public float moveSpeed;
        public float jumpForce;
        public int jumpTimes;
    }
}