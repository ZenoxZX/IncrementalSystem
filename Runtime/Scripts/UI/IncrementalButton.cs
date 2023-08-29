using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using HotPurpleBerry.Money;

namespace ZenoxZX.Incrementals.UI
{
    public class IncrementalButton : MonoBehaviour
    {
        [SerializeField] Button button;
        [SerializeField] Image bg;
        [SerializeField] Image icon;

        [Header("TMP")]
        [SerializeField] TextMeshProUGUI nameTMP;
        [SerializeField] TextMeshProUGUI levelTMP;
        [SerializeField] TextMeshProUGUI costTMP;

        private Incremental incremental;
        private MoneySystem moneySystem;

        public void Initialize(Incremental incremental, MoneySystem moneySystem)
        {
            if (incremental.enabled)
            {
                this.incremental = incremental;
                this.moneySystem = moneySystem;

                moneySystem.OnMoneyChange += OnMoneyChange;
                button.onClick.AddListener(ButtonOnClick);

                bg.sprite = incremental.bg;
                icon.sprite = incremental.icon;
                nameTMP.SetText(incremental.name);
                levelTMP.SetText($"Level {incremental.level}");
                costTMP.SetText(incremental.CurrentCost.ToString());

                button.interactable = incremental.CanAfford(moneySystem.Money);

                gameObject.SetActive(true);
            }
        }

        private void OnMoneyChange(int money) => button.interactable = incremental.CanAfford(money);

        private void ButtonOnClick()
        {
            if (moneySystem.DecreaseMoney(incremental.CurrentCost))
            {
                incremental.LevelUp();
                levelTMP.SetText($"Level {incremental.level}");
                costTMP.SetText(incremental.CurrentCost.ToString());
            }

            else
                button.interactable = false;
        }
    }
}
