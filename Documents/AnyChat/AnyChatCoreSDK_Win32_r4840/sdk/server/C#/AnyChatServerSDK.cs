using System;
using System.Text;
using System.Runtime.InteropServices;

namespace ANYCHATAPI
{
 /***********************************************************************************
    * ** AnyChat Platform Server SDK
    * *********************************************************************************/
    public class AnyChatServerSDK
    {
        public const string AnyChatServerSDKDll = "AnyChatServerSDK.dll";

        //#define BRAS_SERVERAPPMSG_CONNECTED		1		///< 连接AnyChat服务器成功
		public const int BRAS_SERVERAPPMSG_CONNECTED 	= 1;
        //#define BRAS_SERVERAPPMSG_DISCONNECT		2		///< 与AnyChat服务器断开连接
		public const int BRAS_SERVERAPPMSG_DISCONNECT 	= 2;
		
		// 服务器消息类型定义（回调事件：BRAS_OnServerAppMessageEx_CallBack 参数）
		// #define BRAS_MESSAGE_CORESERVERCONN		10		///< 与核心服务器的连接消息，wParam为errorcode
		public const int BRAS_MESSAGE_CORESERVERCONN	= 10;
		// #define BRAS_MESSAGE_RECORDSERVERCONN	11		///< 与录像服务器的连接消息，wParam为errorcode，lParam为recordserverid
		public const int BRAS_MESSAGE_RECORDSERVERCONN	= 11;
		// #define BRAS_MESSAGE_LOGINSERVERCONN		12		///< 与登录服务器的连接消息，wParam为errorcode，lParam为loginserverid
		public const int BRAS_MESSAGE_LOGINSERVERCONN	= 12;
		// #define BRAS_MESSAGE_ROOMSERVERCONN		13		///< 与房间服务器的连接消息，wParam为errorcode，lParam为roomserverid
		public const int BRAS_MESSAGE_ROOMSERVERCONN	= 13;
		// #define BRAS_MESSAGE_MEDIASERVERCONN		14		///< 与流媒体服务器的连接消息，wParam为errorcode，lParam为mediaserverid
		public const int BRAS_MESSAGE_MEDIASERVERCONN	= 14;
		
		// 视频呼叫事件类型定义（API：BRAS_VideoCallControl 传入参数、OnVideoCallEvent回调参数）
		//#define BRAS_VIDEOCALL_EVENT_REQUEST    1        ///< 呼叫请求
		public const int BRAS_VIDEOCALL_EVENT_REQUEST 	= 1;
		//#define BRAS_VIDEOCALL_EVENT_REPLY      2        ///< 呼叫请求回复
		public const int BRAS_VIDEOCALL_EVENT_REPLY 	= 2;
		//#define BRAS_VIDEOCALL_EVENT_START      3        ///< 视频呼叫会话开始事件
		public const int BRAS_VIDEOCALL_EVENT_START 	= 3;
		//#define BRAS_VIDEOCALL_EVENT_FINISH     4        ///< 挂断（结束）呼叫会话
		public const int BRAS_VIDEOCALL_EVENT_FINISH 	= 4;
		
        // 用户信息控制类型定义（API：BRAS_UserInfoControl 传入参数、OnUserInfoControl回调参数）
        //#define BRAS_USERINFO_CTRLCODE_KICKOUT		1	///< 将指定用户从系统中踢掉
        public const int BRAS_USERINFO_CTRLCODE_KICKOUT =   1;
        //#define BRAS_USERINFO_CTRLCODE_SYNCDATA		2	///< 将指定用户的数据同步给客户端
        public const int BRAS_USERINFO_CTRLCODE_SYNCDATA=	2;
        //#define BRAS_USERINFO_CTRLCODE_BLOCKIP		4	///< 阻止IP地址连接服务器，lpStrValue为IP地址字符串，支持通配符“*”
        public const int BRAS_USERINFO_CTRLCODE_BLOCKIP	=	4;
        //#define BRAS_USERINFO_CTRLCODE_UNBLOCKIP	    5	///< 允许IP地址连接服务器，lpStrValue为IP地址字符串，支持通配符“*”
        public const int BRAS_USERINFO_CTRLCODE_UNBLOCKIP=  5;
        //#define BRAS_USERINFO_CTRLCODE_ADDGROUP		20	///< 添加用户分组，wParam为分组Id，lpStrValue为分组名称
        public const int BRAS_USERINFO_CTRLCODE_ADDGROUP=   20;
        //#define BRAS_USERINFO_CTRLCODE_DELGROUP		21	///< 删除用户分组，wParam为分组Id
        public const int BRAS_USERINFO_CTRLCODE_DELGROUP=   21;
        //#define BRAS_USERINFO_CTRLCODE_ADDFRIEND	    22	///< 添加用户好友，wParam为好友Id
        public const int BRAS_USERINFO_CTRLCODE_ADDFRIEND=  22;
        //#define BRAS_USERINFO_CTRLCODE_DELFRIEND	    23	///< 删除用户好友，wParam为好友Id
        public const int BRAS_USERINFO_CTRLCODE_DELFRIEND=  23;
        //#define BRAS_USERINFO_CTRLCODE_SETGROUPRELATION	24	///< 设置好友与分组的关联关系，wParam为分组Id，lParam为好友Id，表示好友属于某个分组
        public const int BRAS_USERINFO_CTRLCODE_SETGROUPRELATION=   24;
        //#define BRAS_USERINFO_CTRLCODE_APPDEFINE	    100	///< 应用层自定义起始指令
        public const int BRAS_USERINFO_CTRLCODE_APPDEFINE = 100;

