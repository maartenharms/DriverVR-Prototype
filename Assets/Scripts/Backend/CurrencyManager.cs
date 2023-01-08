using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Currency 
{
    public class CurrencyManager : MonoBehaviour
    {
        public static GameObject managerInstance;
        private static int currency;

        // Start is called before the first frame update
        void Awake()
        {
            if (managerInstance != null)
                Destroy(gameObject);

            managerInstance = gameObject;
            DontDestroyOnLoad(gameObject);
        }

        public static void AddCurrency(int amount)
        {
            currency += amount;
            Debug.Log(currency);
        }

        public static bool SpendCurrency(int cost)
        {
            if (cost > currency)
                return false;

            currency -= cost;
            return true;
        }
    }
}