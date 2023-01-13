using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Text _moneyInWallet;
    public List<int> _priceList = new List<int>();
    public ulong _money = 0;

    private void Update() {
        _moneyInWallet.text = _money.ToString();
    }

    public void PayFromWallet(int pricePosition){
        _money -= (ulong)_priceList[pricePosition];
    }

    public void AddMoneyToWallet(int money){
        _money += (ulong)money;
    }
}