		// 内核参数设置常量定义（API：BRAS_SetSDKOption 传入参数）
		public const int BRAS_SO_RECORD_VIDEOBR			= 2;	// 录像视频码率设置（参数为：int型，单位：bps）
		public const int BRAS_SO_RECORD_AUDIOBR			= 3;	// 录像音频码率设置（参数为：int型，单位：bps）
		public const int BRAS_SO_RECORD_FILETYPE		= 4;	// 录制文件类型设置（参数为：int型， 0 MP4[默认], 1 WMV, 2 FLV, 3 MP3）
		public const int BRAS_SO_RECORD_WIDTH			= 5;	// 录制视频宽度设置（参数为：int型，如：320）
		public const int BRAS_SO_RECORD_HEIGHT			= 6;	// 录制文件高度设置（参数为：int型，如：240）
		public const int BRAS_SO_RECORD_FILENAMERULE	= 7;	// 录制文件名命名规则（参数为：int型）
		public const int BRAS_SO_RECORD_CLIPMODE		= 8;	// 录制视频裁剪模式（参数为：int型）
		public const int BRAS_SO_CORESDK_WRITELOG		= 20;	// 写入调试信息到日志文件中

		// 初始化标志（API：BRAS_InitSDK 传入参数）
		public const int BRAS_INITFLAGS_MULTITHREADS	= 1;	//多线程模式

        // 回调函数类型定义（API：BRAS_SetCallBack 传入参数）
        public const int BRAS_CBTYPE_APPMESSAGE			= 1;	// 服务器应用程序消息回调
        public const int BRAS_CBTYPE_APPMESSAGEEX		= 2;	// 服务器应用程序消息（扩展）回调
        public const int BRAS_CBTYPE_ONTIMER			= 3;	// SDK定时器回调
        public const int BRAS_CBTYPE_VERIFYUSER			= 4;	// 用户身份验证回调
        public const int BRAS_CBTYPE_PERPAREENTERROOM	= 5;	// 用户申请进入房间回调
        public const int BRAS_CBTYPE_USERLOGIN			= 6;	// 用户登录成功回调
        public const int BRAS_CBTYPE_USERLOGOUT			= 7;	// 用户注销回调
        public const int BRAS_CBTYPE_USERLOGOUTEX		= 8;	// 用户注销（扩展）回调
        public const int BRAS_CBTYPE_USERENTERROOM		= 9;	// 用户进入房间回调
        public const int BRAS_CBTYPE_USERLEAVEROOM		= 10;	// 用户离开房间回调
        public const int BRAS_CBTYPE_FILTERDATA			= 11;	// 上层业务自定义数据回调
        public const int BRAS_CBTYPE_TEXTMESSAGE		= 12;	// 文字聊天通信数据回调
        public const int BRAS_CBTYPE_TRANSBUFFER		= 13;	// 透明通道数据回调
        public const int BRAS_CBTYPE_TRANSBUFFEREX		= 14;	// 透明通道数据扩展回调
        public const int BRAS_CBTYPE_TRANSFILE			= 15;	// 文件传输回调函数
        public const int BRAS_CBTYPE_SERVERRECORD		= 16;	// 服务器录像回调
        public const int BRAS_CBTYPE_SERVERRECORDEX		= 17;	// 服务器录像（扩展）回调
        public const int BRAS_CBTYPE_VIDEOCALL			= 18;	// 视频通话消息通知回调
        public const int BRAS_CBTYPE_USERINFOCTRL		= 19;	// 用户信息控制回调
        public const int BRAS_CBTYPE_OBJECTEVENT        = 20;	// 业务对象事件回调

        // 录像功能标志定义（API：BRAS_StreamRecordCtrl 传入参数）
        public const int ANYCHAT_RECORD_FLAGS_VIDEO		= 0x001;// 录制视频
        public const int ANYCHAT_RECORD_FLAGS_AUDIO		= 0x002;// 录制音频
        public const int ANYCHAT_RECORD_FLAGS_SERVER	= 0x004;// 服务器端录制
        public const int ANYCHAT_RECORD_FLAGS_MIXAUDIO	= 0x010;// 录制音频时，将其它人的声音混音后录制
        public const int ANYCHAT_RECORD_FLAGS_MIXVIDEO	= 0x020;// 录制视频时，将其它人的视频迭加后录制
        public const int ANYCHAT_RECORD_FLAGS_ABREAST	= 0x100;// 录制视频时，将其它人的视频并列录制
        public const int ANYCHAT_RECORD_FLAGS_STEREO	= 0x200;// 录制音频时，将其它人的声音混合为立体声后录制
        public const int ANYCHAT_RECORD_FLAGS_SNAPSHOT	= 0x400;// 拍照
        public const int ANYCHAT_RECORD_FLAGS_LOCALCB   = 0x800;// 触发本地回调
        public const int ANYCHAT_RECORD_FLAGS_STREAM	= 0x1000;// 对视频流进行录制（效率高，但可能存在视频方向旋转的问题）
        public const int ANYCHAT_RECORD_FLAGS_USERFILENAME = 0x2000;// 用户自定义文件名
		
        // 视频裁剪模式定义
        public const int ANYCHAT_VIDEOCLIPMODE_AUTO         = 0;	// 默认模式，以最大比例进行裁剪，然后再整体拉伸，画面保持比例，但被裁剪画面较大
        public const int ANYCHAT_VIDEOCLIPMODE_OVERLAP		= 1;	// 重叠模式，只取最大有效部分，对边缘进行裁剪
        public const int ANYCHAT_VIDEOCLIPMODE_SHRINK		= 2;	// 缩小模式，缩小到合适的比例，不进行裁剪
        public const int ANYCHAT_VIDEOCLIPMODE_STRETCH		= 3;	// 平铺模式，不进行裁剪，但可能导致画面不成比例
        public const int ANYCHAT_VIDEOCLIPMODE_DYNAMIC		= 4;    // 动态模式，由上层应用根据分辩率来调整显示表面，保持画面不变形

        #region AnyChat业务对象常量定义

        #region 对象类型定义

        /// <summary>
        /// 服务区域
        /// </summary>
        public const int ANYCHAT_OBJECT_TYPE_AREA = 4;
        /// <summary>
        /// 队列对象
        /// </summary>
        public const int ANYCHAT_OBJECT_TYPE_QUEUE = 5;
        /// <summary>
        /// 客服对象
        /// </summary>
        public const int ANYCHAT_OBJECT_TYPE_AGENT = 6;
        /// <summary>
        /// 客户端用户对象
        /// </summary>
        public const int ANYCHAT_OBJECT_TYPE_CLIENTUSER = 8;

