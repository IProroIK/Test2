using UnityEngine;
using UnityEngine.Advertisements;
public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string _androidGameID = "4917283";
    [SerializeField] private string _iosGameID = "4917282";
    [SerializeField] private bool testMode = true;
    private string _gameID;

    private void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        _gameID = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iosGameID : _androidGameID;
        Advertisement.Initialize(_gameID, testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Succsesfull add init");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        //Debug.Log($"Adds Init Failed: {error.ToString()} - {message}");
    }
}
