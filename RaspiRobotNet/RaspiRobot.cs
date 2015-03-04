using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaspberryGPIOManager;
using System.Threading;

namespace RaspiRobotNet
{
    public class RaspiRobot
    {
		const int LEFT_GO_PIN = 17;
		const int LEFT_DIR_PIN = 4;
		const int RIGHT_GO_PIN = 10;
		const int RIGHT_DIR_PIN = 25;
		const int SW1_PIN = 11;
		const int SW2_PIN = 9;
		const int LED1_PIN = 7;
		const int LED2_PIN = 8;
		const int OC1_PIN = 22;
		const int OC2_PIN = 21;

		public GPIOPinDriver LED1 { get; set; }
		public GPIOPinDriver LED2 { get; set; }
		public GPIOPinDriver OC1 { get; set; }
		public GPIOPinDriver OC2 { get; set; }
		public GPIOPinDriver LEFT_GO { get; set; }
		public GPIOPinDriver LEFT_DIR { get; set; }
		public GPIOPinDriver RIGHT_GO { get; set; }
		public GPIOPinDriver RIGHT_DIR { get; set; }

		public RaspiRobot()
		{
			this.LED1 = new GPIOPinDriver(GPIOPinDriver.Pin.GPIO7, GPIOPinDriver.GPIODirection.Out, GPIOPinDriver.GPIOState.Low);
			this.LED2 = new GPIOPinDriver(GPIOPinDriver.Pin.GPIO8, GPIOPinDriver.GPIODirection.Out, GPIOPinDriver.GPIOState.Low);
			this.OC1 = new GPIOPinDriver(GPIOPinDriver.Pin.GPIO22, GPIOPinDriver.GPIODirection.Out, GPIOPinDriver.GPIOState.Low);
			this.OC2 = new GPIOPinDriver(GPIOPinDriver.Pin.GPIO21, GPIOPinDriver.GPIODirection.Out, GPIOPinDriver.GPIOState.Low);
			this.LEFT_GO = new GPIOPinDriver(GPIOPinDriver.Pin.GPIO17, GPIOPinDriver.GPIODirection.Out, GPIOPinDriver.GPIOState.Low);
			this.LEFT_DIR = new GPIOPinDriver(GPIOPinDriver.Pin.GPIO4, GPIOPinDriver.GPIODirection.Out, GPIOPinDriver.GPIOState.Low);
			this.RIGHT_GO = new GPIOPinDriver(GPIOPinDriver.Pin.GPIO10, GPIOPinDriver.GPIODirection.Out, GPIOPinDriver.GPIOState.Low);
			this.RIGHT_DIR = new GPIOPinDriver(GPIOPinDriver.Pin.GPIO25, GPIOPinDriver.GPIODirection.Out, GPIOPinDriver.GPIOState.Low);
		}

		public void SetMotors( int left_go, int left_dir, int right_go, int right_dir )
		{
			this.SetMotors(left_go != 0, left_dir != 0, right_go != 0, right_dir != 0);
		}
		public void SetMotors( bool left_go, bool left_dir, bool right_go, bool right_dir )
		{
			this.LEFT_GO.State = left_go  ? GPIOPinDriver.GPIOState.High : GPIOPinDriver.GPIOState.Low;
			this.LEFT_DIR.State = left_dir ? GPIOPinDriver.GPIOState.High : GPIOPinDriver.GPIOState.Low;
			this.RIGHT_GO.State = right_go ? GPIOPinDriver.GPIOState.High : GPIOPinDriver.GPIOState.Low;
			this.RIGHT_DIR.State = right_dir ? GPIOPinDriver.GPIOState.High : GPIOPinDriver.GPIOState.Low;
		}

		public void Stop()
		{
			this.SetMotors(false, false, false, false);
		}
		public void Forward(float sec = 0.0f)
		{
			this.SetMotors(true, false, true, false);
			if (sec > 0.0f)
			{
				Thread.Sleep((int)(sec * 1000.0));
				this.Stop();
			}
		}
		public void Left(float sec = 0.0f)
		{
			this.SetMotors(true, false, true, true);
			if (sec > 0.0f)
			{
				Thread.Sleep((int)(sec * 1000.0));
				this.Stop();
			}
		}
		public void Right(float sec = 0.0f)
		{
			this.SetMotors(true, true, true, false);
			if (sec > 0.0f)
			{
				Thread.Sleep((int)(sec * 1000.0));
				this.Stop();
			}
		}
		public void Reverse(float sec = 0.0f)
		{
			this.SetMotors(true, true, true, true);
			if (sec > 0.0f)
			{
				Thread.Sleep((int)(sec * 1000.0));
				this.Stop();
			}
		}
		public void Back(float sec = 0.0f)
		{
			this.Reverse(sec);
		}

		public void SetLED1( bool sw ) {
			this.LED1.State = sw ? GPIOPinDriver.GPIOState.High : GPIOPinDriver.GPIOState.Low;
		}
		public void SetLED2(bool sw)
		{
			this.LED2.State = sw ? GPIOPinDriver.GPIOState.High : GPIOPinDriver.GPIOState.Low;
		}
		public void SetOC1(bool sw)
		{
			this.OC1.State = sw ? GPIOPinDriver.GPIOState.High : GPIOPinDriver.GPIOState.Low;
		}
		public void SetOC2(bool sw)
		{
			this.OC2.State = sw ? GPIOPinDriver.GPIOState.High : GPIOPinDriver.GPIOState.Low;
		}
	}
}
