using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Spawners
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _objects;
        
        [SerializeField]
        private Transform _parent;
        
        [SerializeField]
        private Vector2 _spawnPeriodRange;
        
        [SerializeField]
        private Vector2 _spawnDelayRange;

        [SerializeField]
        private bool _autoStart = true;

        private Coroutine _spawnRoutine;

        private void Start()
        {
            if (_autoStart)
                StartSpawn();
        }
        
        public void StartSpawn()
        {
            _spawnRoutine = StartCoroutine(Spawn());
        }

        public void StopSpawn()
        {
            StopCoroutine(_spawnRoutine);
        }

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(Random.Range(_spawnDelayRange.x, _spawnDelayRange.y));
            
            while (true)
            {
                var objectToInstantiate = _objects[Random.Range(0, _objects.Length)];
                Instantiate(objectToInstantiate, transform.position, transform.rotation, _parent);
                yield return new WaitForSeconds(Random.Range(_spawnPeriodRange.x, _spawnPeriodRange.y));
            }
        }
    }
}
