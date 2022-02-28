using System;
using UnityEngine;

namespace Entities
{
    [CreateAssetMenu(fileName = "Dimension", menuName = "Dimension", order = 0)]
    public class Dimension : ScriptableObject
    {
        public event Action OnEnter;
        public event Action OnExit;

        public bool IsActive { get; private set; } = false;
        
        public void Enter()
        {
            IsActive = true;
            OnEnter?.Invoke();
        }

        public void Exit()
        {
            IsActive = false;
            OnExit?.Invoke();
        }
    }
}