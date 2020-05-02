using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.constants
{
    public class ConstantsValue
    {

        /// <summary>
        /// GUID
        /// </summary>
        public static string GUID = "";
        /// <summary>
        /// 登录URI
        /// </summary>
        public const string HTTP_LOGIN_URI = "/login";
        /// <summary>
        /// 退出URI
        /// </summary>
        public const string HTTP_LOGOUT_URI = "/logout";
        /// <summary>
        /// 添加用户URI
        /// </summary>
        public const string HTTP_ADD_USER_URI = "/sys/homeowner/add";
        /// <summary>
        /// 删除用户URI
        /// </summary>
        public const string HTTP_DELETE_USER_URI = "/sys/homeowner/del";
        /// <summary>
        /// 更新用户URI
        /// </summary>
        public const string HTTP_UPDATE_USER_URI = "/sys/homeowner/update";
        /// <summary>
        /// 更新密码URI
        /// </summary>
        public const string HTTP_RESET_PWD_URI = "/sys/user/updatePassword";
        /// <summary>
        /// 添加读卡日志
        /// </summary>
        public const string HTTP_ADD_CARD_LOG_URII = "";
        /// <summary>
        /// 查询用户URI
        /// </summary>
        public const string HTTP_SEARCH_USER_RUI = "/sys/homeowner/searchHomeowner";
        /// <summary>
        /// 获取字典
        /// </summary>
        public const string HTTP_GETD_RUI = "/sys/dictionary/getDictionary?type=controller_type";

        /// <summary>
        /// 获取字典
        /// </summary>
        /// 
        public const string HTTP_GETREGION_RUI = "/sys/region/getRegion";
    }
}
