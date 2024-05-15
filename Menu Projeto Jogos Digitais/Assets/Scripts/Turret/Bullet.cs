using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public int moneyGain = 25;    
    public GameObject impactEffect;
    public void Seek(Transform _target)
    {
        target = _target; 
    }

    
    void Update()
    {
        if (target == null) // Caso o inimigo chegue até o final da fase e a bala não encontre seu alvo, ela se destroy, para evitar problema de balas voando por ai
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) //Não queremos que nossa turret atire mais do que o necessário, então calculamos a distância e cumprimento em direção ao alvo, se for menor do que onde  o alvo estiver, o alvo é acertado
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World); //Enquanto não acertar o alvo, esse é o código, para a bala se mover em relação ao mundo não em relação ao "lugar"
    }

    void HitTarget()  //O que acontece ao inimigo ser acertado
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TomarDano(35);
        }
        Destroy(gameObject);
    }

}
