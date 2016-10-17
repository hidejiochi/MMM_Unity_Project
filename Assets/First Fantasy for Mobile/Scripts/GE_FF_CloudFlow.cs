// First Fantasy for Mobile
// Version: 1.3.6
// Unity 4.7.1 or higher and Unity 5.3.4 or higher compatilble, see more info in Readme.txt file.
//
// Author:				Gold Experience Team (http://www.ge-team.com)
//
// Unity Asset Store:	https://www.assetstore.unity3d.com/en/#!/content/10822
// GE Store:			http://www.ge-team.com/store/en/products/first-fantasy-for-mobile/
//
// Please direct any bugs/comments/suggestions to support e-mail (geteamdev@gmail.com).

#region Namespaces

using UnityEngine;
using System.Collections;

#endregion // Namespaces

// ######################################################################
// GE_FF_CloudFlow
// Changes UV coordinate.
// ######################################################################

public class GE_FF_CloudFlow : MonoBehaviour
{
	// ########################################
	// Variables
	// ########################################

	#region Variables

	public float m_SpeedU = 0.1f;

	#endregion // Variables

	// ########################################
	// MonoBehaviour Functions
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.html
	// ########################################

	#region MonoBehaviour

	// Update is called every frame, if the MonoBehaviour is enabled.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
	void Update()
	{
		float newOffsetU = Time.time * m_SpeedU;

		if (this.GetComponent<Renderer>())
		{
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(newOffsetU, 0);
		}
	}

	#endregion // MonoBehaviour
}