        #endregion

        #region 通用标识常量定义

        /// <summary>
        /// 普通客户
        /// </summary>
        public const int ANYCHAT_OBJECT_FLAGS_CLIENT = 0;
        /// <summary>
        /// 坐席用户
        /// </summary>
        public const int ANYCHAT_OBJECT_FLAGS_AGENT = 2;
        /// <summary>
        /// 管理用户
        /// </summary>
        public const int ANYCHAT_OBJECT_FLAGS_MANANGER = 4;
        /// <summary>
        /// 无效的对象ID
        /// </summary>
        public const int ANYCHAT_INVALID_OBJECT_ID = -1;
        /// <summary>
        /// 业务对象身份初始化
        /// </summary>
        public const int BRAC_SO_OBJECT_INITFLAGS = 200;

        #endregion

        #region 对象属性定义_对象公共

        /// <summary>
        /// 对象属性标志
        /// </summary>
        public const int ANYCHAT_OBJECT_INFO_FLAGS = 7;
        /// <summary>
        /// 对象名称
        /// </summary>
        public const int ANYCHAT_OBJECT_INFO_NAME = 8;
        /// <summary>
        /// 对象优先级
        /// </summary>
        public const int ANYCHAT_OBJECT_INFO_PRIORITY = 9;
        /// <summary>
        /// 对象业务属性
        /// </summary>
        public const int ANYCHAT_OBJECT_INFO_ATTRIBUTE = 10;
        /// <summary>
        /// 对象描述
        /// </summary>
        public const int ANYCHAT_OBJECT_INFO_DESCRIPTION = 11;
        /// <summary>
        /// 对象标签，整型，上层应用自定义
        /// </summary>
        public const int ANYCHAT_OBJECT_INFO_INTTAG = 12;
        /// <summary>
        /// 对象标签，字符串，上层应用自定义
        /// </summary>
        public const int ANYCHAT_OBJECT_INFO_STRINGTAG = 13;

        #endregion

        #region 对象属性定义_服务区域

        /// <summary>
        /// 服务区域客服（坐席）数量
        /// </summary>
        public const int ANYCHAT_AREA_INFO_AGENTCOUNT = 401;
        /// <summary>
        /// 服务区域内访客的用户数（没有排入队列的用户）
        /// </summary>
        public const int ANYCHAT_AREA_INFO_GUESTCOUNT = 402;
        /// <summary>
        /// 服务区域内排队的用户数
        /// </summary>
        public const int ANYCHAT_AREA_INFO_QUEUEUSERCOUNT = 403;
        /// <summary>
        /// 服务区域内队列的数量
        /// </summary>
        public const int ANYCHAT_AREA_INFO_QUEUECOUNT = 404;

        #endregion

        #region 对象属性定义_业务队列

        /// <summary>
        /// 自己在该队列中的序号
        /// </summary>
        public const int ANYCHAT_QUEUE_INFO_MYSEQUENCENO = 501;
        /// <summary>
        /// 排在自己前面的用户数
        /// </summary>
        public const int ANYCHAT_QUEUE_INFO_BEFOREUSERNUM = 502;
        /// <summary>
        /// 进入队列的时间
        /// </summary>
        public const int ANYCHAT_QUEUE_INFO_MYENTERQUEUETIME = 503;
        /// <summary>
        /// 业务队列长度（有多少人在排队）
        /// </summary>
        public const int ANYCHAT_QUEUE_INFO_LENGTH = 504;
        /// <summary>
        /// 自己在队列中的等待时间（单位：秒）
        /// </summary>
        public const int ANYCHAT_QUEUE_INFO_WAITTIMESECOND = 508;

        #endregion

        #region 对象属性定义_客服（坐席）

        /// <summary>
        /// 服务状态
        /// </summary>
        public const int ANYCHAT_AGENT_INFO_SERVICESTATUS = 601;
        /// <summary>
        /// 当前服务的用户ID
        /// </summary>
        public const int ANYCHAT_AGENT_INFO_SERVICEUSERID = 602;
        /// <summary>
        /// 当前服务的开始时间
        /// </summary>
        public const int ANYCHAT_AGENT_INFO_SERVICEBEGINTIME = 603;
        /// <summary>
        /// 累计服务时间（单位：秒）
        /// </summary>
        public const int ANYCHAT_AGENT_INFO_SERVICETOTALTIME = 604;
        /// <summary>
        /// 累计服务的用户数
        /// </summary>
        public const int ANYCHAT_AGENT_INFO_SERVICETOTALNUM = 605;

        #endregion

        #region 客服（坐席）服务状态

        /// <summary>
        /// 关闭，不对外提供服务
        /// </summary>
        public const int ANYCHAT_AGENT_STATUS_CLOSEED = 0;
        /// <summary>
        /// 等待中，可随时接受用户服务
        /// </summary>
        public const int ANYCHAT_AGENT_STATUS_WAITTING = 1;
        /// <summary>
        /// 工作中，正在为用户服务
        /// </summary>
        public const int ANYCHAT_AGENT_STATUS_WORKING = 2;
        /// <summary>
        /// 暂停服务
        /// </summary>
        public const int ANYCHAT_AGENT_STATUS_PAUSED = 3;

        #endregion

        #endregion

        #region AnyChat业务方法常量定义

        #region 方法常量定义—公共参数

        /// <summary>
        /// 创建一个对象
        /// </summary>
        public const int ANYCHAT_OBJECT_CTRL_CREATE = 2;
        /// <summary>
        /// 同步对象数据给指定用户
        /// </summary>
        public const int ANYCHAT_OBJECT_CTRL_SYNCDATA = 3;
        /// <summary>
        /// 对象调试信息输出
        /// </summary>
        public const int ANYCHAT_OBJECT_CTRL_DEBUGOUTPUT = 4;

        #endregion

