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
        if (target == null) // Caso o inimigo chegue at� o final da fase e a bala n�o encontre seu alvo, ela se destroy, para evitar problema de balas voando por ai
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) //N�o queremos que nossa turret atire mais do que o necess�rio, ent�o calculamos a dist�ncia e cumprimento em dire��o ao alvo, se for menor do que onde  o alvo estiver, o alvo � acertado
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World); //Enquanto n�o acertar o alvo, esse � o c�digo, para a bala se mover em rela��o ao mundo n�o em rela��o ao "lugar"
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
