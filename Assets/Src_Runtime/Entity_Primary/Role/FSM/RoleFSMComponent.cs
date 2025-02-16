using System;
using UnityEngine;

namespace Practice
{
    public class RoleFSMComponent
    {
        RoleFSMStatus status;
        public RoleFSMStatus Status => status;

        public RoleFSMComponent()
        {

        }

        public void Normal_Enter()
        {
            status = RoleFSMStatus.Normal;
        }


        public void Dead_Enter()
        {
            status = RoleFSMStatus.Dead;
        }
    }
}