using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{


    [SerializeField] float projectileSpeed;
    private void Update() {
        Debug.Log("Speed " + projectileSpeed);

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


    public float Speed {
        get => projectileSpeed;
        set => projectileSpeed = value;
    }
}
