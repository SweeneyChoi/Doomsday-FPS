# 基于Unity3D的末日题材FPS手机游戏的设计与实现

## 关键词：Unity3D；Android；FPS； 

### 一、开发环境
- Unity 2017.2.1f1 (64-bit)
- JDK 1.8.0

### 二、游戏设计

#### 1.游戏背景
一场病毒肆虐过后，昔日的小镇被恐怖笼罩，镇上居民感染病毒变成了丧尸，唯一幸存下来的你却发现小镇紧闭，无法逃离这座丧尸城，恐惧、绝望……不断侵蚀、动摇着你的意志，现在的你要克服内心的恐惧，找遍整座小镇，找出逃离的线索，虽然一扇扇门背后，很可能是疯狂向你扑过来的丧尸，但也许线索，就藏在这些危险的角落，唯有集齐所有线索，才有可能逃出生天……

#### 2.游戏策划
**玩家控制：**玩家通过屏幕上的Joystick遥感控制角色的行走，通过触摸屏控制视角方向，通过屏幕中央的准心瞄准丧尸射击，点击屏幕上的换枪按钮实现换枪操作，点击屏幕上的手电筒按钮开启手电筒。

**游戏玩法：**一开始玩家处于一座充满丧尸的封闭小镇中无法出去，玩家必须克服内心的恐惧，在丧尸随时出没的小镇里找齐所有线索破坏小镇大门，逃离小镇。

**游戏胜利与失败：**玩家集齐线索摧毁小镇大门后，逃出小镇，游戏胜利，若被丧尸攻击至血量减为0，则玩家死亡。最后，游戏通过玩家胜利与否以及击杀或物品收集得分为玩家排名，显示积分榜。

**物品收集：**
1.血瓶:增加玩家HP；![血瓶](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/blood.png)

2.线索:增加玩家得分，玩家需集齐所有线索以逃出小镇。![线索](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/key.png)

**玩家得分：**每个血瓶增加10点HP；每条线索得2分；每击杀一个丧尸得5分。

