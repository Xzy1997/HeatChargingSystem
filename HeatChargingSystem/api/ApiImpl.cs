using HeatChargingSystem.constants;
using HeatChargingSystem.model.request;
using HeatChargingSystem.model.response;
using HeatChargingSystem.utils;
using Newtonsoft.Json;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.api
{
    public class ApiImpl : IApi
    {
        public BaseResponseModel AddCardOperationLog()
        {
            throw new NotImplementedException();
        }

        public BaseResponseModel AddUser(ResponseUserInfoModel request)
        {
            try
            {
                string result = HttpUtils.PostRequest(AppConfigMoel.URL + ConstantsValue.HTTP_ADD_USER_URI, JsonConvert.SerializeObject(request),AppConfigMoel.token);
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                return responseModel;
            }
            catch (Exception)
            {

                throw;
            }                      
        }

        public BaseResponseModel DelUser(string[] ids)
        {
            throw new NotImplementedException();
        }

        public List<controller_type> GetAllDictionary()
        {
            try
            {
                string result = HttpUtils.GetRequest(AppConfigMoel.URL + ConstantsValue.HTTP_GETREGION_RUI, AppConfigMoel.token);
                //Console.WriteLine(result);
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                var arrdata = Newtonsoft.Json.Linq.JArray.Parse(responseModel.data.ToString());
                List<controller_type> obj2 = arrdata.ToObject<List<controller_type>>();            
                return obj2;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<ResponseUserInfoModel> GetAllUserList()
        {
            throw new NotImplementedException();
        }

        public BaseResponseModel GetCardOPerationLog()
        {
            throw new NotImplementedException();
        }

        public List<Region> GetRegion( string level,string pid)
        {
            try
            {
                string str = AppConfigMoel.URL + ConstantsValue.HTTP_GETREGION_RUI;
                str = str + "?level={0}&id={1}";
                string url = String.Format(str, level, pid);
                string result = HttpUtils.GetRequest(url, AppConfigMoel.token);
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                // string str= "[{'id':3,'sort':1,'pid':2,'level':3,'name':'福州市','code':'01','longCode':'3501','hasParent':false,'hasChildren':false},{'id':4,'sort':1,'pid':3,'level':3,'name':'宁波市','code':'01','longCode':'3501','hasParent':false,'hasChildren':false}]";
                if (responseModel.data != null)
                {
                    var arrdata = Newtonsoft.Json.Linq.JArray.Parse(responseModel.data.ToString());
                    //var arrdata = Newtonsoft.Json.Linq.JArray.Parse(str);
                    List<Region> obj2 = arrdata.ToObject<List<Region>>();
                    return obj2;
                }
                return null;
                
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<ResponseUserInfoModel> GetUserList(int pageSize, int pageNum)
        {
            throw new NotImplementedException();
        }

        public ResponseTokenModel Login(RequestLoginModel request)
        {
            try
            {
                string result = HttpUtils.PostRequest(AppConfigMoel.URL + ConstantsValue.HTTP_LOGIN_URI, JsonConvert.SerializeObject(request));
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                if (responseModel != null)
                {
                    if (responseModel.code.Equals("200"))
                    {
                        ResponseTokenModel response = JsonConvert.DeserializeObject<ResponseTokenModel>(responseModel.data.ToString());
                        return response;
                    }
                    else
                    {
                        return null;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public BaseResponseModel Logout()
        {
            throw new NotImplementedException();
        }

        public BaseResponseModel ResetPwd()
        {
            throw new NotImplementedException();
        }

        public List<ResponseUserInfoModel> SearchUser(RequestUserModel request)
        {
            try
            {
                string url = AppConfigMoel.URL + ConstantsValue.HTTP_SEARCH_USER_RUI;
                string str = url+"?name={0}&controllerCode={1}&payStatus={2}";
                 str = String.Format(str, request.name, request.controllerCode, request.status);
                string result = HttpUtils.GetRequest(str, AppConfigMoel.token);
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                if (responseModel != null)
                {
                    if (responseModel.code.Equals("200"))
                    {
                        var arrdata = Newtonsoft.Json.Linq.JArray.Parse(responseModel.data.ToString());
                        List<ResponseUserInfoModel> obj2 = arrdata.ToObject<List<ResponseUserInfoModel>>();
                        // List<ResponseUserInfoModel> obj2 = new List<ResponseUserInfoModel>();
                        // obj2.Add(new ResponseUserInfoModel());
                        Console.Write("11");
                        return obj2;
                    }
                    else
                    {
                        return null;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public BaseResponseModel UpdateUser(ResponseUserInfoModel request)
        {
            throw new NotImplementedException();
        }
    }
}
