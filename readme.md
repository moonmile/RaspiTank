# Raspberry Pi ���

- Raspberry Pi 2
- PS3 Dualshock3 �R���g���[���[
- Raspberry Pi�p���[�^�[�h���C�o�{�[�h

�𗘗p���āARPi2 �Ő�Ԃ𓮂����܂��B

�v���O��������� C#/F# �𗘗p���Ă��܂��B

# �g����

Raspberry pi �� mono/fsharp ���C���X�g�[�����ė��p���܂��B
- [Raspberry Pi 2 �� F# ���C���X�g�[������](http://www.moonmile.net/blog/archives/6870 "Raspberry Pi 2 �� F# ���C���X�g�[������ | Moonmile Solutions Blog")

Windows ��� RaspiRobotNet ���r���h������A���s�t�@�C������ RPi �ɃR�s�[���܂��B

```
git clone https://github.com/moonmile/RaspiTank
cd RaspiTank/RaspiRobot
xbuild
```
RaspiTank/RaspiRobot/bin/Debug/RaspiRobot.exe �����s�t�@�C���ł��B

- ���� Windows ��Ńr���h���� *.exe/dll �� Raspberry Pi �ɃR�s�[���������ł����s�ł��܂��B


# ���s�̎d��

PS3 Dualshock3 �� Bluetooth ����M������
```
sixad -start &
```

�v���O������ /etc/input/js0 ���A�N�Z�X�����邽�� sudo �Ŏ��s���܂��B
```
sudo bin/Debug/RaspiRobot.exe
```

# �Q�Ɛ�

- [Raspberry Pi �Ő�Ԃ����i�ޗ��ҁj](http://www.moonmile.net/blog/archives/6888 "Raspberry Pi �Ő�Ԃ����i�ޗ��ҁj | Moonmile Solutions Blog")
- [Raspberry Pi �Ő�Ԃ����iBluetooth/PS3 Dualshock3�ҁj](http://www.moonmile.net/blog/archives/6898 "Raspberry Pi �Ő�Ԃ����iBluetooth/PS3 Dualshock3�ҁj | Moonmile Solutions Blog")
- [Raspberry Pi �Ő�Ԃ����i���[�^�[�V�[���h�ҁj](http://www.moonmile.net/blog/archives/6910 "Raspberry Pi �Ő�Ԃ����i���[�^�[�V�[���h�ҁj | Moonmile Solutions Blog")
