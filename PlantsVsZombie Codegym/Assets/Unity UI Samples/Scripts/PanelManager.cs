using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;


public class PanelManager : MonoBehaviour {
	[Header("UI")]
	
	public Animator initiallyOpen;
	public Animator authMenu;
	private int m_OpenParameterId;
	private Animator m_Open;
	private GameObject m_PreviouslySelected;
	
	const string k_OpenTransitionName = "Open";
	const string k_ClosedStateName = "Closed";

	public Text messageText;
	public InputField emailInput;
	public InputField passwordInput;
	public static bool isAuthenticated;
	public void OnEnable()
	{
		m_OpenParameterId = Animator.StringToHash (k_OpenTransitionName);
		if (initiallyOpen == null)
			return;

		OpenPanel(initiallyOpen);
	}
    public void OpenPanel (Animator anim)
	{
        if (!isAuthenticated)
        {
			anim = authMenu;
        }
		if (m_Open == anim)
			return;

		anim.gameObject.SetActive(true);
		var newPreviouslySelected = EventSystem.current.currentSelectedGameObject;

		anim.transform.SetAsLastSibling();

		CloseCurrent();

		m_PreviouslySelected = newPreviouslySelected;

		m_Open = anim;
		m_Open.SetBool(m_OpenParameterId, true);

		GameObject go = FindFirstEnabledSelectable(anim.gameObject);

		SetSelected(go);
	}

	static GameObject FindFirstEnabledSelectable (GameObject gameObject)
	{
		GameObject go = null;
		var selectables = gameObject.GetComponentsInChildren<Selectable> (true);
		foreach (var selectable in selectables) {
			if (selectable.IsActive () && selectable.IsInteractable ()) {
				go = selectable.gameObject;
				break;
			}
		}
		return go;
	}

	public void CloseCurrent()
	{
		if (m_Open == null)
			return;

		m_Open.SetBool(m_OpenParameterId, false);
		SetSelected(m_PreviouslySelected);
		StartCoroutine(DisablePanelDeleyed(m_Open));
		m_Open = null;
	}
	 public void RegisterButton()
    {
        if (passwordInput.text.Length < 6)
        {
			messageText.text = "Password too short!";
			return;
        }
        var request = new RegisterPlayFabUserRequest
		{
			Email = emailInput.text,
			Password = passwordInput.text,
			RequireBothUsernameAndEmail = false,
		};
		messageText.text = "Registering...";
		PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
	void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
		isAuthenticated = true;
		messageText.text = "Registered and Logged in !!!";
		OpenPanel(initiallyOpen);
    }
	public void Login()
    {
		var request = new LoginWithEmailAddressRequest
		{
			Email = emailInput.text,
			Password = passwordInput.text,
		};
		messageText.text = "Authenticating...";
		PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
	void OnLoginSuccess(LoginResult result)
    {
		isAuthenticated = true;
		messageText.text = "Logged In!";
		Debug.Log("Successfull Logged in");
		OpenPanel(initiallyOpen);
    }
	void OnError(PlayFabError error)
    {
		messageText.text = error.ErrorMessage;
		Debug.Log(error.GenerateErrorReport());
    }
	
	IEnumerator DisablePanelDeleyed(Animator anim)
	{
		bool closedStateReached = false;
		bool wantToClose = true;
		while (!closedStateReached && wantToClose)
		{
			if (!anim.IsInTransition(0))
				closedStateReached = anim.GetCurrentAnimatorStateInfo(0).IsName(k_ClosedStateName);

			wantToClose = !anim.GetBool(m_OpenParameterId);

			yield return new WaitForEndOfFrame();
		}

		if (wantToClose)
			anim.gameObject.SetActive(false);
	}

	private void SetSelected(GameObject go)
	{
		EventSystem.current.SetSelectedGameObject(go);
	}
}
