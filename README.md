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

**4.玩家射击**

玩家射击需要满足两个条件，玩家必须按下射击键 ， 使用 CrossPlatformInputManager 类的 GetKeyDown 函数来检测玩家是否按下射击键，检查本次攻击与上次攻击的时间间隔，该时间间隔需要大于预定的攻击时间间隔，使用 Time 类的 DeltaTime 属性进行时间累加，计算两次攻击的时间间隔，射击条件满足后，脚本执行射击逻辑，包括准星射击，射击动作枪口射线以及射击音效四个部分。 准星射击，实现对敌人的攻击，使用 Physics 类的 RayCast 函数，从枪口发出来一条射线，检测射线是否接触到敌人，执行敌人扣血等相关动作。
![射击逻辑](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/shejiluoji.png)

```
if (Physics.Raycast (ray, out hitInfo, shootingRange)) {
			if (hitInfo.transform.gameObject.tag.Equals ("Enemy")) {	
				ZombieHealth enemyHealth = hitInfo.transform.gameObject.GetComponent<ZombieHealth> ();
				if (enemyHealth != null) {
					enemyHealth.TakeDamage (shootingDamage, myCamera.transform.position);
				}
			}
```

**5.玩家生命值管理**

startHealth表示初始生命值，currentHealth表示当前生命值，定义 isAlive 字段表示玩家是否存活。在 Update 函数中检测玩家是否存活 在 TakeDamage 函数中实现玩家扣血逻辑，在AddHealth函数中实现玩家加血逻辑。
扣血函数：

```
//扣血函数
	public void TakeDamage(int damage){
		currentHealth -= damage;
		if (currentHealth < 0)
			currentHealth = 0;

		//如果玩家死亡
		if (currentHealth == 0) {
			if (anim != null) {
				anim.SetBool ("isDead", true);
				//允许动画控制器，控制玩家的运动
				anim.applyRootMotion = true;
			}

			//禁用IK
			if (userIKController != null) {
				userIKController.enabled = false;
			}

			//禁用玩家所有的枪械
			if (playerWeaponSwitcher != null) {
				foreach (Transform trans in playerWeaponSwitcher.weaponList) {
					trans.gameObject.SetActive (false);
				}
			} else if(gun!=null) {
				gun.SetActive (false);
			}
		}
	}
```

加血函数：
```
//加血函数
	public void AddHealth(int value){
		currentHealth += value;
		if (currentHealth > startHealth)	
			currentHealth = startHealth;
	}
```

**6.玩家换枪**

逆向动力学（IK）：给定末端节点的位置，通过逆向计算得到节点链上所有其他节点的合理位置的方法，称为逆向动力学，Inverse Kinenatic， 简称 IK。
通过逆向动力学，可以做出玩家持枪动作。

换枪功能：不同的枪械具有不同的：外观、射击速度、攻击距离、伤害……可以增加游戏的趣味性。

实现步骤：

1.为玩家对象添加新的枪械模型；

2.为新的枪械模型设置正确的角色模型 IK；

3.为新的枪械模型添加攻击脚本，设置攻击力、 攻击距离、 攻击速度和攻击音效等属性；

4.为玩家添加换枪脚本，换枪脚本的武器列表用来记录玩家所有的枪械对象。


```
public void changeNextWeapon()
	{

		if (weaponNum <= 1) 
			return;


		int newIdx = (currentIdx + 1) % weaponNum;


		Transform newWeapon = weaponList [newIdx];
		Transform rightHand = newWeapon.Find ("RightHandObj");
		Transform leftHand  = newWeapon.Find ("LeftHandObj");
		Transform gunBarrelEnd = newWeapon.Find ("GunBarrelEnd");
		ikController.leftHandObj = leftHand;
		ikController.rightHandObj = rightHand;
		ikController.lookObj = gunBarrelEnd;


		newWeapon.gameObject.SetActive (true);
		weaponList [currentIdx].gameObject.SetActive (false);


		currentIdx = newIdx;
	}
```

**7.光照系统与开启、关闭手电筒**

光源类型和属性：

点光源（Point Light）：点光源从光源位置向所有方向发射出强度相等的光线，光的强度在传输过程中不断衰减，当传输距离达到我们预先为它设定的极限距离时，强度衰减为 0，点光源适合用来模拟灯笼、 火把等局部光照。

![点光源1](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/pointLight1.png)
![点光源2](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/pointLight2.png)

方向光（Directional Light）：方向光不会衰减，它以相同的强度和方向照亮空间中的所有物体。方向光的位置没有任何意义。我们将方向光对象放置场景中任何位置，方向光通常用来模拟那些体积较大，距离游戏场景非常远的光源，比如日光和月光。

![方向光1](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/directionLight1.png)
![方向光2](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/directionLight2.png)

聚光灯（Spot Light）：聚光灯从光源位置开始向某个特定的方向照射，照射一个圆锥的空间区域，在传播过程中不断衰减，聚光灯通常适用模拟人造光源，比如手电、 车灯、 探照灯。

![聚光灯1](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/SpotLight1.png)
![聚光灯2](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/SpotLight2.png)