        #region 方法常量定义—服务区域

        /// <summary>
        /// 进入服务区域
        /// </summary>
        public const int ANYCHAT_AREA_CTRL_USERENTER = 401;
        /// <summary>
        /// 离开服务区域
        /// </summary>
        public const int ANYCHAT_AREA_CTRL_USERLEAVE = 402;

        #endregion

        #region 方法常量定义—业务队列

        /// <summary>
        /// 进入业务队列
        /// </summary>
        public const int ANYCHAT_QUEUE_CTRL_USERENTER = 501;
        /// <summary>
        /// 离开业务队列
        /// </summary>
        public const int ANYCHAT_QUEUE_CTRL_USERLEAVE = 502;

        #endregion

        #region 方法常量定义—客服（坐席）

        /// <summary>
        /// 坐席服务状态控制
        /// </summary>
        public const int ANYCHAT_AGENT_CTRL_SERVICESTATUS = 601;
        /// <summary>
        /// 服务请求
        /// </summary>
        public const int ANYCHAT_AGENT_CTRL_SERVICEREQUEST = 602;
        /// <summary>
        /// 结束服务
        /// </summary>
        public const int ANYCHAT_AGENT_CTRL_FINISHSERVICE = 604;
        /// <summary>
        /// 服务评价
        /// </summary>
        public const int ANYCHAT_AGENT_CTRL_EVALUATION = 605;

        #endregion

        #endregion

        #region AnyChat业务异步事件常量定义

        #region 异步事件常量定义—公共事件

        /// <summary>
        /// 对象数据更新
        /// </summary>
        public const int ANYCHAT_OBJECT_EVENT_UPDATE = 1;
        /// <summary>
        /// 对象数据同步结束
        /// </summary>
        public const int ANYCHAT_OBJECT_EVENT_SYNCDATAFINISH = 2;

        #endregion

        #region 异步事件常量定义—服务区域

        /// <summary>
        /// 服务区域状态变化
        /// </summary>
        public const int ANYCHAT_AREA_EVENT_STATUSCHANGE = 401;
        /// <summary>
        /// 进入服务区域结果
        /// </summary>
        public const int ANYCHAT_AREA_EVENT_ENTERRESULT = 402;
        /// <summary>
        /// 用户进入服务区域
        /// </summary>
        public const int ANYCHAT_AREA_EVENT_USERENTER = 403;
        /// <summary>
        /// 用户离开服务区域
        /// </summary>
        public const int ANYCHAT_AREA_EVENT_USERLEAVE = 404;
        /// <summary>
        /// 离开服务区域结果
        /// </summary>
        public const int ANYCHAT_AREA_EVENT_LEAVERESULT = 405;

        #endregion

        #region 异步事件常量定义—业务队列

        /// <summary>
        /// 业务队列状态变化
        /// </summary>
        public const int ANYCHAT_QUEUE_EVENT_STATUSCHANGE = 501;
        /// <summary>
        /// 进入业务队列结果
        /// </summary>
        public const int ANYCHAT_QUEUE_EVENT_ENTERRESULT = 502;
        /// <summary>
        /// 用户进入业务队列
        /// </summary>
        public const int ANYCHAT_QUEUE_EVENT_USERENTER = 503;
        /// <summary>
        /// 用户离开业务队列
        /// </summary>
        public const int ANYCHAT_QUEUE_EVENT_USERLEAVE = 504;
        /// <summary>
        /// 离开业务队列结果
        /// </summary>
        public const int ANYCHAT_QUEUE_EVENT_LEAVERESULT = 505;

        #endregion

        #region 异步事件常量定义—客服（坐席）

        /// <summary>
        /// 坐席状态变化
        /// </summary>
        public const int ANYCHAT_AGENT_EVENT_STATUSCHANGE = 601;
        /// <summary>
        /// 坐席服务通知（哪个用户到哪个坐席办理业务）
        /// </summary>
        public const int ANYCHAT_AGENT_EVENT_SERVICENOTIFY = 602;
        /// <summary>
        /// 暂时没有客户，请等待
        /// </summary>
        public const int ANYCHAT_AGENT_EVENT_WAITINGUSER = 603;

        #endregion

        #endregion


		
        /**
		 *    回调函数定义
		 */

        // 服务器应用程序消息回调函数定义
        //typedef void (CALLBACK* BRAS_OnServerAppMessage_CallBack)(DWORD dwMsg, LPVOID lpUserValue);
        public delegate void OnServerAppMessageCallBack(int msg, int userValue);
		
		// 服务器应用程序消息（扩展）回调函数定义
        //typedef void (CALLBACK* BRAS_OnServerAppMessageEx_CallBack)(DWORD dwNotifyMessage, DWORD wParam, DWORD lParam, LPVOID lpUserValue);
        public delegate void OnServerAppMessageExCallBack(int dwNotifyMessage, int wParam, int lParam, int userValue);

		// SDK定时器回调函数定义（上层应用可以在该回调中处理定时任务，而不需要额外开启线程，或是定时器）
		//typedef void (CALLBACK* BRAS_OnTimerEvent_CallBack)(LPVOID lpUserValue);
        public delegate void OnTimerEventCallBack(int userValue);

		// 用户身份验证回调函数定义
		// typedef DWORD (CALLBACK* BRAS_VerifyUser_CallBack)(IN LPCTSTR lpUserName,IN LPCTSTR lpPassword, OUT LPDWORD lpUserID, OUT LPDWORD lpUserLevel, OUT LPTSTR lpNickName,IN DWORD dwNCLen, LPVOID lpUserValue);
        public delegate int VerifyUserCallBack(string userName, string password, ref int userID, ref int userLevel, IntPtr nickName, int len,int userValue);

        // 用户申请进入房间回调函数定义
        //typedef DWORD (CALLBACK* BRAS_PrepareEnterRoom_CallBack)(DWORD dwUserId, DWORD dwRoomId, LPCTSTR lpRoomName,LPCTSTR lpPassword, LPVOID lpUserValue);
        public delegate int PrepareEnterRoomCallBack(int userId, int roomId, string roomName, string password, int userValue);

