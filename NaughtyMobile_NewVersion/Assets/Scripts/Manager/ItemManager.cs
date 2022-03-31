using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = System.Random;

public class ItemManager : Singleton<ItemManager>
{
    #region Count Item Value

    public int CountCreateItem { get; private set; }

    #region EasyItem

    public int CountScissor { get; private set; }
    public int CountChocolate { get; private set; }
    public int CountGlove { get; private set; }
    public int CountMilk { get; private set; }
    public int CountCola { get; private set; }

    #endregion

    #region ModerateItem

    public int CountBanana { get; private set; }
    public int CountIceCream { get; private set; }
    public int CountFrozenFood { get; private set; }
    public int CountVegetables { get; private set; }

    #endregion

    #region HardItem

    public int CountBattery { get; private set; }
    public int CountWire { get; private set; }
    public int CountLightBulb { get; private set; }

    #endregion

    
    
    #endregion

    #region Private Value

    private static Random _random;

    private int countEasyItem = 5;
    private int countModerateItem = 4;
    private int countHardItem = 3;

    private int countNeedEasyItem = 5;
    private int countNeedModerateItem = 3;
    private int countNeedHardItem = 2;

    private int resetCountItem = 0;

    private int minEasyAndModerateShelf = 0;
    private int maxEasyAndModerateShelf = 12;
    private int minFrozenShelf = 15;
    private int maxFrozenShelf = 17;
    private int minHardShelf = 12;
    private int maxHardShelf = 15;

    private int scoreItameEasy = 20;
    private int scoreItameModerate = 50;
    private int scoreItameHard = 80;
    
    private readonly List<Button> buttonItemShelfScissor = new List<Button>();
    private readonly List<Button> buttonItemShelfChocolate = new List<Button>();
    private readonly List<Button> buttonItemShelfGlove = new List<Button>();
    private readonly List<Button> buttonItemShelfMilk = new List<Button>();
    private readonly List<Button> buttonItemShelfCola = new List<Button>();
    private readonly List<Button> buttonItemShelfBanana = new List<Button>();
    private readonly List<Button> buttonItemShelfIceCream = new List<Button>();
    private readonly List<Button> buttonItemShelfFrozenFood = new List<Button>();
    private readonly List<Button> buttonItemShelfVegetables = new List<Button>();
    private readonly List<Button> buttonItemShelfBattery = new List<Button>();
    private readonly List<Button> buttonItemShelfWire = new List<Button>();
    private readonly List<Button> buttonItemShelfLightBulb = new List<Button>();

    #endregion

    #region SetInfo From Inspector

    [Header("Prefab Item")] 
    [SerializeField] private ItemList itemList;
    [SerializeField] private ItemShelf itemShelf;

    [Header("Panel Position")] 
    [SerializeField] private Transform itemListPanel;
    [SerializeField] private Transform[] itemShelfPanel;

    [Space]
    [Header("Sprite Item")]
    [SerializeField] private Sprite scissorSprite;
    [SerializeField] private Sprite chocolateSprite;
    [SerializeField] private Sprite gloveSprite;
    [SerializeField] private Sprite milkSprite;
    [SerializeField] private Sprite colaSprite;
    [SerializeField] private Sprite bananaSprite;
    [SerializeField] private Sprite iceCreamSprite;
    [SerializeField] private Sprite frozenFoodSprite;
    [SerializeField] private Sprite vegetablesSprite;
    [SerializeField] private Sprite batterySprite;
    [SerializeField] private Sprite wireSprite;
    [SerializeField] private Sprite lightBulbSprite;

    #endregion

    private void Awake()
    {
        _random = new Random();
        
        CountCreateItem = countNeedEasyItem + countNeedModerateItem + countNeedHardItem;

        StartGame();
        SetOnClick();
    }
    
