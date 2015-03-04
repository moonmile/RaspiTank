using Moonmile.BrickPiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspiRobotSample
{
	class Program
	{
		static void Main(string[] args)
		{
			new Program().main();
		}

		BPiJoystick js;
		RaspiRobotNet.RaspiRobot robot;
		
		public void main()
		{
			robot = new RaspiRobotNet.RaspiRobot();

			js = new BPiJoystick();
			js.OnChangedJoystick += js_OnChangedJoystick;
			js.OnChangedButton += js_OnChangedButton;
			js.Setup();
			Console.WriteLine("any key is stop.");
			var key = Console.ReadKey();

		}

		/// <summary>
		/// ボタンが変更された
		/// </summary>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		void js_OnChangedButton(object sender, JoystickEventArgs e)
		{
			if (e.Joystick.Up == true) robot.Forward();
			else if (e.Joystick.Down == true) robot.Back();
			else if (e.Joystick.Left == true) robot.Left();
			else if (e.Joystick.Right == true) robot.Right();
			else
			{
				if (e.Joystick.Up == false && e.Joystick.Down == false &&
					e.Joystick.Left == false && e.Joystick.Right == false)
					robot.Stop();
			}

			/// LED1,2 を点灯する
			robot.SetLED1( e.Joystick.Circle );
			robot.SetLED2( e.Joystick.Cross );
		}
		/// <summary>
		/// ジョイスティックを変更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void js_OnChangedJoystick(object sender, JoystickEventArgs e)
		{
			int ly = e.Joystick.LeftAxisY;
			int ry = e.Joystick.RightAxisY;
			Console.WriteLine("joystick {0} {1}", ly, ry);
			int sp1 = ly / (32767 / 200);
			int sp2 = ry / (32767 / 200);
			if (e.Joystick.Up == false && e.Joystick.Down == false &&
				e.Joystick.Left == false && e.Joystick.Right == false)
			{
				move_bot(sp1, sp2);
			}
		}
		void move_bot(int sp1, int sp2)
		{
			if (sp1 > 0 && sp2 > 0) { robot.Forward(); }
			if (sp1 < 0 && sp2 > 0) { robot.Right(); }
			if (sp1 > 0 && sp2 < 0) { robot.Left(); }
			if (sp1 < 0 && sp2 < 0) { robot.Reverse(); }
			// 停止
			if (sp1 == 0 && sp2 == 0) { 
				robot.Stop(); 
			}
			// 右だけ動かす
			if (sp1 == 0)
			{
				if ( sp2 > 0 )
					robot.SetMotors(false, false, true, false);
				if (sp2 < 0)
					robot.SetMotors(false, false, true, true);
			}
			// 左だけ動かす
			if (sp2 == 0)
			{
				if (sp1 > 0)
					robot.SetMotors(true, false, false, false);
				if (sp1 < 0)
					robot.SetMotors(true, true, false, false);
			}
		}
	}
}
