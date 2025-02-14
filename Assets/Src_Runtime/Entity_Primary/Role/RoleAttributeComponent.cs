namespace Practice
{
    public class RoleAttributeComponent
    {
        // Locomotion
        public float moveSpeed;
        public void SetMoveSpeed(float value) => moveSpeed = value;

        public float jumpForce;
        public void SetJumpForce(float value) => jumpForce = value;

        public int jumpTimes;
        public void SetJumpTimes(int value) => jumpTimes = value;
    }
}