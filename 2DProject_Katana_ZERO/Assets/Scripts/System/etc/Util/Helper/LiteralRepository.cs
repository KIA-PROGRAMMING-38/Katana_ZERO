using UnityEngine;

namespace LiteralRepository
{
    public static class PlayerAnimationLiteral
    {
        public const string IDLE        = "isIdle";
        public const string IDLE_TO_RUN = "isIdleToRun";
        public const string RUN         = "isRun";
        public const string RUN_TO_IDLE = "isRunToIdle";
        public const string JUMP        = "isJump";
        public const string FALL        = "isFall";
        public const string WALL_GRAB   = "isWallGrab";
        public const string WALL_SLIDE  = "isWallSlide";
        public const string WALL_FLIP   = "isWallFlip";
        public const string PRE_CROUCH  = "isPreCrouch";
        public const string CROUCH      = "isCrouch";
        public const string POST_CROUCH = "isPostCrouch";
        public const string ROLL        = "isRoll";
        public const string ATTACK      = "isAttack";
        public const string ONDAMAGED   = "onDamaged";
        public const string DIE         = "isDie";
    }

    public class PlayerAnimationHash
    {
        public static int s_Idle        = Animator.StringToHash( PlayerAnimationLiteral.IDLE );
        public static int s_IdleToRun   = Animator.StringToHash( PlayerAnimationLiteral.IDLE_TO_RUN );
        public static int s_Run         = Animator.StringToHash( PlayerAnimationLiteral.RUN );
        public static int s_RunToIdle   = Animator.StringToHash( PlayerAnimationLiteral.RUN_TO_IDLE );
        public static int s_Jump        = Animator.StringToHash( PlayerAnimationLiteral.JUMP );
        public static int s_Fall        = Animator.StringToHash( PlayerAnimationLiteral.FALL );
        public static int s_WallGrab    = Animator.StringToHash( PlayerAnimationLiteral.WALL_GRAB );
        public static int s_WallSlide   = Animator.StringToHash( PlayerAnimationLiteral.WALL_SLIDE );
        public static int s_WallFlip    = Animator.StringToHash( PlayerAnimationLiteral.WALL_FLIP );
        public static int s_PreCrouch   = Animator.StringToHash( PlayerAnimationLiteral.PRE_CROUCH );
        public static int s_Crouch      = Animator.StringToHash( PlayerAnimationLiteral.CROUCH );
        public static int s_PostCrouch  = Animator.StringToHash( PlayerAnimationLiteral.POST_CROUCH );
        public static int s_Roll        = Animator.StringToHash( PlayerAnimationLiteral.ROLL );
        public static int s_Attack      = Animator.StringToHash( PlayerAnimationLiteral.ATTACK );
        public static int s_OnDamaged   = Animator.StringToHash( PlayerAnimationLiteral.ONDAMAGED );
        public static int s_Die         = Animator.StringToHash( PlayerAnimationLiteral.DIE );
    }

    public static class ItemAnimationLiteral
    {
        public const string IDLE        = "isIdle";
        public const string INTERACTION = "isInteraction";
    }

    public static class EnemyAnimationLiteral
    {
        public const string IDLE        = "isIdle";
        public const string WALK        = "isWalk";
        public const string RUN         = "isRun";
        public const string AIM         = "isAim";
        public const string ATTACK      = "isAttack";
        public const string KNOCKDOWN   = "isKnockDown";
        public const string DIE         = "isDie";
    }

    public static class KissyfaceAnimeLiteral
    {
        public const string TOBATTLE    = "isToBattle";
        public const string IDLE        = "isIdle";
        public const string PRELUNGE    = "isPreLunge";
        public const string LUNGE       = "isLunge";
        public const string LUNGEATTACK = "isLungeAttack";
        public const string THROW       = "isThrow";
        public const string TUG         = "isTug";
        public const string RETURNAXE   = "isReturnAxe";
        public const string SLASH       = "isSlash";
        public const string PREJUMP     = "isPreJump";
        public const string JUMP        = "isJump";
        public const string JUMPSWING   = "isJumpSwing";
        public const string LANDATTACK  = "isLandAttack";
        public const string HURT        = "isHurt";
        public const string STRUGGLE    = "isStruggle";
        public const string RECOVER     = "isRecover";
        public const string DIE         = "isDie";
        public const string BLOCK       = "isBlock";
        public const string DEAD        = "isDead";
        public const string NOHEAD      = "isNoHead";
    }