        // 用户登录成功回调函数定义
        //typedef void (CALLBACK* BRAS_OnUserLoginAction_CallBack)(DWORD dwUserId, LPCTSTR szUserName, DWORD dwLevel, LPCTSTR szIpAddr, LPVOID lpUserValue);
        public delegate void OnUserLoginActionCallBack(int userId, string userName, int level, string addr, int userValue);

        // 用户注销回调函数定义
        //typedef void (CALLBACK* BRAS_OnUserLogoutAction_CallBack)(DWORD dwUserId, LPVOID lpUserValue);
        public delegate void OnUserLogoutActionCallBack(int userId, int userValue);
		
		// 用户注销回调函数定义（扩展）
        //typedef void (CALLBACK* BRAS_OnUserLogoutActionEx_CallBack)(DWORD dwUserId, DWORD dwErrorCode, LPVOID lpUserValue);
        public delegate void OnUserLogoutActionExCallBack(int userId, int errorcode, int userValue);

        // 用户进入房间回调函数定义
        //typedef void (CALLBACK* BRAS_OnUserEnterRoomAction_CallBack)(DWORD dwUserId, DWORD dwRoomId, LPVOID lpUserValue);
        public delegate void OnUserEnterRoomActionCallBack(int userId, int roomId, int userValue);

        // 用户离开房间回调函数定义
        //typedef void (CALLBACK* BRAS_OnUserLeaveRoomAction_CallBack)(DWORD dwUserId, DWORD dwRoomId, LPVOID lpUserValue);
        public delegate void OnUserLeaveRoomActionCallBack(int userId, int roomId, int userValue);

        // 上层业务自定义数据回调函数定义
        //typedef void (CALLBACK* BRAS_OnRecvUserFilterData_CallBack)(DWORD dwUserId, LPCTSTR lpBuf, DWORD dwLen, LPVOID lpUserValue);
        public delegate void OnRecvUserFilterDataCallBack(int userId, IntPtr buf, int len, int userValue);

        // 收到用户文字聊天通信数据回调函数定义
        //typedef void (CALLBACK* BRAS_OnRecvUserTextMsg_CallBack)(DWORD dwRoomId, DWORD dwSrcUserId, DWORD dwTarUserId, BOOL bSecret, LPCTSTR lpTextMessage, DWORD dwLen, LPVOID lpUserValue);
        public delegate void OnRecvUserTextMsgCallBack(int roomId, int srcUserId, int tarUserId, bool bSecret, string textMessage, int len, int userValue);

		// 透明通道数据回调函数定义
		//typedef void (CALLBACK * BRAS_OnTransBuffer_CallBack)(DWORD dwUserId, LPBYTE lpBuf, DWORD dwLen, LPVOID lpUserValue);
		public delegate void OnTransBufferCallBack(int dwUserId, IntPtr lpBuf, int dwLen, int lpUserValue);
		
		// 透明通道数据扩展回调函数定义
		//typedef void (CALLBACK * BRAS_OnTransBufferEx_CallBack)(DWORD dwUserId, LPBYTE lpBuf, DWORD dwLen, DWORD wParam, DWORD lParam, DWORD dwTaskId, LPVOID lpUserValue);
		public delegate void OnTransBufferExCallBack(int dwUserId, IntPtr lpBuf, int dwLen, int wParam, int lParam, int dwTaskId, int lpUserValue);
		
		// 文件传输回调函数定义
		//typedef void (CALLBACK * BRAS_OnTransFile_CallBack)(DWORD dwUserId, LPCTSTR lpFileName, LPCTSTR lpTempFilePath, DWORD dwFileLength, DWORD wParam, DWORD lParam, DWORD dwTaskId, LPVOID lpUserValue);
		public delegate void OnTransFileCallBack(int dwUserId, string lpFileName, string lpTempFilePath, int dwFileLength, int wParam, int lParam, int dwTaskId, int lpUserValue);

		// 服务器录像回调函数定义
		//typedef void (CALLBACK * BRAS_OnServerRecord_CallBack)(DWORD dwUserId, DWORD dwParam, DWORD dwRecordServerId, DWORD dwElapse, LPCTSTR lpRecordFileName, LPVOID lpUserValue);
		public delegate void OnServerRecordCallBack(int dwUserId, int dwParam, int dwRecordServerId, int dwElapse, string lpRecordFileName, int lpUserValue);

        // 服务器录像回调函数定义（扩展）
        //typedef void (CALLBACK * BRAS_OnServerRecordEx_CallBack)(DWORD dwUserId, LPCTSTR lpFileName, DWORD dwElapse, DWORD dwFlags, DWORD dwParam, LPCTSTR lpUserStr, DWORD dwRecordServerId, LPVOID lpUserValue);
        public delegate void OnServerRecordExCallBack(int dwUserId, string lpFileName, int dwElapse, int dwFlags, int dwParam, string lpUserStr, int dwRecordServerId, IntPtr lpCallBackUserValue);

		// 视频通话消息通知回调函数定义
		//typedef DWORD (CALLBACK * BRAS_OnVideoCallEvent_CallBack)(DWORD dwEventType, DWORD dwSrcUserId, DWORD dwTarUserId, DWORD dwErrorCode, DWORD dwFlags, DWORD dwParam, LPCTSTR lpUserStr, LPVOID lpUserValue);
		public delegate int OnVideoCallEventCallBack(int dwEventType, int dwSrcUserId, int dwTarUserId, int dwErrorCode, int dwFlags, int dwParam, string lpUserStr, int lpUserValue);
		
        // 用户信息控制回调函数定义
        //typedef DWORD (CALLBACK * BRAS_OnUserInfoControl_CallBack)(DWORD dwSendUserId, DWORD dwUserId, DWORD dwCtrlCode, DWORD wParam, DWORD lParam, LPCTSTR lpStrValue, LPVOID lpUserValue); 
        public delegate int OnUserInfoControlCallBack(int dwSendUserId, int dwUserId, int dwCtrlCode, int wParam, int lParam, string lpStrValue, int lpUserValue);

