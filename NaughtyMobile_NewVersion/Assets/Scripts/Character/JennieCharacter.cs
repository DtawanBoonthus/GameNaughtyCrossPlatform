using Character;
using DefaultNamespace;
using Manager;
using UnityEngine;

public class JennieCharacter : BaseCharacter, IDamageable, ICollision, IOpenShelfZero, IOpenShelfOne, IOpenShelfTwo,
    IOpenShelfThree, IOpenShelfFour, IOpenShelfFive, IOpenShelfSix, IOpenShelfSeven, IOpenShelfEight, IOpenShelfNine,
    IOpenShelfTen, IOpenShelfEleven, IOpenShelfTwelve, IOpenShelfThirteen, IOpenShelfFourteen, IOpenShelfFifteen,
    IOpenShelfSixteen
{
    [SerializeField] private CharacterInfo player;
    [SerializeField] private Animator anim;
    
    private UISceneGameplayManager uiSceneGameplayManager;
    private bool isTakeCollision = false;
    private bool isOpen = false;
    private int countBullet = 10;
    
    private void Awake()
    {
        uiSceneGameplayManager = UISceneGameplayManager.Instance;
        uiSceneGameplayManager.SetCountBulletText(countBullet);
    }
    
    internal void Init(int hp, float speed, Bullet defaultBullet)
    {
        base.Init(hp, speed, defaultBullet, BulletSpawnPosition);
    }
    
    internal override void Attack()
    {
        if(countBullet == 0)
        {
            return;
        }

        var bullet = Instantiate(player.DefaultBullet, BulletSpawnPosition.position, BulletSpawnPosition.rotation);
        bullet.Init(BulletSpawnPosition);

        countBullet--;
        
        uiSceneGameplayManager.SetCountBulletText(countBullet);
    }
    
    internal override void Die()
    {
       GameManager.Instance.EndGame();
    }
    
    internal override void Open()
    {
        if (!isOpen && isTakeCollision)
        {
            isOpen = true;
            
            uiSceneGameplayManager.ShowShelfPanel();
        }
        else
        {
            uiSceneGameplayManager.CloseShelfPanel();
            
            isOpen = false;
        }
    }
    
    public void TakeHit(int damage)
    {
        anim.Play("GetHit");
        
        player.Hp -= damage;

        if (player.Hp > 0)
        {
            uiSceneGameplayManager.SetHpUI(damage);
            return;
        }

        Die();
    }
    
    public void TakeCollision()
    {
        if (isOpen)
        {
            uiSceneGameplayManager.CloseOpenUI();
            return;
        }

        isTakeCollision = true;
        
        uiSceneGameplayManager.ShowOpenUI();

    }

    public void NotTakeCollision()
    {
        isOpen = false;
        isTakeCollision = false;
        
        uiSceneGameplayManager.CloseOpenUI();
        uiSceneGameplayManager.CloseShelfPanel();
        uiSceneGameplayManager.CloseShelfUI();
    }

    #region Open Shelf

    public void OpenShelfZero()
    {
        uiSceneGameplayManager.ShowShelfZero();
    }

    public void OpenShelfOne()
    {
        uiSceneGameplayManager.ShowShelfOne();
    }

    public void OpenShelfTwo()
    {
        uiSceneGameplayManager.ShowShelfTwo();
    }

    public void OpenShelfThree()
    {
        uiSceneGameplayManager.ShowShelfThree();
    }

    public void OpenShelfFour()
    {
        uiSceneGameplayManager.ShowShelfFour();
    }

    public void OpenShelfFive()
    {
        uiSceneGameplayManager.ShowShelfFive();
    }

    public void OpenShelfSix()
    {
        uiSceneGameplayManager.ShowShelfSix();
    }

    public void OpenShelfSeven()
    {
        uiSceneGameplayManager.ShowShelfSeven();
    }

    public void OpenShelfEight()
    {
        uiSceneGameplayManager.ShowShelfEight();
    }

    public void OpenShelfNine()
    {
        uiSceneGameplayManager.ShowShelfNine();
    }

    public void OpenShelfTen()
    {
        uiSceneGameplayManager.ShowShelfTen();
    }

    public void OpenShelfEleven()
    {
        uiSceneGameplayManager.ShowShelfEleven();
    }

    public void OpenShelfTwelve()
    {
        uiSceneGameplayManager.ShowShelfTwelve();
    }

    public void OpenShelfThirteen()
    {
        uiSceneGameplayManager.ShowShelfThirteen();
    }

    public void OpenShelfFourteen()
    {
        uiSceneGameplayManager.ShowShelfFourteen();
    }

    public void OpenShelfFifteen()
    {
        uiSceneGameplayManager.ShowShelfFifteen();
    }

    public void OpenShelfSixteen()
    {
        uiSceneGameplayManager.ShowShelfSixteen();
    }

    #endregion
}