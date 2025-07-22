using UnityEngine;

namespace Objects
{
    public class BulbSpawner
    {
        public static void SpawnBulb(Vector3 position, Quaternion rotation )
        {
            Object.Instantiate(Resources.Load("Prefabs/Bulb"), position, rotation);
        }
        
        public static void SpawnBulb(Vector3 position)
        {
            Object.Instantiate(Resources.Load("Prefabs/Bulb"), position, Quaternion.Euler(0,0, Random.Range(-30,30)));
        }
    }
}