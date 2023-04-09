namespace StringLiteral
{
    public static class PlayerAnimationLiteral
    {
        public const string IDLE = "isIdle";
        public const string IDLE_TO_RUN = "isIdleToRun";
        public const string RUN = "isRun";
        public const string RUN_TO_IDLE = "isRunToIdle";
        public const string JUMP = "isJump";
        public const string FALL = "isFall";
        public const string WALL_GRAB = "isWallGrab";
        public const string WALL_SLIDE = "isWallSlide";
        public const string WALL_FLIP = "isWallFlip";
        public const string PRE_CROUCH = "isPreCrouch";
        public const string CROUCH = "isCrouch";
        public const string POST_CROUCH = "isPostCrouch";
        public const string ROLL = "isRoll";
        public const string ATTACK = "isAttack";
    }

    public static class ItemAnimationLiteral
    {
        public const string IDLE = "isIdle";
        public const string INTERACTION = "isInteraction";
    }

    public static class EnemyAnimationLiteral
    {
        public const string IDLE = "isIdle";
        public const string RETURN = "isReturn";
        public const string WALK = "isWalk";
        public const string RUN = "isRun";
        public const string ATTACK = "isAttack";
        public const string KNOCKDOWN = "isKnockDown";
    }

    public static class InputAxisString
    {
        public const string UP_KEY = "UpKey";
        public const string DOWN_KEY = "DownKey";
        public const string HORIZONTAL_KEY = "Horizontal";
    }

    public static class TagLiteral
    {
        public const string PLAYER = "Player";
        public const string ENEMY = "Enemy";
        public const string FRONTIER = "Frontier";
        public const string ITEM = "Item";
    }
}
