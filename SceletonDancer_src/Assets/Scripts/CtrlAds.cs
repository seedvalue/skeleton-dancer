using UnityEngine;
using GoogleMobileAds.Api;

public class CtrlAds : MonoBehaviour
{
	public static CtrlAds Instance;


	[SerializeField]
	private string bannerId = "ca-app-pub-7602426439989665/7801877402";
	//skeleton
	//ca-app-pub-7602426439989665/7801877402
	
	
	[SerializeField]
	private string interstitialId = "ca-app-pub-7602426439989665/1364106346";
	//skeleton
	//ca-app-pub-7602426439989665/1364106346
	
	BannerView _bannerView;
	AdRequest _requestBanner;

	InterstitialAd _interstitial;
	private AdRequest _requestnterstitial;
	
	public void RequestBanner ()
	{
		
		// Create a 320x50 banner at the top of the screen.
		_bannerView = new BannerView (bannerId, AdSize.Banner, AdPosition.Top);
		// Create an empty ad request.
		_requestBanner = new AdRequest.Builder ().Build ();
		// Load the banner with the request.
		_bannerView.LoadAd (_requestBanner);
	}




	public void RequestInterstitial ()
	{
		if (_interstitial != null && _interstitial.IsLoaded ()) {
			return;
		}
		
		// Initialize an InterstitialAd.
		_interstitial = new InterstitialAd (interstitialId);
		// Create an empty ad request.
		_requestnterstitial = new AdRequest.Builder ().Build ();
		// Load the interstitial with the request.
		_interstitial.LoadAd (_requestnterstitial);
	}
	
	public void ShowInterstitial ()
	{
		if (_interstitial.IsLoaded ()) {
			_interstitial.Show ();
		} else {
			Debug.LogError("ShowInterstitial : _interstitial.IsLoaded is FALSE");
		}
	}
	
	void Awake ()
	{
		if (CtrlAds.Instance)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
	}


	void Start ()
	{
		DontDestroyOnLoad (gameObject);
		RequestInterstitial ();
	}

}
