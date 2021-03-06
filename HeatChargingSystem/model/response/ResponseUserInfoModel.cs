﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.model.response
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class ResponseUserInfoModel
    {
       
        /// <summary>
        /// C端用户表Id
        /// </summary>
        public string id;
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 网络用户
        /// </summary>
        public string hourseCode { get; set; }
        /// <summary>
        /// 用户类型（00系统用户）
        /// </summary>
        public string userType { get; set; }
        /// <summary>
        /// 供暖面积
        /// </summary>
        public string area { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string provice { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 县/区
        /// </summary>
        public string county { get; set; }
        /// <summary>
        /// 街道
        /// </summary>
        public string street { get; set; }
        /// <summary>
        /// 小区
        /// </summary>
        public string village { get; set; }
        /// <summary>
        /// 详细地址-楼号
        /// </summary>
        public string build { get; set; }
        /// <summary>
        /// 详细地址-单元
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 详细地址-室
        /// </summary>
        public string room { get; set; }
        /// <summary>
        /// 阀门序列号
        /// </summary>
        public string controllerCode { get; set; }
        /// <summary>
        /// 阀门类型
        /// </summary>
        public string controllerType { get; set; }
        /// <summary>
        /// 阀门类型名称
        /// </summary>
        public string controllerTypeName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createDate { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 阀门开度
        /// </summary>
        public string openPecent { get; set; }
        /// <summary>
        /// 阀门缴费状态,0：未缴费，1：已经缴费，2：不需要
        /// </summary>
        public int pay_status { get; set; }

        public string phone { get; set; }
        public string heatingStations { get; set; }
    }
    public class pay_status
    {
        public int id {get; set; }
        public string name { get; set; }
        public pay_status(int id,string name)
        {
            this.id = id;
            this.name = name;

        }
    }
    public class controller_type
    {
        public string dicType { get; set; }
        public string dicTypeName { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public controller_type(string dicType, string dicTypeName, string i,string name)
        {
            this.dicType = dicType;
            this.dicTypeName = dicTypeName;
            this.id = id;
            this.name = name;
        }
    }
    public class Region
    {
        public string id { get; set; }
        public string pid { get; set; }
        public string level { get; set; }
        public string name { get; set; }

        public Region(string id, string pid, string i, string level, string name)
        {
            this.id = id;
            this.pid = pid;
            this.level = level;
            this.name = name;
        }
    }
}
