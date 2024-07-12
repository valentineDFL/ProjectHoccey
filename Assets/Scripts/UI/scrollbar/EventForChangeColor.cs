using System;
using UnityEngine;

namespace Assets.Scripts.UI
{
    internal class EventForChangeColor : MonoBehaviour
    {
        public static event Action ChangeColEv;

        public static void ChangeColor()
        {
            ChangeColEv?.Invoke();
        }
    }
}
