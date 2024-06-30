using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory : Factory
{
    [SerializeField] private EnemyData EnemyData;

    public override IProduct GetProduct(Vector3 position, Quaternion rotation)
    {
        //int rand = Random.Range(0, 12);
        //float TravelDistance = EnemyData.TravelDistance;

        //GameObject Projectile;

        //if (rand < 2)
        //{
        //    Projectile = EnemyData.EntangleProjectile;
        //}
        //else if (rand < 4)
        //{
        //    Projectile = EnemyData.PoisonProjectile;
        //}
        //else if (rand < 6)
        //{
        //    TravelDistance = EnemyData.TravelDistance * 0.3f;
        //    Projectile = EnemyData.ThornProjectile;
        //}
        //else
        //{
        //    Projectile = EnemyData.ProjectilePref;
        //}

        /////ProjectileObj = GameObject.Instantiate(Projectile, AttackPosition.position, AttackPosition.rotation);
        //ProjectileObj = ObjectPoolManager.SpawnObject(Projectile, AttackPosition.position, AttackPosition.rotation);

        //if (ProjectileObj.TryGetComponent<Projectile>(out Projectile projectile))
        //{
        //    projectile.FireProjectile(EnemyData.ProjectileSpeed, TravelDistance, EnemyData.ProjectileDamage);
        //}
        return null;
    }
}
