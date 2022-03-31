using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Character
{
    public abstract class BaseCharacter : MonoBehaviour
    {
       [SerializeField] protected Transform BulletSpawnPosition;

        public int Hp { get; protected internal set; }
        public float Speed { get; protected  set; }
        internal Bullet Bullet { get; private set; }

        protected void Init(int hp, float speed, Bullet bullet, Transform bulletSpawnPosition)
        {
            Hp = hp;
            Speed = speed;
            Bullet = bullet;
            BulletSpawnPosition = bulletSpawnPosition;
        }

        internal abstract void Attack();
        internal abstract void Die();
        internal abstract void Open();
    }
}
