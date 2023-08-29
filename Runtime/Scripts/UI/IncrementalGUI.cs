using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ZenoxZX.UI;
using HotPurpleBerry.Money;

namespace HotPurpleBerry.Incrementals.UI
{
    [Serializable]
    public class IncrementalGUI : GUIBase
    {
        [SerializeField] IncrementalSource incrementalSource;
        [SerializeField] IncrementalButton[] incrementalButtons;

        public void Initialize(MoneySystem moneySystem)
        {
            base.Initialize();

            var incrementals = incrementalSource.Incrementals;

            for (int i = 0; i < incrementals.Length; i++)
            {
                incrementals[i].Load();
                incrementalButtons[i].Initialize(incrementals[i], moneySystem);
            }

            TopMost();
            Open();
        }
    }
}