using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

[RequireComponent(typeof(PostProcessingBehaviour))]
public class changeGlow : MonoBehaviour
{
	PostProcessingProfile m_Profile;

	void OnEnable()
	{
		var behaviour = GetComponent<PostProcessingBehaviour>();

		if (behaviour.profile == null)
		{
			enabled = false;
			return;
		}

		m_Profile = Instantiate(behaviour.profile);
		behaviour.profile = m_Profile;
	}

	void Update()
	{
		var bloom = m_Profile.bloom.settings;
		//bloom.bloom.intensity = 2 + Mathf.Sin (Time.fixedTime) * 2;
		m_Profile.bloom.settings = bloom;
	}
}