    private void SetOnClick()
    {
        if (buttonItemShelfScissor.Count != 0)
        {
            foreach (var buttonItemShelf in buttonItemShelfScissor)
            {
                buttonItemShelf.onClick.AddListener(delegate { SetScoreEasyItem(buttonItemShelf); });
            }
        }

        if (buttonItemShelfChocolate.Count != 0)
        {
            foreach (var buttonItemShelf in buttonItemShelfChocolate)
            {
                buttonItemShelf.onClick.AddListener(delegate { SetScoreEasyItem(buttonItemShelf); });
            }
        }

        if (buttonItemShelfGlove.Count != 0)
        {
            foreach (var buttonItemShelf in buttonItemShelfGlove)
            {
                buttonItemShelf.onClick.AddListener(delegate { SetScoreEasyItem(buttonItemShelf); });
            }
        }

        if (buttonItemShelfMilk.Count != 0)
        {
            foreach (var buttonItemShelf in buttonItemShelfMilk)
            {
                buttonItemShelf.onClick.AddListener(delegate { SetScoreEasyItem(buttonItemShelf); });
            }
        }

        if (buttonItemShelfCola.Count != 0)
        {
            foreach (var buttonItemShelf in buttonItemShelfCola)
            {
                buttonItemShelf.onClick.AddListener(delegate { SetScoreEasyItem(buttonItemShelf); });
            }
        }

        if (buttonItemShelfBanana.Count != 0)
        {
            foreach (var buttonItemShelf in buttonItemShelfBanana)
            {
                buttonItemShelf.onClick.AddListener(delegate { SetScoreModerateItem(buttonItemShelf); });
            }
        }

        if (buttonItemShelfIceCream.Count != 0)
        {
            foreach (var buttonItemShelf in buttonItemShelfIceCream)
            {
                buttonItemShelf.onClick.AddListener(delegate { SetScoreModerateItem(buttonItemShelf); });
            }
        }

        if (buttonItemShelfFrozenFood.Count != 0)
        {
            foreach (var buttonItemShelf in buttonItemShelfFrozenFood)
            {
                buttonItemShelf.onClick.AddListener(delegate { SetScoreModerateItem(buttonItemShelf); });
            }
        }

        if (buttonItemShelfVegetables.Count != 0)
        {
            foreach (var buttonItemShelf in buttonItemShelfVegetables)
            {
                buttonItemShelf.onClick.AddListener(delegate { SetScoreModerateItem(buttonItemShelf); });
            }
        }

        if (buttonItemShelfBattery.Count != 0)
        {
            foreach (var buttonItemShelf in buttonItemShelfBattery)
            {
                buttonItemShelf.onClick.AddListener(delegate { SetScoreHardItem(buttonItemShelf); });
            }
        }

        if (buttonItemShelfWire.Count != 0)
        {
            foreach (var buttonItemShelf in buttonItemShelfWire)
            {
                buttonItemShelf.onClick.AddListener(delegate { SetScoreHardItem(buttonItemShelf); });
            }
        }
        
        if (buttonItemShelfLightBulb.Count != 0)
        {
            foreach (var buttonItemShelf in buttonItemShelfLightBulb)
            {
                buttonItemShelf.onClick.AddListener(delegate { SetScoreHardItem(buttonItemShelf); });
            }
        }
    }

    private void SetScoreEasyItem(Button button)
    {
        SoundManager.Instance.Play(SoundClip.Sound.Click);
        ScoreManager.Instance.GetScore(scoreItameEasy);
        
        CountCreateItem -= 1;
        
        CheckEndGame(CountCreateItem);
        
        button.gameObject.SetActive(false);
    }

    private void SetScoreModerateItem(Button button)
    {
        SoundManager.Instance.Play(SoundClip.Sound.Click);
        ScoreManager.Instance.GetScore(scoreItameModerate);
        
        CountCreateItem -= 1;
        
        CheckEndGame(CountCreateItem);
        
        button.gameObject.SetActive(false);
    }

