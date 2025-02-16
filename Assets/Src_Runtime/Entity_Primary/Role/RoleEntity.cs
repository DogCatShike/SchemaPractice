using System;
using UnityEngine;

namespace Practice
{
    public class RoleEntity : MonoBehaviour
    {
        public IDSignature idSig;
        public int typeID => idSig.typeID;

        public RoleType roleType;
        public bool isOwner => roleType == RoleType.Player;

        [SerializeField] Rigidbody2D rb;

        // User Input
        RoleInputComponent inputCom;
        public RoleInputComponent InputCom => inputCom;

        // AttrCom
        RoleAttributeComponent attrCom;
        public RoleAttributeComponent AttrCom => attrCom;

        // MoveCom
        RoleMoveComponent moveCom;
        public RoleMoveComponent MoveCom => moveCom;

        // FSMCom
        RoleFSMComponent fsmCom;
        public RoleFSMComponent FSMCom => fsmCom;

        // Event
        public event Action<RoleEntity, Collision2D> OnBodyCollisionEnterHandle;
        public event Action<RoleEntity, Collision2D> OnBodyCollisionStayHandle;
        public event Action<RoleEntity, Collision2D> OnBodyCollisionExitHandle;

        public event Action<RoleEntity, Collider2D> OnBodyTriggerEnterHandle;
        public event Action<RoleEntity, Collider2D> OnBodyTriggerStayHandle;
        public event Action<RoleEntity, Collider2D> OnBodyTriggerExitHandle;

        public void Ctor()
        {
            inputCom = new RoleInputComponent();
            attrCom = new RoleAttributeComponent();
            moveCom = new RoleMoveComponent();
            fsmCom = new RoleFSMComponent();

            moveCom.Inject(rb);
        }

        public void Reuse()
        {
            gameObject.SetActive(true);
        }

        public void Release()
        {
            OnBodyCollisionEnterHandle = null;
            OnBodyCollisionStayHandle = null;
            OnBodyCollisionExitHandle = null;

            OnBodyTriggerEnterHandle = null;
            OnBodyTriggerStayHandle = null;
            OnBodyTriggerExitHandle = null;

            gameObject.SetActive(false);
        }

        public void TearDown()
        {
            Destroy(gameObject);
        }

        #region Locomotion
        public void Move(float xAxis, float moveSpeed)
        {
            moveCom.Move(xAxis, moveSpeed);
            RotateFace(xAxis);
        }

        public void Jump(bool isJumpDown, float jumpForce)
        {
            moveCom.Jump(isJumpDown, jumpForce);
            ExitGround();
        }

        void RotateFace(float xAxis)
        {
            Vector2 scale = transform.localScale;

            if (xAxis > 0)
            {
                scale.x = 1;
            }
            else if (xAxis < 0)
            {
                scale.x = -1;
            }
            transform.localScale = scale;
        }

        public bool IsGround()
        {
            return moveCom.IsGround;
        }

        public void EnterGround(int jumpTimes)
        {
            moveCom.Ground_Enter(jumpTimes);
        }

        public void ExitGround()
        {
            moveCom.Ground_Exit();
        }
        #endregion

        #region Event
        void OnCollisionEnter2D(Collision2D other)
        {
            if (!gameObject.activeSelf) { return; }

            OnBodyCollisionEnterHandle?.Invoke(this, other);
        }

        void OnCollisionStay2D(Collision2D other)
        {
            if (!gameObject.activeSelf) { return; }

            OnBodyCollisionStayHandle?.Invoke(this, other);
        }

        void OnCollisionExit2D(Collision2D other)
        {
            if (!gameObject.activeSelf) { return; }

            OnBodyCollisionExitHandle?.Invoke(this, other);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!gameObject.activeSelf) { return; }

            OnBodyTriggerEnterHandle?.Invoke(this, other);
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (!gameObject.activeSelf) { return; }

            OnBodyTriggerStayHandle?.Invoke(this, other);
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (!gameObject.activeSelf) { return; }

            OnBodyTriggerExitHandle?.Invoke(this, other);
        }
        #endregion
    }
}