    public class EnemyAnimationHash
    {
        public static int s_Idle        = Animator.StringToHash( EnemyAnimationLiteral.IDLE );
        public static int s_Walk        = Animator.StringToHash( EnemyAnimationLiteral.WALK );
        public static int s_Run         = Animator.StringToHash( EnemyAnimationLiteral.RUN );
        public static int s_Aim         = Animator.StringToHash( EnemyAnimationLiteral.AIM );
        public static int s_Attack      = Animator.StringToHash( EnemyAnimationLiteral.ATTACK );
        public static int s_KnockDown   = Animator.StringToHash( EnemyAnimationLiteral.KNOCKDOWN );
        public static int s_Die         = Animator.StringToHash( EnemyAnimationLiteral.DIE );
    }

    public class KissyfaceAnimeHash
    {
        public static int s_ToBattle    = Animator.StringToHash( KissyfaceAnimeLiteral.TOBATTLE );
        public static int s_Idle        = Animator.StringToHash( KissyfaceAnimeLiteral.IDLE );
        public static int s_PreLunge    = Animator.StringToHash( KissyfaceAnimeLiteral.PRELUNGE );
        public static int s_Lunge       = Animator.StringToHash( KissyfaceAnimeLiteral.LUNGE );
        public static int s_LungeAttack = Animator.StringToHash( KissyfaceAnimeLiteral.LUNGEATTACK );
        public static int s_Throw       = Animator.StringToHash( KissyfaceAnimeLiteral.THROW );
        public static int s_Tug         = Animator.StringToHash( KissyfaceAnimeLiteral.TUG );
        public static int s_ReturnAxe   = Animator.StringToHash( KissyfaceAnimeLiteral.RETURNAXE );
        public static int s_Slash       = Animator.StringToHash( KissyfaceAnimeLiteral.SLASH );
        public static int s_PreJump     = Animator.StringToHash( KissyfaceAnimeLiteral.PREJUMP );
        public static int s_Jump        = Animator.StringToHash( KissyfaceAnimeLiteral.JUMP );
        public static int s_JumpSwing   = Animator.StringToHash( KissyfaceAnimeLiteral.JUMPSWING );
        public static int s_LandAttack  = Animator.StringToHash( KissyfaceAnimeLiteral.LANDATTACK );
        public static int s_Hurt        = Animator.StringToHash( KissyfaceAnimeLiteral.HURT );
        public static int s_Struggle    = Animator.StringToHash( KissyfaceAnimeLiteral.STRUGGLE );
        public static int s_Recover     = Animator.StringToHash( KissyfaceAnimeLiteral.RECOVER );
        public static int s_Die         = Animator.StringToHash( KissyfaceAnimeLiteral.DIE );
        public static int s_Block       = Animator.StringToHash( KissyfaceAnimeLiteral.BLOCK );
        public static int s_Dead        = Animator.StringToHash( KissyfaceAnimeLiteral.DEAD );
        public static int s_NoHead      = Animator.StringToHash( KissyfaceAnimeLiteral.NOHEAD );
    }

    public class LayerMaskNumber
    {
        public static int s_Default              = 0;
        public static int s_Transparent          = 1;
        public static int s_IgnoreRaycast        = 2;
        public static int s_Ground               = 3;
        public static int s_Water                = 4;
        public static int s_UI                   = 5;
        public static int s_Item                 = 6;
        public static int s_Player               = 7;
        public static int s_Enemy                = 8;
        public static int s_DieEnemy             = 9;
        public static int s_Bullet               = 10;
        public static int s_ReflectedBullet      = 11;
        public static int s_EnemyWeapon          = 12;
        public static int s_EnemyColliderSensor  = 13;
        public static int s_ImmunityState        = 14;
        public static int s_Obstacles            = 15;
        public static int s_Effect               = 16;
        public static int s_PlayerColliderSensor = 17;
        public static int s_DiePlayer            = 18;
        public static int s_FlatGround           = 19;
        public static int s_SlopeGround          = 20;
    }

    public static class InputAxisString
    {
        public const string UP_KEY          = "UpKey";
        public const string DOWN_KEY        = "DownKey";
        public const string HORIZONTAL_KEY  = "Horizontal";
    }

    public static class TagLiteral
    {
        public const string PLAYER               = "Player";
        public const string ENEMY                = "Enemy";
        public const string FLOOR                = "Floor";
        public const string ITEM                 = "Item";
        public const string BULLET               = "Bullet";
        public const string PLAYER_KATANA_EFFECT = "PlayerKatanaEffect";
        public const string DOOR                 = "Door";
    }

    public static class FuncLiteral
    {
        public const string OnDamaged   = "OnDamaged";
        public const string Release     = "Release";
        public const string Burn        = "Burn";
    }
}

