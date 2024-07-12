using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Score_Num.Gates
{
    public abstract class Gates : MonoBehaviour
    {
        protected delegate void GatesCheckDelegate();
        protected event GatesCheckDelegate BottPlus;
        protected event GatesCheckDelegate TopPlus;

        [SerializeField] protected GameObject _gate;
        public enum Side
        {
            Bottom,
            Top
        }
        protected Side _side;
        protected Side _Side => _side;

        public abstract void ScoreChangeEvent();
        public void EventActivate(Side s)
        {
            switch (s)
            {
                case Side.Bottom:
                    BottPlus?.Invoke();
                    break;
                case Side.Top:
                    TopPlus?.Invoke();
                    break;
            }

        }

    }
}
