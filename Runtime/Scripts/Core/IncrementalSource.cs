using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZenoxZX.Incrementals
{
    [CreateAssetMenu(fileName = "New Incremental Source", menuName = "Hot Purple Berry/Incremental Source")]
    public class IncrementalSource : ScriptableObject
    {
        [SerializeField] Incremental[] incrementals;
        public Incremental[] Incrementals => incrementals;
        
    }
}