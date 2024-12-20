using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using static UnityEngine.Advertisements.Advertisement;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsShowListener
{
    public static AdsManager main;
    float timer;
    bool bannerVisivel;
    public bool exibindoIntersticial = false;
    public Button button;
    public RecompensaDelegate recompensaDelegate;

    private void Awake()
    {
        main = this;
    }
    private void Start()
    {
        timer = 10f;
        bannerVisivel = true;
        Advertisement.Initialize("5729657", true, this);
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show("Banner_Android");
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (bannerVisivel && timer <= 0 && !exibindoIntersticial)
        {
            Advertisement.Banner.Hide();
            bannerVisivel = false;
            timer = 5f;
        }
        else if (!bannerVisivel && timer <= 0 && !exibindoIntersticial)
        {
            Advertisement.Banner.Show("Banner_Android");
            bannerVisivel = true;
            timer = 10f;
        }
    }
    public void Interstitial(bool podePular)
    {
        if (podePular)
        {
            Advertisement.Show("IntersentialPulavel", this);
            Advertisement.Banner.Hide();
            bannerVisivel = false;

        }
        else
        {
            Advertisement.Show("IntercentialNaoPulavel", this);
            Advertisement.Banner.Hide();
            bannerVisivel = false;

        }
        exibindoIntersticial = true;
    }
    public delegate void RecompensaDelegate(int valor);

    public void RecompensaContinuar()
    {
        Advertisement.Show("Rewarded_Android", this);
        Advertisement.Banner.Hide();
        bannerVisivel = false;
        recompensaDelegate = GameManager.main.ContinuarJogo;
    }

    public void Recompensa()
    {
        Advertisement.Show("Rewarded_Android", this);
        Advertisement.Banner.Hide();
        bannerVisivel = false;
        recompensaDelegate = GameManager.main.AumentarMoeda;
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == "Rewarded_Android" && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            recompensaDelegate(200);
        }
        else if (placementId == "IntersentialPulavel" || placementId == "IntercentialNaoPulavel")
        {
            exibindoIntersticial = false;
        }

    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {

    }

    public void OnUnityAdsShowStart(string placementId)
    {

    }

    public void OnUnityAdsShowClick(string placementId)
    {

    }
    public void OnInitializationComplete()
    {

    }
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {

    }
}
