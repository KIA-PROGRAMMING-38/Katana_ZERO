using UnityEngine;

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
        public const string WALK = "isWalk";
        public const string RUN = "isRun";
        public const string AIM = "isAim";
        public const string ATTACK = "isAttack";
        public const string KNOCKDOWN = "isKnockDown";
        public const string DIE = "isDie";
    }

    public class EnemyAnimationHash
    {
        public static int s_IDLE = Animator.StringToHash( EnemyAnimationLiteral.IDLE );
        public static int s_WALK = Animator.StringToHash( EnemyAnimationLiteral.WALK );
        public static int s_RUN = Animator.StringToHash( EnemyAnimationLiteral.RUN );
        public static int s_AIM = Animator.StringToHash( EnemyAnimationLiteral.AIM );
        public static int s_ATTACK = Animator.StringToHash( EnemyAnimationLiteral.ATTACK );
        public static int s_KNOCKDOWN = Animator.StringToHash( EnemyAnimationLiteral.KNOCKDOWN );
        public static int s_DIE = Animator.StringToHash( EnemyAnimationLiteral.DIE );
    }

    public static class KissyfaceAnimeLiteral
    {
        public const string TOBATTLE = "isToBattle";
        public const string IDLE = "isIdle";
        public const string PRELUNGE = "isPreLunge";
        public const string LUNGE = "isLunge";
        public const string LUNGEATTACK = "isLungeAttack";
        public const string THROW = "isThrow";
        public const string TUG = "isTug";
        public const string RETURNAXE = "isReturnAxe";
        public const string SLASH = "isSlash";
        public const string PREJUMP = "isPreJump";
        public const string JUMP = "isJump";
        public const string JUMPSWING = "isJumpSwing";
        public const string LANDATTACK = "isLandAttack";
        public const string HURT = "isHurt";
        public const string STRUGGLE = "isStruggle";
        public const string RECOVER = "isRecover";
        public const string DIE = "isDie";
        public const string BLOCK = "isBlock";
    }

    public class KissyfaceAnimeHash
    {
        public static int s_TOBATTLE = Animator.StringToHash( KissyfaceAnimeLiteral.TOBATTLE );
        public static int s_IDLE = Animator.StringToHash( KissyfaceAnimeLiteral.IDLE );
        public static int s_PRELUNGE = Animator.StringToHash( KissyfaceAnimeLiteral.PRELUNGE );
        public static int s_LUNGE = Animator.StringToHash( KissyfaceAnimeLiteral.LUNGE );
        public static int s_LUNGEATTACK = Animator.StringToHash( KissyfaceAnimeLiteral.LUNGEATTACK );
        public static int s_THROW = Animator.StringToHash( KissyfaceAnimeLiteral.THROW );
        public static int s_TUG = Animator.StringToHash( KissyfaceAnimeLiteral.TUG );
        public static int s_RETURNAXE = Animator.StringToHash( KissyfaceAnimeLiteral.RETURNAXE );
        public static int s_SLASH = Animator.StringToHash( KissyfaceAnimeLiteral.SLASH );
        public static int s_PREJUMP = Animator.StringToHash( KissyfaceAnimeLiteral.PREJUMP );
        public static int s_JUMP = Animator.StringToHash( KissyfaceAnimeLiteral.JUMP );
        public static int s_JUMPSWING = Animator.StringToHash( KissyfaceAnimeLiteral.JUMPSWING );
        public static int s_LANDATTACK = Animator.StringToHash( KissyfaceAnimeLiteral.LANDATTACK );
        public static int s_HURT = Animator.StringToHash( KissyfaceAnimeLiteral.HURT );
        public static int s_STRUGGLE = Animator.StringToHash( KissyfaceAnimeLiteral.STRUGGLE );
        public static int s_RECOVER = Animator.StringToHash( KissyfaceAnimeLiteral.RECOVER );
        public static int s_DIE = Animator.StringToHash( KissyfaceAnimeLiteral.DIE );
        public static int s_BLOCK = Animator.StringToHash( KissyfaceAnimeLiteral.BLOCK );
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
        public const string FLOOR = "Floor";
        public const string ITEM = "Item";
        public const string BULLET = "Bullet";
        public const string PLAYER_KATANA_EFFECT = "PlayerKatanaEffect";
    }
}

