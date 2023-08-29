using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ZenoxZX.Incrementals
{
    [Serializable]
    public class Incremental
    {
        public event Action<int> OnLevelUp;
        public string name;
        public bool enabled = true;
        public Sprite bg;
        public Sprite icon;
        public int level = 1;
        public int[] costs = { 100, 250, 500, 1500, 2500, 5000, 8000, 10000 };
        [SerializeField] CostType costType = CostType.PresetArray;
        private Func<int, int> costFunction;

        public Incremental()
        {
            costType = CostType.PresetArray;
            this.costs = new int[] { 100, 250, 500, 1500, 2500, 5000, 8000, 10000 };
        }

        public Incremental(int[] costs)
        {
            costType = CostType.PresetArray;
            this.costs = costs;
        }

        public Incremental(Func<int, int> costFunction)
        {
            costType = CostType.Function;
            this.costFunction = costFunction;
        }

        public void SetCostFunction(Func<int, int> costFunction) => this.costFunction = costFunction;

        public int CurrentCost => costType switch
        {
            CostType.PresetArray => costs[level - 1],
            CostType.Function => costFunction(level),
            _ => 0
        };

        private string PREF => $"PREF_INCREMENTAL_{name}";
        public bool CanAfford(int money) => money >= CurrentCost;
        public void LevelUp()
        {
            level++;
            OnLevelUp?.Invoke(level);
            Save();
        }

        public void Save() => PlayerPrefs.SetInt(PREF, level);
        public void Load() => level = PlayerPrefs.GetInt(PREF, 1);

        [SerializeField] 
        enum CostType
        {
            PresetArray,
            Function
        }
    }
}