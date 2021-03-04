using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker: MonoBehaviour {

    [SerializeField] int playerLifeDamage = 1;



    //states
    float currentSpeed = 1f;

    //cached references
    GameObject currentTarget;
    Animator animator;

    private void Awake() {
        FindObjectOfType<LevelControler>().AttackerHasSpawned();
    }
    private void OnDestroy() {
        FindObjectOfType<LevelControler>().AttackerWasDestroyed();
    }

    private void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        updateAnimationState();
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
    }

    private void updateAnimationState() {
        if (!currentTarget) {
            animator.SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed) {
        currentSpeed = speed;
    }

    public void Attack(GameObject target) {

        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void HitCurrentTarget(float damage) {
        if (!currentTarget) {
            return;
        }
        HealthManager health = currentTarget.GetComponent<HealthManager>();

        if (health) {
            health.DealDamage(damage);
        }


    }

    public int PlayerLifeDamage{
        get => playerLifeDamage;
    }

}
