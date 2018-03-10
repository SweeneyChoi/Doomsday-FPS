# 基于Unity3D的末日题材FPS手机游戏的设计与实现

## 关键词：Unity3D；Android；FPS； 

### 一、开发环境
- Unity 2017.2.1f1 (64-bit)
- JDK 1.8.0

### 二、游戏设计

#### 1.游戏背景
一场病毒肆虐过后，昔日的小镇被恐怖笼罩，镇上居民感染病毒变成了丧尸，唯一幸存下来的你却发现小镇紧闭，无法逃离这座丧尸城，恐惧、绝望……不断侵蚀、动摇着你的意志，现在的你要克服内心的恐惧，找遍整座小镇，找出逃离的线索，虽然一扇扇门背后，很可能是疯狂向你扑过来的丧尸，但也许线索，就藏在这些危险的角落，唯有集齐所有线索，才有可能逃出生天……

#### 2.游戏策划
**玩家控制：** 玩家通过屏幕上的Joystick遥感控制角色的行走，通过触摸屏控制视角方向，通过屏幕中央的准心瞄准丧尸射击，点击屏幕上的换枪按钮实现换枪操作，点击屏幕上的手电筒按钮开启手电筒。

**游戏玩法：** 一开始玩家处于一座充满丧尸的封闭小镇中无法出去，玩家必须克服内心的恐惧，在丧尸随时出没的小镇里找齐所有线索破坏小镇大门，逃离小镇。

**游戏胜利与失败：** 玩家集齐线索摧毁小镇大门后，逃出小镇，游戏胜利，若被丧尸攻击至血量减为0，则玩家死亡。最后，游戏通过玩家胜利与否以及击杀或物品收集得分为玩家排名，显示积分榜。

**物品收集：**

1.血瓶:增加玩家HP；![血瓶](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/blood.png)

2.线索:增加玩家得分，玩家需集齐所有线索以逃出小镇。![线索](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/key.png)

**玩家得分：** 每个血瓶增加10点HP；每条线索得2分；每击杀一个丧尸得5分。

#### 3.UI界面设计

**游戏开始界面**

![开始界面1](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/start1.png)

该场景包含一下几个元素：
1.标题：Doomsday，通过字体的加粗、放大、倾斜以及颜色设置为红色，显示在屏幕顶部的中央。
2.游戏面板：位于右边的蓝色透明面板，面板中包含开始、选项、退出三个游戏按钮。
3.左下角的TextField：标名了作者信息。
4.背景面板：位于所有元素最里面的背景图片

**点击开始按钮，游戏面板切换到开始游戏面板**

![开始界面2](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/start2.png)

在这个面板中，使用了Text控件，制作玩家名称标签，在标签下面使用InputField控件，制作了一个文本框，用于输入玩家的姓名。在面板下方，使用Button控件制作开始按钮，用于开始游戏，以及返回按钮，用于返回初始面板。

**点击选项按钮，游戏切换到游戏选项面板**

![开始界面3](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/start3.png)

在这个面板中，使用Text控件制作声音开关标签，在标签后面使用Toggle控件，制作了一个开关，用于切换游戏声音的开启与关闭。在面板下方，使用Button控件，制作返回按钮。

**游戏运行界面**

![游戏运行界面](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/runUI.png)

本面板包含以下几个元素：
1.屏幕中央射击准星Sightbead
2.左下角用Slider控件实现的玩家生命值血条
3.右上角用Text控件实现的TimeText和ScoreText,表示玩家战斗时间和得分
4.左侧使用Image控件实现Joystick遥感，右侧使用Image控件实现玩家射击、跳跃、换枪、打开手电的按钮

**游戏结束界面**

![游戏结束界面](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/endUI.png)

游戏结束界面显示游戏的排行榜，游戏结束界面包含开始新战斗和返回主菜单两个按钮，游戏排行榜背景使用多个颜色不同、 透明度不同的 Image 控件堆叠实现 游戏排行榜内容使用 Text 控件实现，开始新战斗与返回主界面按钮使用 Button 控件实现

#### 4.游戏场景设计

![场景](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/scene.png)

本游戏场景设计为一座充满丧尸的封闭小镇，玩家在收集完所有线索后才能摧毁小镇大门，逃离小镇。
场景由Unity3D地形系统配合网上下载的资源自行搭建。

