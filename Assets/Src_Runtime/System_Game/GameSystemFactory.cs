using System;
using UnityEngine;
using Practice.Template;

namespace Practice.System_Game
{
    public static class GameSystemFactory
    {
        #region Role: New
        public static RoleEntity Role_New(AssetsModule assetsModule)
        {
            GameObject prefab = assetsModule.Entity_GetRole();
            var go = GameObject.Instantiate(prefab);
            var role = go.GetComponent<RoleEntity>();
            role.Ctor();
            return role;
        }
        #endregion

        #region Role: Create
        public static RoleEntity Role_Create(AssetsModule assetsModule, int typeID)
        {
            GameObject prefab = assetsModule.Entity_GetRole();
            var go = GameObject.Instantiate(prefab);
            var role = go.GetComponent<RoleEntity>();
            role.Reuse();

            bool has = assetsModule.Role_TryGet(typeID, out RoleTM tm);
            if (!has)
            {
                Debug.LogError($"Role type {typeID} not found");
                return null;
            }

            role.idSig = new IDSignature(EntityType.Role, typeID);
            role.roleType = tm.roleType;

            // Attr
            var attrCom = role.AttrCom;
            attrCom.SetMoveSpeed(tm.moveSpeed);
            attrCom.SetJumpForce(tm.jumpForce);
            attrCom.SetJumpTimes(tm.jumpTimes);
            
            role.Ctor();

            return role;
        }
        #endregion
    }
}