    private void SetScoreHardItem(Button button)
    {
        SoundManager.Instance.Play(SoundClip.Sound.Click);
        ScoreManager.Instance.GetScore(scoreItameHard);
        
        CountCreateItem -= 1;
        
        CheckEndGame(CountCreateItem);

        button.gameObject.SetActive(false);
    }

    private void CheckEndGame(int countItem)
    {
        if (CountCreateItem == 0)
        {
            GameManager.Instance.EndGame();
        }
    }
    
    
    private void StartGame()
    {
        CountScissor = resetCountItem;
        CountChocolate = resetCountItem;
        CountGlove = resetCountItem;
        CountMilk = resetCountItem;
        CountCola = resetCountItem;
        CountBanana = resetCountItem;
        CountIceCream = resetCountItem;
        CountFrozenFood = resetCountItem;
        CountVegetables = resetCountItem;
        CountBattery = resetCountItem;
        CountWire = resetCountItem;
        CountLightBulb = resetCountItem;

        SetEasyItemList();
        SetModerateItemList();
        SetHardItemList();
        CreateItemList();
        StartCreateItemShelf();
    }

    private void StartCreateItemShelf()
    {
        CreateItemShelf(Items.Scissor, scissorSprite, CountScissor, minEasyAndModerateShelf, maxEasyAndModerateShelf);
        CreateItemShelf(Items.Chocolate, chocolateSprite, CountChocolate, minEasyAndModerateShelf,
            maxEasyAndModerateShelf);
        CreateItemShelf(Items.Glove, gloveSprite, CountGlove, minEasyAndModerateShelf, maxEasyAndModerateShelf);
        CreateItemShelf(Items.Milk, milkSprite, CountMilk, minEasyAndModerateShelf, maxEasyAndModerateShelf);
        CreateItemShelf(Items.Cola, colaSprite, CountCola, minEasyAndModerateShelf, maxEasyAndModerateShelf);
        CreateItemShelf(Items.Banana, bananaSprite, CountBanana, minEasyAndModerateShelf, maxEasyAndModerateShelf);
        CreateItemShelf(Items.Vegetables, vegetablesSprite, CountVegetables, minEasyAndModerateShelf,
            maxEasyAndModerateShelf);
        CreateItemShelf(Items.IceCream, iceCreamSprite, CountIceCream, minFrozenShelf, maxFrozenShelf);
        CreateItemShelf(Items.FrozenFood, frozenFoodSprite, CountFrozenFood, minFrozenShelf, maxFrozenShelf);

        CreateItemShelf(Items.Battery, batterySprite, CountBattery, minHardShelf, maxHardShelf);
        CreateItemShelf(Items.Wire, wireSprite, CountWire, minHardShelf, maxHardShelf);
        CreateItemShelf(Items.LightBulb, lightBulbSprite, CountLightBulb, minHardShelf, maxHardShelf);
    }

    private void CreateItemShelf(Enum nameItem, Sprite imageItem, int count, int min, int max)
    {
        if (count != 0)
        {
            for (int i = 0; i < count; i++)
            {
                var item = Instantiate(itemShelf, itemShelfPanel[_random.Next(min, max)]);
                item.Init(nameItem, imageItem);
                
                switch (nameItem)
                {
                    case Items.Scissor:
                        buttonItemShelfScissor.Add(item.Button);
                        break;
                    case Items.Chocolate:
                        buttonItemShelfChocolate.Add(item.Button);
                        break;
                    case Items.Glove:
                        buttonItemShelfGlove.Add(item.Button);
                        break;
                    case Items.Milk:
                        buttonItemShelfMilk.Add(item.Button);
                        break;
                    case Items.Cola:
                        buttonItemShelfCola.Add(item.Button);
                        break;
                    case Items.Banana:
                        buttonItemShelfBanana.Add(item.Button);
                        break;
                    case Items.IceCream:
                        buttonItemShelfIceCream.Add(item.Button);
                        break;
                    case Items.FrozenFood:
                        buttonItemShelfFrozenFood.Add(item.Button);
                        break;
                    case Items.Vegetables:
                        buttonItemShelfVegetables.Add(item.Button);
                        break;
                    case Items.Battery:
                        buttonItemShelfBattery.Add(item.Button);
                        break;
                    case Items.Wire:
                        buttonItemShelfWire.Add(item.Button);
                        break;
                    case Items.LightBulb:
                        buttonItemShelfLightBulb.Add(item.Button);
                        break;
                }
            }
        }
    }