#### 5.游戏特效设计

1.枪口火焰特效，不同的枪具有不同的火焰效果：
![火焰特效1](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/effect1.png)
![火焰特效2](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/effect2.png)

2.子弹特效：
![子弹特效](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/effect3.png)

3.玩家受伤血晕特效：
![血晕效果](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/effect4.png)

4.丧尸狂暴特效，丧尸发现玩家后变狂暴，周身泛着血红，使用shader实现：
![丧尸狂暴特效](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/effect5.png)

5.车辆燃烧特效：
![车辆燃烧特效](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/effect6.png)

### 三、游戏实现

**1.鼠标观察**
（1）使用枚举类型用于选择水平或垂直旋转：

```
public class MouseLook : MonoBehaviour {
	public enum RotationAxes {
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}
```

（2）水平旋转：将旋转速度乘以轴向的值，旋转将响应鼠标的移动：

```
if (axes == RotationAxes.MouseX) {
	transform.Rotate(0, CrossPlatformInputManager.GetAxis("Mouse X") * sensitivityHor, 0);
		}
```

（3）垂直旋转：不能使用Rotate()函数，应该通过创建新的Vector3向量来设置新的localEulerAngles:

```
else if (axes == RotationAxes.MouseY) {
			_rotationX -= CrossPlatformInputManager.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
			
			transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y, 0);
		}
```

**2.玩家移动：**

使用CharacterController组件来应用碰撞检测，并使用Move(movement)通过movement向量移动：

```
float deltaX = CrossPlatformInputManager.GetAxis ("Horizontal") * moveSpeed;
float deltaZ = CrossPlatformInputManager.GetAxis ("Vertical") * moveSpeed;

Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
movement = Vector3.ClampMagnitude (movement, moveSpeed);

movement *= Time.deltaTime;
movement = transform.TransformDirection (movement);
_charController.Move (movement);
```

为玩家施加重力，以调整为走路而不是飞翔：需要声明一个中立变量并把这个重力变量赋值给Y轴：

```
public float gravity = -9.8f;
movement.y = _vertSpeed;
```

最后，为了保持重力永远竖直向下，我们需要设置玩家身上的MouseLook仅仅为水平旋转，接着给camera对象添加一个MouseLook组件，并设置它为垂直旋转。因为camera的父对象是玩家对象，所以尽管它独立于玩家垂直旋转，但摄像机还是会跟着玩家做水平旋转。

**3.玩家跳跃**

使用射线投射检测玩家是否在地面上，如果判断为true，那么垂直速度的值重置为0，如果单击跳跃按钮，给玩家应用一个垂直方向的速度。由公式v=-gt,可知，垂直速度应该不断被重力减弱，最后反向，转而开始下降，跳跃就出现一条自然的弧线。

使用射线投射检测地面引入了一个需要处理的新情况：光线投射没有检测角色下方的地面，但角色控制器正与地面碰撞。在这种情况下，代码应该让角色从边缘滑落，角色仍然会降落（因为它没有站立在地面上），但它也会从碰撞点推离（因为它需要从碰撞的站台一开胶囊）。那么，代码将用角色控制器来检测碰撞并通过将角色推离碰撞点来响应碰撞。

```
        bool hitGround = false;
		RaycastHit hit;
		if (_vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit)) {
			float check = (_charController.height + _charController.radius) / 1.9f;
			hitGround = hit.distance <= check;	
			if (hitGround == false && anim != null)
				anim.SetBool ("isJump", false);
		}
				
		if (hitGround) {
				if (CrossPlatformInputManager.GetButtonDown("Jump")) {
				_vertSpeed = jumpSpeed;
					if (anim != null)
						anim.SetBool ("isJump", true);
			} else {
				_vertSpeed = minFall;
					if(anim != null)
						anim.SetBool ("isJump", false);
			}
		} else {
			_vertSpeed += gravity * 5 * Time.deltaTime;
			if (_vertSpeed < terminalVelocity) {
				_vertSpeed = terminalVelocity;
			}
			if (_contact != null ) {	
			}
					
			if (_charController.isGrounded) {
				if (Vector3.Dot(movement, _contact.normal) < 0) {
					movement = _contact.normal * moveSpeed;
				} else {
					movement += _contact.normal * moveSpeed;
				}
			}
		}
```





