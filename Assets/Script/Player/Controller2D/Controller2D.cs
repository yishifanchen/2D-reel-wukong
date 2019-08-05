using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : RaycastController {

    float maxClimbAngle = 80;//最大攀爬角度
    float maxDescendAngle = 80;//最大下滑角度
    float checkGroundAheadLength = 0.35f;

    public CollisionInfo collisions;
    public Vector2 playerInput;//玩家输入xy
    public bool HandlePhysic = true;
    public override void Start()
    {
        base.Start();
        collisions.faceDir = 1;
    }
    public void Move(Vector3 velocity,Vector2 input,bool standingOnPlatform=false)
    {
        UpdateRaycastOrigins();
        collisions.Reset();
        collisions.velocityOld = velocity;
        playerInput = input;

        if (velocity.x != 0)
        {
            collisions.faceDir = (int)Mathf.Sign(velocity.x);
        }
        if (velocity.y < 0)
        {
            //todo
        }
        if (HandlePhysic)
        {

        }
        transform.Translate(velocity, Space.World);
        if (standingOnPlatform)
        {
            collisions.below = true;
        }
    }
    void HorizontalCollisions(ref Vector3 velocity)
    {
        //float directionX = collisions.faceDir;
        //float rayLength = Mathf.Abs(velocity.x) + skinWidth;

        //if(Mathf.Abs())
    }
    /// <summary>
    /// 碰撞信息
    /// </summary>
    public struct CollisionInfo
    {
        public bool above, below;
        public bool left, right;

        public bool isGroundedAhead;

        public bool climbingSlope;//攀爬斜坡
        public bool descendingSlope;//下滑斜坡
        public float slopeAngle, slopeAngleOld;
        public Vector3 velocityOld;
        public int faceDir;
        public bool fallingThroughPlatform;

        public void Reset()
        {
            above = below = false;
            left = right = false;
            isGroundedAhead = false;
            climbingSlope = false;
            descendingSlope = false;

            slopeAngleOld = slopeAngle;
            slopeAngle =0;
        }
    }
}
