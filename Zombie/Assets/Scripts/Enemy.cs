using System.Collections;
using UnityEngine;
using UnityEngine.AI; // AI, 내비게이션 시스템 관련 코드를 가져오기

// 적 AI를 구현한다
public class Enemy : LivingEntity {
    public LayerMask whatIsTarget; // 추적 대상 레이어

    private LivingEntity targetEntity; // 추적할 대상
    private NavMeshAgent pathFinder; // 경로계산 AI 에이전트

    public ParticleSystem hitEffect; // 피격시 재생할 파티클 효과
    public AudioClip deathSound; // 사망시 재생할 소리
    public AudioClip hitSound; // 피격시 재생할 소리

    private Animator enemyAnimator; // 애니메이터 컴포넌트
    private AudioSource enemyAudioPlayer; // 오디오 소스 컴포넌트
    private Renderer enemyRenderer; // 렌더러 컴포넌트

    public float damage = 20f; // 공격력
    public float timeBetAttack = 0.5f; // 공격 간격
    private float lastAttackTime; // 마지막 공격 시점

    private void Awake() {
        // 게임 오브젝트로부터 사용할 컴포넌트들을 가져오기
        pathFinder = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        enemyAudioPlayer = GetComponent<AudioSource>();
        enemyRenderer = GetComponentInChildren<Renderer>();
    }

    // 적 AI의 초기 스펙을 결정하는 셋업 메서드
    public void Setup(float newHealth, float newDamage, float newSpeed, Color skinColor) {
        startingHealth = newHealth;
        damage = newDamage;
        pathFinder.speed = newSpeed;
        enemyRenderer.material.color = skinColor;
    }

    private void Start() {
        StartCoroutine(UpdatePath());
    }

    private void Update() {
        enemyAnimator.SetBool("HasTarget", hasTarget);
    }

    // 주기적으로 추적할 대상의 위치를 찾아 경로를 갱신
    private IEnumerator UpdatePath() {
        while (!dead)
        {
            if (hasTarget) {
                pathFinder.isStopped = false;
                pathFinder.SetDestination(
                    targetEntity.transform.position);
            }
            else {
                pathFinder.isStopped = true;

                Collider[] colliders = 
                    Physics.OverlapSphere(transform.position, 20f, whatIsTarget);

                // 모든 콜라이더들을 순회하면서, 살아있는 플레이어를 찾기
                for (int i = 0; i < colliders.Length; i++) {
                    LivingEntity livingEntity = colliders[i].GetComponent<LivingEntity>();
                    if (livingEntity != null && !livingEntity.dead) {
                        targetEntity = livingEntity;
                        break;
                    }
                }
            }

            // 0.25초 주기로 처리 반복
            yield return new WaitForSeconds(0.25f);
        }
    }

    // 데미지를 입었을때 실행할 처리
    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal) {
        // 아직 사망하지 않은 경우에만 피격 효과 재생
        if (!dead) {
            hitEffect.transform.position = hitPoint;
            hitEffect.transform.rotation = Quaternion.LookRotation(hitNormal);
            hitEffect.Play();
            enemyAudioPlayer.PlayOneShot(hitSound);
        }
        base.OnDamage(damage, hitPoint, hitNormal);
    }

    // 사망 처리
    public override void Die() {
        base.Die();

        Collider[] enemyColliders = GetComponents<Collider>();
        for (int i = 0; i < enemyColliders.Length; i++) {
            enemyColliders[i].enabled = false;
        }
        pathFinder.isStopped = true;
        pathFinder.enabled = false;

        enemyAnimator.SetTrigger("Die");
        enemyAudioPlayer.PlayOneShot(deathSound);
    }

    private void OnTriggerStay(Collider other) {
        if (!dead && Time.time >= lastAttackTime + timeBetAttack) {
            LivingEntity attackTarget = other.GetComponent<LivingEntity>();

            if (attackTarget != null && attackTarget == targetEntity) {
                lastAttackTime = Time.time;
                Vector3 hitPoint = other.ClosestPoint(transform.position);
                Vector3 hitNormal = transform.position - other.transform.position;

                attackTarget.OnDamage(damage, hitPoint, hitNormal);
            }
        }
    }
    
    // 추적할 대상이 존재하는지 알려주는 프로퍼티
    private bool hasTarget {
        get {
            if (targetEntity != null && !targetEntity.dead) {
                return true;
            }
            return false;
        }
    }
}