        // 业务对象事件回调函数定义
        //typedef void (CALLBACK * BRAS_ObjectEventNotify_CallBack)(DWORD dwObjectType, DWORD dwObjectId, DWORD dwEventType, DWORD dwParam1, DWORD dwParam2, DWORD dwParam3, DWORD dwParam4, LPCTSTR lpStrParam, LPVOID lpUserValue);
        public delegate void ObjectEventNotifyCallBack(int dwObjectType, int dwObjectId, int dwEventType, int dwParam1, int dwParam2, int dwParam3, int dwParam4, string lpStrParam, int lpUserValue);


		/**
		 *    API 方法定义
		 */

        // 设置服务器应用程序消息回调函数
        //BRAS_API DWORD BRAS_SetOnServerAppMessageCallBack(BRAS_OnServerAppMessage_CallBack lpFunction, LPVOID lpUserValue=NULL);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetOnServerAppMessageCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SetOnServerAppMessageCallBack(OnServerAppMessageCallBack function, int userValue);
		
		// 设置服务器应用程序消息（扩展）回调函数
        //BRAS_API DWORD BRAS_SetOnServerAppMessageExCallBack(BRAS_OnServerAppMessageEx_CallBack lpFunction, LPVOID lpUserValue=NULL);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetOnServerAppMessageExCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SetOnServerAppMessageExCallBack(OnServerAppMessageExCallBack function, int userValue);

        // 设置SDK定时器回调函数（dwElapse：定时器间隔，单位：ms）
        // BRAS_API DWORD BRAS_SetTimerEventCallBack(DWORD dwElapse, BRAS_OnTimerEvent_CallBack lpFunction, LPVOID lpUserValue=NULL);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetTimerEventCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SetTimerEventCallBack(int elapse, OnTimerEventCallBack function, int userValue);

        // 设置用户身份验证回调函数
        //BRAS_API DWORD BRAS_SetVerifyUserCallBack(BRAS_VerifyUser_CallBack lpFunction, LPVOID lpUserValue=NULL);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetVerifyUserCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SetVerifyUserCallBack(VerifyUserCallBack function, int userValue);

        // 设置用户申请进入房间回调函数
        // BRAS_API DWORD BRAS_SetPrepareEnterRoomCallBack(BRAS_PrepareEnterRoom_CallBack lpFunction, LPVOID lpUserValue=NULL);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetPrepareEnterRoomCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SetPrepareEnterRoomCallBack(PrepareEnterRoomCallBack function, int userValue);

        // 设置用户登录成功回调函数
        //BRAS_API DWORD BRAS_SetOnUserLoginActionCallBack(BRAS_OnUserLoginAction_CallBack lpFunction, LPVOID lpUserValue=NULL);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetOnUserLoginActionCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SetOnUserLoginActionCallBack(OnUserLoginActionCallBack function, int userValue);

        // 设置用户注销回调函数
        //BRAS_API DWORD BRAS_SetOnUserLogoutActionCallBack(BRAS_OnUserLogoutAction_CallBack lpFunction, LPVOID lpUserValue=NULL);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetOnUserLogoutActionCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SetOnUserLogoutActionCallBack(OnUserLogoutActionCallBack function, int userValue);
		
		// 设置用户注销回调函数（扩展）
        //BRAS_API DWORD BRAS_SetOnUserLogoutActionExCallBack(BRAS_OnUserLogoutActionEx_CallBack lpFunction, LPVOID lpUserValue=NULL);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetOnUserLogoutActionExCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SetOnUserLogoutActionExCallBack(OnUserLogoutActionExCallBack function, int userValue);

        // 设置用户进入房间回调函数
        //BRAS_API DWORD BRAS_SetOnUserEnterRoomActionCallBack(BRAS_OnUserEnterRoomAction_CallBack lpFunction, LPVOID lpUserValue=NULL);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetOnUserEnterRoomActionCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SetOnUserEnterRoomActionCallBack(OnUserEnterRoomActionCallBack function, int userValue);

        // 设置用户离开房间回调函数
        //BRAS_API DWORD BRAS_SetOnUserLeaveRoomActionCallBack(BRAS_OnUserLeaveRoomAction_CallBack lpFunction, LPVOID lpUserValue=NULL);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetOnUserLeaveRoomActionCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SetOnUserLeaveRoomActionCallBack(OnUserLeaveRoomActionCallBack function, int userValue);

        // 设置用户上层业务自定义数据回调函数
        // BRAS_API DWORD BRAS_SetOnRecvUserFilterDataCallBack(BRAS_OnRecvUserFilterData_CallBack lpFunction, LPVOID lpUserValue=NULL);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetOnRecvUserFilterDataCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SetOnRecvUserFilterDataCallBack(OnRecvUserFilterDataCallBack function, int userValue);

