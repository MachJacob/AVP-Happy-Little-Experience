/************************************************************************************
Copyright : Copyright (c) Facebook Technologies, LLC and its affiliates. All rights reserved.

Licensed under the Oculus Utilities SDK License Version 1.31 (the "License"); you may not use
the Utilities SDK except in compliance with the License, which is provided at the time of installation
or download, or which otherwise accompanies this software in either electronic or hard copy form.

You may obtain a copy of the License at
https://developer.oculus.com/licenses/utilities-1.31

Unless required by applicable law or agreed to in writing, the Utilities SDK distributed
under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
ANY KIND, either express or implied. See the License for the specific language governing
permissions and limitations under the License.
************************************************************************************/

using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class OVRGearVrControllerTest : MonoBehaviour
{
	public class BoolMonitor
	{
		public delegate bool BoolGenerator();

		private string m_name = "";
		private BoolGenerator m_generator;
		private bool m_prevValue = false;
		private bool m_currentValue = false;
		private bool m_currentValueRecentlyChanged = false;
		private float m_displayTimeout = 0.0f;
		private float m_displayTimer = 0.0f;

		public BoolMonitor(string name, BoolGenerator generator, float displayTimeout = 0.5f)
		{
			m_name = name;
			m_generator = generator;
			m_displayTimeout = displayTimeout;
		}

		public void Update()
		{
			m_prevValue = m_currentValue;
			m_currentValue = m_generator();

			if (m_currentValue != m_prevValue)
			{
				m_currentValueRecentlyChanged = true;
				m_displayTimer = m_displayTimeout;
			}

			if (m_displayTimer > 0.0f)
			{
				m_displayTimer -= Time.deltaTime;

				if (m_displayTimer <= 0.0f)
				{
					m_currentValueRecentlyChanged = false;
					m_displayTimer = 0.0f;
				}
			}
		}

		public void AppendToStringBuilder(ref StringBuilder sb)
		{
			sb.Append(m_name);

			if (m_currentValue && m_currentValueRecentlyChanged)
				sb.Append(": *True*\n");
			else if (m_currentValue)
				sb.Append(":  True \n");
			else if (!m_currentValue && m_currentValueRecentlyChanged)
				sb.Append(": *False*\n");
			else if (!m_currentValue)
				sb.Append(":  False \n");
		}
	}

	public Text uiText;
	private List<BoolMonitor> monitors;
	private StringBuilder data;

	void Start()
	{
		if (uiText != null)
		{
			uiText.supportRichText = false;
		}

		data = new StringBuilder(2048);

		monitors = new List<BoolMonitor>()
		{
			// virtual
			new BoolMonitor("Start",                            () => OVRInput.Get(OVRInput.Button.Start)),
            new BoolMonitor("StartDown",                        () => OVRInput.GetDown(OVRInput.Button.Start)),
            new BoolMonitor("StartUp",                          () => OVRInput.GetUp(OVRInput.Button.Start)),
            new BoolMonitor("Back",                             () => OVRInput.Get(OVRInput.Button.Back)),
            new BoolMonitor("BackDown",                         () => OVRInput.GetDown(OVRInput.Button.Back)),
            new BoolMonitor("BackUp",                           () => OVRInput.GetUp(OVRInput.Button.Back)),

            new BoolMonitor("WasRecentered",                    () => OVRInput.GetControllerWasRecentered()),
			new BoolMonitor("One",                              () => OVRInput.Get(OVRInput.Button.One)),
			new BoolMonitor("OneDown",                          () => OVRInput.GetDown(OVRInput.Button.One)),
			new BoolMonitor("OneUp",                            () => OVRInput.GetUp(OVRInput.Button.One)),
			new BoolMonitor("Two",                              () => OVRInput.Get(OVRInput.Button.Two)),
			new BoolMonitor("TwoDown",                          () => OVRInput.GetDown(OVRInput.Button.Two)),
			new BoolMonitor("TwoUp",                            () => OVRInput.GetUp(OVRInput.Button.Two)),
            new BoolMonitor("Three",                            () => OVRInput.Get(OVRInput.Button.Three)),
            new BoolMonitor("ThreeDown",                        () => OVRInput.GetDown(OVRInput.Button.Three)),
            new BoolMonitor("ThreeUp",                          () => OVRInput.GetUp(OVRInput.Button.Three)),
            new BoolMonitor("Four",                             () => OVRInput.Get(OVRInput.Button.Four)),
            new BoolMonitor("FourDown",                         () => OVRInput.GetDown(OVRInput.Button.Four)),
            new BoolMonitor("FourUp",                           () => OVRInput.GetUp(OVRInput.Button.Four)),
			new BoolMonitor("Up",                               () => OVRInput.Get(OVRInput.Button.Up)),
			new BoolMonitor("Down",                             () => OVRInput.Get(OVRInput.Button.Down)),
			new BoolMonitor("Left",                             () => OVRInput.Get(OVRInput.Button.Left)),
			new BoolMonitor("Right",                            () => OVRInput.Get(OVRInput.Button.Right)),
            new BoolMonitor("DpadUp",                           () => OVRInput.Get(OVRInput.Button.DpadUp)),
            new BoolMonitor("DpadDown",                         () => OVRInput.Get(OVRInput.Button.DpadDown)),
            new BoolMonitor("DpadLeft",                         () => OVRInput.Get(OVRInput.Button.DpadLeft)),
            new BoolMonitor("DpadRight",                        () => OVRInput.Get(OVRInput.Button.DpadRight)),

            new BoolMonitor("One (Touch)",                      () => OVRInput.Get(OVRInput.Touch.One)),
			new BoolMonitor("OneDown (Touch)",                  () => OVRInput.GetDown(OVRInput.Touch.One)),
			new BoolMonitor("OneUp (Touch)",                    () => OVRInput.GetUp(OVRInput.Touch.One)),
            new BoolMonitor("Two (Touch)",                      () => OVRInput.Get(OVRInput.Touch.Two)),
            new BoolMonitor("TwoDown (Touch)",                  () => OVRInput.GetDown(OVRInput.Touch.Two)),
            new BoolMonitor("TwoUp (Touch)",                    () => OVRInput.GetUp(OVRInput.Touch.Two)),
            new BoolMonitor("Three (Touch)",                    () => OVRInput.Get(OVRInput.Touch.Three)),
            new BoolMonitor("ThreeDown (Touch)",                () => OVRInput.GetDown(OVRInput.Touch.Three)),
            new BoolMonitor("ThreeUp (Touch)",                  () => OVRInput.GetUp(OVRInput.Touch.Three)),
            new BoolMonitor("Four (Touch)",                     () => OVRInput.Get(OVRInput.Touch.Four)),
            new BoolMonitor("FourDown (Touch)",                 () => OVRInput.GetDown(OVRInput.Touch.Four)),
            new BoolMonitor("FourUp (Touch)",                   () => OVRInput.GetUp(OVRInput.Touch.Four)),


            new BoolMonitor("PrimaryIndexTrigger",              () => OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)),
			new BoolMonitor("PrimaryIndexTriggerDown",          () => OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)),
			new BoolMonitor("PrimaryIndexTriggerUp",            () => OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)),
            new BoolMonitor("PrimaryHandTrigger",               () => OVRInput.Get(OVRInput.Button.PrimaryHandTrigger)),
			new BoolMonitor("PrimaryHandTriggerDown",           () => OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger)),
			new BoolMonitor("PrimaryHandTriggerUp",             () => OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger)),
            new BoolMonitor("PrimaryShoulder",                  () => OVRInput.Get(OVRInput.Button.PrimaryShoulder)),
            new BoolMonitor("PrimaryShoulderDown",              () => OVRInput.GetDown(OVRInput.Button.PrimaryShoulder)),
            new BoolMonitor("PrimaryShoulderUp",                () => OVRInput.GetUp(OVRInput.Button.PrimaryShoulder)),
            new BoolMonitor("PrimaryThumbstick",                () => OVRInput.Get(OVRInput.Button.PrimaryThumbstick)),
            new BoolMonitor("PrimaryThumbstickDown",            () => OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick)),
            new BoolMonitor("PrimaryThumbstickUp",              () => OVRInput.GetUp(OVRInput.Button.PrimaryThumbstick)),
            new BoolMonitor("PrimaryThumbstick^",               () => OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp)),
            new BoolMonitor("PrimaryThumbstick^Down",           () => OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickUp)),
            new BoolMonitor("PrimaryThumbstick^Up",             () => OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickUp)),
            new BoolMonitor("PrimaryThumbstick\\/",             () => OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown)),
            new BoolMonitor("PrimaryThumbstick\\/Down",         () => OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown)),
            new BoolMonitor("PrimaryThumbstick\\/Up",           () => OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickDown)),
            new BoolMonitor("PrimaryThumbstick<",               () => OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft)),
            new BoolMonitor("PrimaryThumbstick<Down",           () => OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft)),
            new BoolMonitor("PrimaryThumbstick<Up",             () => OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickLeft)),
            new BoolMonitor("PrimaryThumbstick>",               () => OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight)),
            new BoolMonitor("PrimaryThumbstick>Down",           () => OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight)),
            new BoolMonitor("PrimaryThumbstick>Up",             () => OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickRight)),

            new BoolMonitor("PrimaryIndexTrigger (Touch)",      () => OVRInput.Get(OVRInput.Touch.PrimaryIndexTrigger)),
			new BoolMonitor("PrimaryIndexTriggerDown (Touch)",  () => OVRInput.GetDown(OVRInput.Touch.PrimaryIndexTrigger)),
			new BoolMonitor("PrimaryIndexTriggerUp (Touch)",    () => OVRInput.GetUp(OVRInput.Touch.PrimaryIndexTrigger)),
            new BoolMonitor("PrimaryThumbstick (Touch)",        () => OVRInput.Get(OVRInput.Touch.PrimaryThumbstick)),
            new BoolMonitor("PrimaryThumbstickDown (Touch)",    () => OVRInput.GetDown(OVRInput.Touch.PrimaryThumbstick)),
            new BoolMonitor("PrimaryThumbstickUp (Touch)",      () => OVRInput.GetUp(OVRInput.Touch.PrimaryThumbstick)),
            new BoolMonitor("PrimaryThumbRest (Touch)",        () => OVRInput.Get(OVRInput.Touch.PrimaryThumbRest)),
            new BoolMonitor("PrimaryThumbRestDown (Touch)",    () => OVRInput.GetDown(OVRInput.Touch.PrimaryThumbRest)),
            new BoolMonitor("PrimaryThumbRestUp (Touch)",      () => OVRInput.GetUp(OVRInput.Touch.PrimaryThumbRest)),


            new BoolMonitor("SecondaryIndexTrigger",            () => OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger)),
            new BoolMonitor("SecondaryIndexTriggerDown",        () => OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)),
            new BoolMonitor("SecondaryIndexTriggerUp",          () => OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger)),
            new BoolMonitor("SecondaryHandTrigger",             () => OVRInput.Get(OVRInput.Button.SecondaryHandTrigger)),
            new BoolMonitor("SecondaryHandTriggerDown",         () => OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger)),
            new BoolMonitor("SecondaryHandTriggerUp",           () => OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger)),
            new BoolMonitor("SecondaryShoulder",                () => OVRInput.Get(OVRInput.Button.SecondaryShoulder)),
            new BoolMonitor("SecondaryShoulderDown",            () => OVRInput.GetDown(OVRInput.Button.SecondaryShoulder)),
            new BoolMonitor("SecondaryShoulderUp",              () => OVRInput.GetUp(OVRInput.Button.SecondaryShoulder)),
            new BoolMonitor("SecondaryThumbstick",              () => OVRInput.Get(OVRInput.Button.SecondaryThumbstick)),
            new BoolMonitor("SecondaryThumbstickDown",          () => OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick)),
            new BoolMonitor("SecondaryThumbstickUp",            () => OVRInput.GetUp(OVRInput.Button.SecondaryThumbstick)),
            new BoolMonitor("SecondaryThumbstick^",             () => OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp)),
            new BoolMonitor("SecondaryThumbstick^Down",         () => OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickUp)),
            new BoolMonitor("SecondaryThumbstick^Up",           () => OVRInput.GetUp(OVRInput.Button.SecondaryThumbstickUp)),
            new BoolMonitor("SecondaryThumbstick\\/",           () => OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown)),
            new BoolMonitor("SecondaryThumbstick\\/Down",       () => OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickDown)),
            new BoolMonitor("SecondaryThumbstick\\/Up",         () => OVRInput.GetUp(OVRInput.Button.SecondaryThumbstickDown)),
            new BoolMonitor("SecondaryThumbstick<",             () => OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft)),
            new BoolMonitor("SecondaryThumbstick<Down",         () => OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickLeft)),
            new BoolMonitor("SecondaryThumbstick<Up",           () => OVRInput.GetUp(OVRInput.Button.SecondaryThumbstickLeft)),
            new BoolMonitor("SecondaryThumbstick>",             () => OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight)),
            new BoolMonitor("SecondaryThumbstick>Down",         () => OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickRight)),
            new BoolMonitor("SecondaryThumbstick>Up",           () => OVRInput.GetUp(OVRInput.Button.SecondaryThumbstickRight)),

            new BoolMonitor("SecondaryIndexTrigger (Touch)",    () => OVRInput.Get(OVRInput.Touch.SecondaryIndexTrigger)),
            new BoolMonitor("SecondaryIndexTriggerDown (Touch)",() => OVRInput.GetDown(OVRInput.Touch.SecondaryIndexTrigger)),
            new BoolMonitor("SecondaryIndexTriggerUp (Touch)",  () => OVRInput.GetUp(OVRInput.Touch.SecondaryIndexTrigger)),
            new BoolMonitor("SecondaryThumbstick (Touch)",      () => OVRInput.Get(OVRInput.Touch.SecondaryThumbstick)),
            new BoolMonitor("SecondaryThumbstickDown (Touch)",  () => OVRInput.GetDown(OVRInput.Touch.SecondaryThumbstick)),
            new BoolMonitor("SecondaryThumbstickUp (Touch)",    () => OVRInput.GetUp(OVRInput.Touch.SecondaryThumbstick)),
            new BoolMonitor("SecondaryThumbRest (Touch)",        () => OVRInput.Get(OVRInput.Touch.SecondaryThumbRest)),
            new BoolMonitor("SecondaryThumbRestDown (Touch)",    () => OVRInput.GetDown(OVRInput.Touch.SecondaryThumbRest)),
            new BoolMonitor("SecondaryThumbRestUp (Touch)",      () => OVRInput.GetUp(OVRInput.Touch.SecondaryThumbRest)),


            new BoolMonitor("Touchpad (Click)",                 () => OVRInput.Get(OVRInput.Button.PrimaryTouchpad)),
			new BoolMonitor("TouchpadDown (Click)",             () => OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad)),
			new BoolMonitor("TouchpadUp (Click)",               () => OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad)),
			new BoolMonitor("Touchpad (Touch)",                 () => OVRInput.Get(OVRInput.Touch.PrimaryTouchpad)),
			new BoolMonitor("TouchpadDown (Touch)",             () => OVRInput.GetDown(OVRInput.Touch.PrimaryTouchpad)),
			new BoolMonitor("TouchpadUp (Touch)",               () => OVRInput.GetUp(OVRInput.Touch.PrimaryTouchpad)),
            new BoolMonitor("Touchpad (Click)",                 () => OVRInput.Get(OVRInput.Button.SecondaryTouchpad)),
            new BoolMonitor("TouchpadDown (Click)",             () => OVRInput.GetDown(OVRInput.Button.SecondaryTouchpad)),
            new BoolMonitor("TouchpadUp (Click)",               () => OVRInput.GetUp(OVRInput.Button.SecondaryTouchpad)),
            new BoolMonitor("Touchpad (Touch)",                 () => OVRInput.Get(OVRInput.Touch.SecondaryTouchpad)),
            new BoolMonitor("TouchpadDown (Touch)",             () => OVRInput.GetDown(OVRInput.Touch.SecondaryTouchpad)),
            new BoolMonitor("TouchpadUp (Touch)",               () => OVRInput.GetUp(OVRInput.Touch.SecondaryTouchpad)),


			// raw
			new BoolMonitor("Start",                            () => OVRInput.Get(OVRInput.RawButton.Start)),
			new BoolMonitor("StartDown",                        () => OVRInput.GetDown(OVRInput.RawButton.Start)),
			new BoolMonitor("StartUp",                          () => OVRInput.GetUp(OVRInput.RawButton.Start)),
			new BoolMonitor("Back",                             () => OVRInput.Get(OVRInput.RawButton.Back)),
			new BoolMonitor("BackDown",                         () => OVRInput.GetDown(OVRInput.RawButton.Back)),
			new BoolMonitor("BackUp",                           () => OVRInput.GetUp(OVRInput.RawButton.Back)),
			new BoolMonitor("A",                                () => OVRInput.Get(OVRInput.RawButton.A)),
			new BoolMonitor("ADown",                            () => OVRInput.GetDown(OVRInput.RawButton.A)),
			new BoolMonitor("AUp",                              () => OVRInput.GetUp(OVRInput.RawButton.A)),
		};
	}
	static string prevConnected = "";
	static BoolMonitor controllers = new BoolMonitor("Controllers Changed", () => { return OVRInput.GetConnectedControllers().ToString() != prevConnected; });

	void Update()
	{
		OVRInput.Controller activeController = OVRInput.GetActiveController();

		data.Length = 0;
		byte recenterCount = OVRInput.GetControllerRecenterCount();
		data.AppendFormat("RecenterCount: {0}\n", recenterCount);

		byte battery = OVRInput.GetControllerBatteryPercentRemaining();
		data.AppendFormat("Battery: {0}\n", battery);

		float framerate = OVRPlugin.GetAppFramerate();
		data.AppendFormat("Framerate: {0:F2}\n", framerate);

		string activeControllerName = activeController.ToString();
		data.AppendFormat("Active: {0}\n", activeControllerName);

		string connectedControllerNames = OVRInput.GetConnectedControllers().ToString();
		data.AppendFormat("Connected: {0}\n", connectedControllerNames);

		data.AppendFormat("PrevConnected: {0}\n", prevConnected);

		controllers.Update();
		controllers.AppendToStringBuilder(ref data);

		prevConnected = connectedControllerNames;

		Quaternion rot = OVRInput.GetLocalControllerRotation(activeController);
		data.AppendFormat("Orientation: ({0:F2}, {1:F2}, {2:F2}, {3:F2})\n", rot.x, rot.y, rot.z, rot.w);

		Vector3 angVel = OVRInput.GetLocalControllerAngularVelocity(activeController);
		data.AppendFormat("AngVel: ({0:F2}, {1:F2}, {2:F2})\n", angVel.x, angVel.y, angVel.z);

		Vector3 angAcc = OVRInput.GetLocalControllerAngularAcceleration(activeController);
		data.AppendFormat("AngAcc: ({0:F2}, {1:F2}, {2:F2})\n", angAcc.x, angAcc.y, angAcc.z);

		Vector3 pos = OVRInput.GetLocalControllerPosition(activeController);
		data.AppendFormat("Position: ({0:F2}, {1:F2}, {2:F2})\n", pos.x, pos.y, pos.z);

		Vector3 vel = OVRInput.GetLocalControllerVelocity(activeController);
		data.AppendFormat("Vel: ({0:F2}, {1:F2}, {2:F2})\n", vel.x, vel.y, vel.z);

		Vector3 acc = OVRInput.GetLocalControllerAcceleration(activeController);
		data.AppendFormat("Acc: ({0:F2}, {1:F2}, {2:F2})\n", acc.x, acc.y, acc.z);

		Vector2 primaryTouchpad = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
		data.AppendFormat("PrimaryTouchpad: ({0:F2}, {1:F2})\n", primaryTouchpad.x, primaryTouchpad.y);

		Vector2 secondaryTouchpad = OVRInput.Get(OVRInput.Axis2D.SecondaryTouchpad);
		data.AppendFormat("SecondaryTouchpad: ({0:F2}, {1:F2})\n", secondaryTouchpad.x, secondaryTouchpad.y);

        Vector2 primaryThumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        data.AppendFormat("PrimaryThumbstick: ({0:F2}, {1:F2})\n", primaryThumbstick.x, primaryThumbstick.y);

        Vector2 secondaryThumbstick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        data.AppendFormat("SecondaryThumbstick: ({0:F2}, {1:F2})\n", secondaryThumbstick.x, secondaryThumbstick.y);

        float primeIndexTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
		data.AppendFormat("PrimaryIndexTriggerAxis1D: ({0:F2})\n", primeIndexTrigger);

		float primeHandTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
		data.AppendFormat("PrimaryHandTriggerAxis1D: ({0:F2})\n", primeHandTrigger);

        float secondIndexTrigger = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        data.AppendFormat("SecondaryIndexTriggerAxis1D: ({0:F2})\n", secondIndexTrigger);

        float secondHandTrigger = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
        data.AppendFormat("SecondaryHandTriggerAxis1D: ({0:F2})\n", secondHandTrigger);

        for (int i = 0; i < monitors.Count; i++)
		{
			monitors[i].Update();
			monitors[i].AppendToStringBuilder(ref data);
		}

		if (uiText != null)
		{
			uiText.text = data.ToString();
		}
	}
}
