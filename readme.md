# Raspberry Pi 戦車

- Raspberry Pi 2
- PS3 Dualshock3 コントローラー
- Raspberry Pi用モータードライバボード

を利用して、RPi2 で戦車を動かします。

プログラム言語は C#/F# を利用しています。

# 使い方

Raspberry pi に mono/fsharp をインストールして利用します。
- [Raspberry Pi 2 に F# をインストールする](http://www.moonmile.net/blog/archives/6870 "Raspberry Pi 2 に F# をインストールする | Moonmile Solutions Blog")

Windows 上で RaspiRobotNet をビルドした後、実行ファイル等を RPi にコピーします。

```
git clone https://github.com/moonmile/RaspiTank
cd RaspiTank/RaspiRobot
xbuild
```
RaspiTank/RaspiRobot/bin/Debug/RaspiRobot.exe が実行ファイルです。

- 実は Windows 上でビルドした *.exe/dll を Raspberry Pi にコピーしただけでも実行できます。


# 実行の仕方

PS3 Dualshock3 の Bluetooth を受信させる
```
sixad -start &
```

プログラムは /etc/input/js0 をアクセスさせるため sudo で実行します。
```
sudo bin/Debug/RaspiRobot.exe
```

# 参照先

- [Raspberry Pi で戦車を作る（材料編）](http://www.moonmile.net/blog/archives/6888 "Raspberry Pi で戦車を作る（材料編） | Moonmile Solutions Blog")
- [Raspberry Pi で戦車を作る（Bluetooth/PS3 Dualshock3編）](http://www.moonmile.net/blog/archives/6898 "Raspberry Pi で戦車を作る（Bluetooth/PS3 Dualshock3編） | Moonmile Solutions Blog")
- [Raspberry Pi で戦車を作る（モーターシールド編）](http://www.moonmile.net/blog/archives/6910 "Raspberry Pi で戦車を作る（モーターシールド編） | Moonmile Solutions Blog")
