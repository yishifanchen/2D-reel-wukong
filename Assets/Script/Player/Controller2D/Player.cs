using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour {
    public bool GodMode;
    [Header("Moving")]
    public float moveSpeed = 3;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;

    [Header("Jump")]
    public float maxJumpHeight = 3;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    public int numberOfJumpMax = 1;
    int numberOfJumpLeft;
    public GameObject JumpEffect;

    [Header("Wall Slide")]
    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public float wallSlideSpeedMax = 3;
    public float wallStickTime = .25f;
    float timeToWallUnstick;

    [Header("Health")]
    public int maxHealth;
    public int Health { get; private set; }
    public GameObject HurtEffect;

    [Header("Sound")]
    public AudioClip jumpSound;
    [Range(0, 1)]
    public float jumpSoundVolume = .5f;
    public AudioClip landSound;
    [Range(0,1)]
    public float landSoundVolume = .5f;
    public AudioClip wallSlideSound;
    [Range(0, 1)]
    public float wallSlideSoundVolume = .5f;
    public AudioClip hurtSound;
    [Range(0, 1)]
    public float hurtSoundVolume = .5f;
    public AudioClip deadSound;
    [Range(0, 1)]
    public float deadSoundVolume = .5f;
    public AudioClip rangeAttackSound;
    [Range(0, 1)]
    public float rangeAttackSoundVolume = .5f;
    public AudioClip meleeAttackSound;
    [Range(0, 1)]
    public float meleeAttackSoundVolume = 0.5f;

    bool isPlayedLandSound;

    [Header("Option")]
    public bool allowMeleeAttack;
    public bool allowRangeAttack;
    public bool allowSlideWall;

    private AudioSource soundFx;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    [HideInInspector]
    public Vector3 velocity;
    float velocityXSmoothing;

    bool isFacingRight;
    bool wallSliding;
    int wallDirX;

    public Vector2 input;

    [HideInInspector]
    public Controller2D controller;
    Animator anim;

    public bool isPlaying { get; private set; }
    public bool isFinish { get; set; }
    private void Awake()
    {
        controller = GetComponent<Controller2D>();
        anim = GetComponent<Animator>();
    }
    void Start () {
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
	}
	
	void Update () {
		
	}
}
