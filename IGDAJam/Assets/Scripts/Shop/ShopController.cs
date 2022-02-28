using System.Collections.Generic;
using Entities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Gameplay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup shopObject;

        [SerializeField] private Health shopHealth;
        [SerializeField] private Button closeShopButton;
        [SerializeField] private ShopItemModel[] possibleItemModels;
        [SerializeField] private ShopItemView[] itemSlots;

        private PlayerInput _input;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player") && col.attachedRigidbody.TryGetComponent(out _input))
                SetupShop();
        }
        
        private void SetupShop()
        {
            SetupItemSlots();
            
            EventSystem.current.SetSelectedGameObject(itemSlots[0].gameObject);
            _input.DeactivateInput();
            shopObject.alpha = 1;
            shopObject.interactable = true;
            shopObject.blocksRaycasts = true;
            closeShopButton.onClick.AddListener(CloseShop);
        }

        private void CloseShop()
        {
            _input.ActivateInput();
            shopObject.alpha = 0;
            shopObject.interactable = false;
            shopObject.blocksRaycasts = false;
            closeShopButton.onClick.RemoveListener(CloseShop);
            shopHealth.Damage(shopHealth.MaxHealth);
        }

        private void SetupItemSlots()
        {
            var possibleItems = new List<ShopItemModel>(possibleItemModels);

            foreach (var shopItemView in itemSlots)
            {
                int randomIndex = Random.Range(0, possibleItems.Count);
                UpdateView(shopItemView, possibleItems[randomIndex]);
                possibleItems.RemoveAt(randomIndex);
            }
        }

        private void UpdateView(ShopItemView view, ShopItemModel model)
        {
            view.nameDisplay.UpdateText(model.itemName);
            view.descriptionDisplay.UpdateText(model.itemDescription);
            view.costDisplay.UpdateText($"Cost: {model.cost}");
            view.purchaseButton.onClick.AddListener(() => HandlePurchase(view, model));
        }

        private void HandlePurchase(ShopItemView view, ShopItemModel model)
        {
            view.purchaseButton.interactable = false;
            model.ApplyTo(_input.gameObject);
        }
    }
}