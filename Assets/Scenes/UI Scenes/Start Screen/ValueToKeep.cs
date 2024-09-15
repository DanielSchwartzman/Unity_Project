using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueToKeep : MonoBehaviour
{
    public static ValueToKeep _instance;
    private static int Coins = 0;
    public static ValueToKeep Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ValueToKeep>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(ValueToKeep).Name);
                    _instance = singletonObject.AddComponent<ValueToKeep>();
                }
            }

            return _instance;
        }
    }
    public int getCoins()
    {
        return Coins;
    }
    public void addCoins(int num)
    {
        Coins += num;
    }
}