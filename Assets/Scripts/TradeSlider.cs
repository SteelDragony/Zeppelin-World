using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TradeSlider : MonoBehaviour {

    public Text storeAmountText;
    public Text playerInvAmountText;
    public Text transactionAmountText;
    public Text unitCostText;
    public Text TransactionCostText;
    public Slider tradeInputSlider;
    public float startAmount = 0f;
    public float transactionAmount = 0f;
    public float unitPrice = 0f;
    public float transactionPrice = 0f;
	// Use this for initialization
	void Start () {
        startAmount = tradeInputSlider.value;

	}
	
	// Update is called once per frame
	void Update () {
        transactionAmount = tradeInputSlider.value - startAmount;
        storeAmountText.text = (tradeInputSlider.maxValue - tradeInputSlider.value).ToString();
        playerInvAmountText.text = (tradeInputSlider.minValue + tradeInputSlider.value).ToString();
        transactionAmountText.text = transactionAmount.ToString();
        unitCostText.text = unitPrice.ToString();
        TransactionCostText.text = (-transactionAmount * unitPrice).ToString();
	}
}
