using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private ScoreInfo playerScore;
    
    [SerializeField] private Button watchAdsButton;
    [SerializeField] private Button nextButton;

    private string gameId = "4428977";
    
    private string placement = "Interstitial_Android";
    
    private void Awake()
    {
        watchAdsButton.onClick.AddListener(ShowAds);
        nextButton.onClick.AddListener(NextScene);
        
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId);
    }
    

    private void ShowAds()
    {
        SoundManager.Instance.Play(SoundClip.Sound.Click);
        Advertisement.Show(placement);
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        { 
            playerScore.Score *= 2;
            SetMaxScore(playerScore.Score);
        }
        
        NextScene();
    }
    
    private void NextScene()
    {
        SoundManager.Instance.Play(SoundClip.Sound.Click);
        SceneManager.LoadScene("EndGame");
    }
    
    private void SetMaxScore(int score)
    {
        if (score > playerScore.MaxScore)
        {
            playerScore.MaxScore = score;
        }
    }

    private void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}