        // 设置用户文字聊天通信数据回调函数
        //BRAS_API DWORD BRAS_SetOnRecvUserTextMsgCallBack(BRAS_OnRecvUserTextMsg_CallBack lpFunction, LPVOID lpUserValue=NULL);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetOnRecvUserTextMsgCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SetOnRecvUserTextMsgCallBack(OnRecvUserTextMsgCallBack function, int userValue);
		
		
		// 设置透明通道数据回调函数
		//BRAS_API DWORD BRAS_SetOnTransBufferCallBack(BRAS_OnTransBuffer_CallBack lpFunction, LPVOID lpUserValue=NULL);
		[DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetOnTransBufferCallBack", CallingConvention = CallingConvention.Cdecl)]
		public static extern int BRAS_SetOnTransBufferCallBack(OnTransBufferCallBack function, int lpUserValue);
		
		// 设置透明通道数据扩展回调函数
		//BRAS_API DWORD BRAS_SetOnTransBufferExCallBack(BRAS_OnTransBufferEx_CallBack lpFunction, LPVOID lpUserValue=NULL);
		[DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetOnTransBufferExCallBack", CallingConvention = CallingConvention.Cdecl)]
		public static extern int BRAS_SetOnTransBufferExCallBack(OnTransBufferExCallBack function, int lpUserValue);
		
		// 设置文件传输回调函数
		//BRAS_API DWORD BRAS_SetOnTransFileCallBack(BRAS_OnTransFile_CallBack lpFunction, LPVOID lpUserValue=NULL);
		[DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetOnTransFileCallBack", CallingConvention = CallingConvention.Cdecl)]
		public static extern int BRAS_SetOnTransFileCallBack(OnTransFileCallBack function, int lpUserValue);
		
		// 设置服务器录像通知回调函数
		//BRAS_API DWORD BRAS_SetOnServerRecordCallBack(BRAS_OnServerRecord_CallBack lpFunction, LPVOID lpUserValue=NULL);
		[DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetOnServerRecordCallBack", CallingConvention = CallingConvention.Cdecl)]
		public static extern int BRAS_SetOnServerRecordCallBack(OnServerRecordCallBack function, int lpUserValue);

		// 设置视频通话消息通知回调函数
		//BRAS_API DWORD BRAS_SetOnVideoCallEventCallBack(BRAS_OnVideoCallEvent_CallBack lpFunction, LPVOID lpUserValue=NULL);
		[DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetOnVideoCallEventCallBack", CallingConvention = CallingConvention.Cdecl)]
		public static extern int BRAS_SetOnVideoCallEventCallBack(OnVideoCallEventCallBack function, int lpUserValue);

        // 设置回调函数
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SetCallBack(int dwCBType, IntPtr lpFuncPtr, IntPtr lpCallBackUserValue);
		
		
		// 获取SDK版本信息
		//BRAS_API DWORD BRAS_GetSDKVersion(DWORD& dwMainVer, DWORD& dwSubVer, TCHAR* lpCompileTime, DWORD dwBufLen);
		[DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_GetSDKVersion", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_GetSDKVersion(ref int dwMainVer, ref int dwSubVer, StringBuilder lpCompileTime, int bufLen);
		
        // 初始化SDK
        //BRAS_API DWORD BRAS_InitSDK(DWORD dwReserved);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_InitSDK", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_InitSDK(int reserved);

        // 释放资源
        //BRAS_API DWORD BRAS_Release(void);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_Release", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_Release();

        // 向指定用户发送数据
        //BRAS_API DWORD BRAS_SendBufToUser(DWORD dwUserId, LPCTSTR lpBuf, DWORD dwLen);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SendBufToUser", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SendBufToUser(int userId, byte[] buf, int len);

        // 向指定房间的所有用户发送数据
        //BRAS_API DWORD BRAS_SendBufToRoom(DWORD dwRoomId, LPCTSTR lpBuf, DWORD dwLen);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SendBufToRoom", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SendBufToRoom(int dwRoomId, byte[] lpBuf, int dwLen);
		
		// 向指定用户发送透明通道数据
		//BRAS_API DWORD BRAS_TransBuffer(DWORD dwUserId, LPBYTE lpBuf, DWORD dwLen);
		[DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_TransBuffer", CallingConvention = CallingConvention.Cdecl)]
		public static extern int BRAS_TransBuffer(int dwUserId, byte[] lpBuf, int dwLen);
		
		// 向指定用户发送扩展缓冲区数据
		//BRAS_API DWORD BRAS_TransBufferEx(DWORD dwUserId, LPBYTE lpBuf, DWORD dwLen, DWORD wParam, DWORD lParam, DWORD dwFlags, DWORD& dwTaskId);
		[DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_TransBufferEx", CallingConvention = CallingConvention.Cdecl)]
		public static extern int BRAS_TransBufferEx(int dwUserId, byte[] lpBuf, int dwLen, int wParam, int lParam, int dwFlags, ref int dwTaskId);
		
		// 向指定用户发送文件
		//BRAS_API DWORD BRAS_TransFile(DWORD dwUserId, LPCTSTR lpLocalPathName, DWORD wParam, DWORD lParam, DWORD dwFlags, DWORD& dwTaskId);
		[DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_TransFile", CallingConvention = CallingConvention.Cdecl)]
		public static extern int BRAS_TransFile(int dwUserId, string lpLocalPathName, int wParam, int lParam, int dwFlags, ref int dwTaskId);
		
		// 中心端录像控制
		//BRAS_API DWORD BRAS_StreamRecordCtrl(DWORD dwUserId, BOOL bStartRecord, DWORD dwFlags, DWORD dwParam, DWORD dwRecordServerId);
		[DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_StreamRecordCtrl", CallingConvention = CallingConvention.Cdecl)]
		public static extern int BRAS_StreamRecordCtrl(int dwUserId, int bStartRecord, int dwFlags, int dwParam, int dwRecordServerId);

        // 中心端录像控制（扩展）
        //BRAS_API DWORD BRAS_StreamRecordCtrlEx(DWORD dwUserId, BOOL bStartRecord, DWORD dwFlags, DWORD dwParam, LPCTSTR lpUserStr=NULL, DWORD dwRecordServerId=-1);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_StreamRecordCtrlEx", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_StreamRecordCtrl(int dwUserId, int bStartRecord, int dwFlags, int dwParam, string lpUserStr, int dwRecordServerId);
		
		// 发送透明通道数据给录像服务器
		//BRAS_API DWORD BRAS_TransBuffer2RecordServer(DWORD dwUserId, LPBYTE lpBuf, DWORD dwLen, DWORD dwParam, DWORD dwRecordServerId);
		[DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_TransBuffer2RecordServer", CallingConvention = CallingConvention.Cdecl)]
		public static extern int BRAS_TransBuffer2RecordServer(int dwUserId, byte[] lpBuf, int dwLen, int dwParam, int dwRecordServerId);
		
		// 视频呼叫事件控制（请求、回复、挂断等）
		//BRAS_API DWORD BRAS_VideoCallControl(DWORD dwEventType, DWORD dwUserId, DWORD dwErrorCode, DWORD dwFlags=0, DWORD dwParam=0, LPCTSTR lpUserStr=NULL);
		[DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_VideoCallControl", CallingConvention = CallingConvention.Cdecl)]
		public static extern int BRAS_VideoCallControl(int dwEventType, int dwUserId, int dwErrorCode, int dwFlags, int dwParam, string lpUserStr);
		

        // 设置用户的详细信息
		//BRAS_API DWORD BRAS_SetUserInfo(DWORD dwUserId, DWORD dwInfoId, LPCTSTR lpInfoValue, DWORD dwFlags=0);
		[DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetUserInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SetUserInfo(int dwUserId, int dwInfoId, string lpInfoValue, int dwFlags);

        // 获取用户的详细信息
		//BRAS_API DWORD BRAS_GetUserInfo(DWORD dwUserId, DWORD dwInfoId, TCHAR* lpInfoValue, DWORD dwSize);
		[DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_GetUserInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_GetUserInfo(int dwUserId, int dwInfoId, StringBuilder lpInfoValue, int dwSize);

        // 用户信息控制
		//BRAS_API DWORD BRAS_UserInfoControl(DWORD dwUserId, DWORD dwCtrlCode, DWORD wParam=0, DWORD lParam=0, LPCTSTR lpStrValue=NULL);
		[DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_UserInfoControl", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_UserInfoControl(int dwUserId, int dwCtrlCode, int wParam, int lParam, string lpStrValue);

        // SDK内核参数设置（字符串类型）
		//BRAS_API DWORD BRAS_SetSDKOption(DWORD optname, CHAR* optval, DWORD optlen);
		[DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetSDKOption", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SetSDKOption(int optname, StringBuilder optval, int optlen);

        // SDK内核参数设置（整型）
        //BRAS_API DWORD BRAS_SetSDKOption(DWORD optname, CHAR* optval, DWORD optlen);
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_SetSDKOption", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_SetSDKOption(int optname, ref int optval, int optlen);

        /// <summary>
        /// 获取房间在线用户列表
        /// <param name="dwRoomId">房间ID（dwRoomId=-1时，表示获取已登录系统的用户ID列表）</param>
        /// <param name="lpIdArray">用户ID数组</param>
        /// <param name="objNumber">用户数量</param>
        /// <returns></returns>
        /// </summary>
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_GetOnlineUsers", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_GetOnlineUsers(int dwRoomId, int[] lpIdArray, ref int dwCount);

        /// <summary>
        /// 获取房间ID列表（系统所有活动的房间）
        /// <param name="lpIdArray">房间ID数组</param>
        /// <param name="objNumber">房间数量</param>
        /// <returns></returns>
        /// </summary>
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_GetRoomIdList", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_GetRoomIdList(int[] lpIdArray, ref int dwCount);

        /// <summary>
        /// 向核心服务器动态查询相关信息
        /// </summary>
        /// <param name="dwInfoName"></param>
        /// <param name="lpInParam"></param>
        /// <param name="dwInSize"></param>
        /// <param name="lpResult"></param>
        /// <param name="dwOutSize"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_QueryInfoFromServer", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_QueryInfoFromServer(int dwInfoName, StringBuilder lpInParam, int dwInSize, StringBuilder lpResult, ref int dwOutSize, int dwFlags);
        
        #region 业务对象API方法定义

        /// <summary>
        /// 返回某对象类型的对象ID数组
        /// <param name="dwObjectType">对象类型</param>
        /// <param name="objIDArray">对象ID数组</param>
        /// <param name="objNumber">对象长度</param>
        /// <returns></returns>
        /// </summary>
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_ObjectGetIdList", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_ObjectGetIdList(int dwObjectType, int[] objIDArray, ref int objNumber);

        /// <summary>
        /// 获取对象的属性值(整型)
        /// <param name="dwObjectType">对象类型</param>
        /// <param name="dwObjectId">对象ID</param>
        /// <param name="dwInfoName">属性名</param>
        /// </summary>
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_ObjectGetValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_ObjectGetValue(int dwObjectType, int dwObjectId, int dwInfoName, ref int value);

        /// <summary>
        /// 获取对象的属性值(字符串)
        /// <param name="dwObjectType">对象类型</param>
        /// <param name="dwObjectId">对象ID</param>
        /// <param name="dwInfoName">属性名</param>
        /// </summary>
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_ObjectGetValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_ObjectGetValue(int dwObjectType, int dwObjectId, int dwInfoName, StringBuilder value);

        /// <summary>
        /// 设置对象的属性值(整型)
        /// <param name="dwObjectType">对象类型</param>
        /// <param name="dwObjectId">对象ID</param>
        /// <param name="dwInfoName">属性名</param>
        /// <param name="value">属性值</param>
        /// </summary>
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_ObjectSetValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_ObjectSetValue(int dwObjectType, int dwObjectId, int dwInfoName, ref int value, int optlen);

        /// <summary>
        /// 设置对象的属性值(字符串)
        /// <param name="dwObjectType">对象类型</param>
        /// <param name="dwObjectId">对象ID</param>
        /// <param name="dwInfoName">属性名</param>
        /// <param name="value">属性值</param>
        /// </summary>
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_ObjectSetValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_ObjectSetValue(int dwObjectType, int dwObjectId, int dwInfoName, string value, int optlen);

        /// <summary>
        /// 业务对象控制指令
        /// <param name="dwObjectType">对象类型</param>
        /// <param name="dwObjectId">对象ID</param>
        /// <param name="dwCtrlCode">控制方法指令</param>
        /// <param name="dwParam1"></param>
        /// <param name="dwParam2"></param>
        /// <param name="dwParam3"></param>
        /// <param name="dwParam4"></param>
        /// <param name="strParam"></param>
        /// </summary>
        [DllImport(AnyChatServerSDKDll, EntryPoint = "BRAS_ObjectControl", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BRAS_ObjectControl(int dwObjectType, int dwObjectId, int dwCtrlCode, int dwParam1, int dwParam2, int dwParam3, int dwParam4, string strParam);

        #endregion

    }
}