﻿using UnityEngine;
using UnityEngine.UI;


	public class PlayerHealthUI : MonoBehaviour
	{
		public UI_HeartMonitor heartMonitor;
		public OverlayCrits overlayCrits;

		//Server calls to update the UI

		public void UpdateHealthUI(UpdateUIMessage validateMsg, float curHealth)
		{
			if (validateMsg == null) //can only be called from server msg
			{
				return;
			}

			DetermineUIDisplay(curHealth);
		}

		private void DetermineUIDisplay(float curHealth)
		{
			heartMonitor.DetermineDisplay(this,
				curHealth); //For the heart monitor anim (atm just working off maxHealth)
			//TODO do any other updates required in here
		}

		/// placeholder based on old code
		public void SetBodyTypeOverlay(BodyPartBehaviour bodyPart)
		{
			foreach (DamageMonitorListener listener in
				UIManager.Instance.GetComponentsInChildren<DamageMonitorListener>())
			{
				if (listener.bodyPartType != bodyPart.Type)
				{
					continue;
				}
				Sprite sprite;
				switch (bodyPart.Severity)
				{
					case DamageSeverity.None:
						sprite = bodyPart.GreenDamageMonitorIcon;
						break;
					case DamageSeverity.Moderate:
						sprite = bodyPart.YellowDamageMonitorIcon;
						break;
					case DamageSeverity.Bad:
						sprite = bodyPart.OrangeDamageMonitorIcon;
						break;
					case DamageSeverity.Critical:
						sprite = bodyPart.RedDamageMonitorIcon;
						break;
					default:
						sprite = bodyPart.GrayDamageMonitorIcon;
						break;
				}
				listener.GetComponent<Image>().sprite = sprite;
			}
		}
	}
