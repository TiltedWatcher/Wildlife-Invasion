using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{


    [SerializeField] float projectileSpeed;
    [SerializeField] float damage = 50f;
    [SerializeField] bool penetrates;
    private void Update() {

        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);

    }

    public IEnumerator shootProjectile(float speed, bool defenderProjectile) {
        var direction = new Vector2();
        switch (defenderProjectile) {
            case true:
                direction = Vector2.right;
                break;

            case false:
                direction = Vector2.left;
                break;
        }
        while (true) {
            Debug.Log("Moving");
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            yield return new WaitForFixedUpdate();

        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        var otherHealth = otherCollider.GetComponent<HealthManager>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if (attacker && otherHealth) {
            otherHealth.DealDamage(damage);
            if (!penetrates) {

                Destroy(gameObject);
            }
        }




    }


    public float Speed {
        get => projectileSpeed;
        set => projectileSpeed = value;
    }
}
