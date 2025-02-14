using System;
using UnityEngine;

namespace Practice.Template
{
    [CreateAssetMenu(fileName = "RoleSO", menuName = "Practice/RoleSO")]
    public class RoleSO : ScriptableObject
    {
        public RoleTM tm;
    }
}