面光源（Area Light）：面光源使用一个矩形来定义，光线从矩形的正面出发，照亮矩形前面的一片区域。面光源可以从多个方向照亮一个物体，能产生更加柔和的照明效果，通常用于模拟广告灯箱，或者靠近玩家的一组灯光。面光源需要大量的计算资源，无法作为实时光源使用。

![面光源](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/areaLight.png)

使用Spot Light模拟FPS游戏中的手电筒效果：

![手电筒](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/flashLight.png)

实现代码：

```
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class FlashLightController : MonoBehaviour {

	private Light mylight;

	void Start () {
		mylight = GetComponent<Light> ();
	}	

	void Update () {
		if (CrossPlatformInputManager.GetButtonDown ("Fire3")) {
			if (mylight.intensity < 0.1)
				mylight.intensity = 5f;
			else
				mylight.intensity = 0.0f;
		}
			
	}
}

```

**8.导航系统**

Nav Mesh导航网格：

Nav Mesh导航网格是3D游戏中用于实现动态物体自动寻路的技术。

它将游戏场景中复杂的对象结构组织，简化为带有一定信息的网格，在这些网格的基础上，通过一系列计算，实现自动寻路。

Unity 引擎中，Nav Mesh Agent 是配合导航网格使用的导航代理组件，给物体添加导航代理组件后，物体会根据目标位置和导航网格通过搜索算法寻找合适的路线，沿着找到的路线移动到目标位置。

![导航系统](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/daohangxitong.png)

该图中的蓝色路径代表烘焙好的导航网格，丧尸可以通过代码，沿着这些路径进行移动、搜索玩家。

**9.丧尸AI**

智能丧尸：

能够根据自身情况，比如当前生命值、中枪与否和外部条件，比如僵尸周围是否有玩家采取合理的行动。

![丧尸](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/sangshi1.png)

AI基础：

- 基本行为操控：靠近，远离，追逐，逃避……
- 寻路能力：从游戏场景中的一个位置移动到另一个位置；
- 感知能力：自身状态，听觉和视觉等感知能力；
- 自主决策能力：根据自身状态和外部环境条件，做出合理的反应。

实现寻路能力：

通过Navigation导航系统实现搜索算法，使丧尸具有寻路能力。

模拟丧尸的听觉和视觉的方法：

1.触发器（Trigger）;
2.向量计算(Vector)

其中，向量计算的效率更高。

实现丧尸自主决策能力：
- 丧尸的感知范围内没有玩家->丧尸随机游荡；
- 丧尸受到攻击->丧尸向玩家开枪时所在的方向进行搜索；
- 丧尸感知到玩家->丧尸追踪玩家；
- 玩家进入丧尸攻击范围->丧尸攻击玩家；
- 玩家死亡脱离丧尸感知范围->丧尸回到随机游荡状态；
- 丧尸生命值变为0->丧尸进入死亡状态。

高级丧尸状态机：

![丧尸状态机](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/gaojisangshiluoji.png)

实现丧尸的感知能力：
- 外部世界：视觉、听觉；
- 自身情况：生命值、是否中枪。

实现方式：

1．使用触发器Trigger进行感知：OnTriggerEnter,OnTriggerExit和OnTriggerStay分别会在其他对象进入，离开和停留与触发器范围时被调用。适合用于低阶丧尸的感知能力。
缺点：
- 需要使用三维建模软件，制作出椎体网格来模拟视区域。这种方式较为麻烦，且不易维护。
- 物理计算，尤其是MeshCollider网格碰撞体的碰撞计算，开销较大，会降低游戏性能。

2．使用向量计算：
- 听觉的模拟：

丧尸的听觉范围可以视为一个球体，该球体的中心是丧尸所在的位置，只要玩家位于该球体内部，我们就认为丧尸可以感知到玩家。

![听觉](https://github.com/SweeneyChoi/Doomsday-FPS/blob/master/Image/tingjue.png)

- 视觉的模拟：

丧尸的视觉范围使用丧尸眼睛正前方的一个圆锥体来模拟，只要玩家位于这个圆锥体内部，且不被遮挡，我们就认为丧尸看到了玩家。

具体算法如下：

1.使用 Vector3 的 Distance 函数，计算丧尸与玩家之间的距离。 如果该距离小于丧尸的视觉距离，进入下一步的判断；

2.计算出丧尸所在的位置到玩家所在位置的向量 direction 然后使用 Vector3 的 Angle 方法，计算 direction 向量与丧尸的 forward 向量之间的夹角，如果该夹角小于丧尸视觉圆锥体张角的一半，就说明玩家位于丧尸的视觉圆锥体之内，进入下一步判断；

3.使用 Raycast 方法，从丧尸位置向玩家位置发射一条射线 如果该射线没有被其他物体遮挡，直接到达玩家所在的位置，说明丧尸可以看到玩家

生命值感知和中枪感知：

currentHP 把丧尸中枪时玩家所在的方向保存在 damageDirection 字段中，其它脚本读取 ZombieHealth 的 currentHP 和damageDirection 字段，可以获得丧尸的生命值和中枪情况。