    private void SetEasyItemList()
    {
        for (int i = 0; i < countNeedEasyItem; i++)
        {
            RandomEasyItem(_random.Next(countEasyItem));
        }
    }

    private void SetModerateItemList()
    {
        for (int i = 0; i < countNeedModerateItem; i++)
        {
            RandomModerateItem(_random.Next(countModerateItem));
        }
    }

    private void SetHardItemList()
    {
        for (int i = 0; i < countNeedHardItem; i++)
        {
            RandomHardItem(_random.Next(countHardItem));
        }
    }

    private void RandomEasyItem(int random)
    {
        switch (random)
        {
            case 0:
                ++CountScissor;
                break;
            case 1:
                ++CountChocolate;
                break;
            case 2:
                ++CountGlove;
                break;
            case 3:
                ++CountMilk;
                break;
            case 4:
                ++CountCola;
                break;
        }
    }

    private void RandomHardItem(int random)
    {
        switch (random)
        {
            case 0:
                ++CountBattery;
                break;
            case 1:
                ++CountWire;
                break;
            case 2:
                ++CountLightBulb;
                break;
        }
    }

    private void RandomModerateItem(int random)
    {
        switch (random)
        {
            case 0:
                ++CountBanana;
                break;
            case 1:
                ++CountIceCream;
                break;
            case 2:
                ++CountFrozenFood;
                break;
            case 3:
                ++CountVegetables;
                break;
        }
    }

    private void CreateItemList()
    {
        if (CountScissor > 0)
        {
            InstantiateItemList(Items.Scissor, scissorSprite, CountScissor);
        }

        if (CountChocolate > 0)
        {
            InstantiateItemList(Items.Chocolate, chocolateSprite, CountChocolate);
        }

        if (CountGlove > 0)
        {
            InstantiateItemList(Items.Glove, gloveSprite, CountGlove);
        }

        if (CountMilk > 0)
        {
            InstantiateItemList(Items.Milk, milkSprite, CountMilk);
        }

        if (CountCola > 0)
        {
            InstantiateItemList(Items.Cola, colaSprite, CountCola);
        }

        if (CountBanana > 0)
        {
            InstantiateItemList(Items.Banana, bananaSprite, CountBanana);
        }

        if (CountIceCream > 0)
        {
            InstantiateItemList(Items.IceCream, iceCreamSprite, CountIceCream);
        }

        if (CountFrozenFood > 0)
        {
            InstantiateItemList(Items.FrozenFood, frozenFoodSprite, CountFrozenFood);
        }

        if (CountVegetables > 0)
        {
            InstantiateItemList(Items.Vegetables, vegetablesSprite, CountVegetables);
        }

        if (CountBattery > 0)
        {
            InstantiateItemList(Items.Battery, batterySprite, CountBattery);
        }

        if (CountWire > 0)
        {
            InstantiateItemList(Items.Wire, wireSprite, CountWire);
        }

        if (CountLightBulb > 0)
        {
            InstantiateItemList(Items.LightBulb, lightBulbSprite, CountLightBulb);
        }
    }

    private void InstantiateItemList(Enum nameItem, Sprite imageItem, int count)
    {
        var itemLists = Instantiate(itemList, itemListPanel);
        itemLists.Init(nameItem, imageItem, count);
    }

    private enum Items
    {
        Scissor,
        Chocolate,
        Glove,
        Milk,
        Cola,
        Banana,
        IceCream,
        FrozenFood,
        Vegetables,
        Battery,
        Wire,
        LightBulb
    }
}