using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class MummyMaterialSelector : MonoBehaviour
    {
        [SerializeField]
        private List<Material> _materials;

        private void Awake()
        {
            int index = Random.Range(0, _materials.Count);
            GetComponent<SkinnedMeshRenderer>().material = _materials[index];
        }
    }
}