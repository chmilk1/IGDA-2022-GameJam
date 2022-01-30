using System.Collections;
using UnityEngine;

namespace Entities.Enemy
{
    public class RandomMoveEnemy : MonoBehaviour
    {
        public State IdleState = new IdleState();
        public State AttackState = new AttackState();

        public State CurrentState;
    }

    public class IdleState : State
    {
        
    }

    public class AttackState : State
    {
        
    }

    public abstract class State
    {
        public virtual IEnumerator OnEnter()
        {
            yield return null;
        }
    }
}