using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GlobalEvents
{
    public class GlobalEventManager
    {
        public enum BUTTON {ANY, RADIO, HEADLIGHT, BREAK};

        public static UnityAction<BUTTON> onButtonEvent;

        public static void StartButtonEvent(BUTTON button)
        {
            onButtonEvent?.Invoke(button);
        }
    }
}
