using MVC.Helper;
using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;
using MVC.Utility;

namespace MVC.Data
{
    public class ImpCategoryService : ICategoryService
    {
        private readonly InitApi _initapi;
        private readonly ConditionModel _condition;

        public ImpCategoryService(InitApi initapi, ConditionModel condition)
        {
            _initapi = initapi;
            _condition = condition;
        }
        public async Task<string> CreateCategory(CategoryModel cat)
        {
            var client = _initapi.Initial();
            try
            {
                if(cat == null)
                {
                    throw new ArgumentNullException(nameof(cat));
                }
                var json = JsonConvert.SerializeObject(cat);
                HttpContent c = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync(ConfigurationManager.AppSettings["CategoryApiUrl"],c);
                var StatusCode = res.StatusCode;
                if(res.IsSuccessStatusCode)
                {
                    return StatusCode.ToString();
                }
                else
                {
                    return StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> DeleteCategory(int? id)
        {
            var client = _initapi.Initial();
            try
            {
                HttpResponseMessage res = await client.DeleteAsync(ConfigurationManager.AppSettings["CategoryApiUrl"] + "/" + id);
                var StatusCode = res.StatusCode;
                if (res.IsSuccessStatusCode)
                {
                    return StatusCode.ToString();
                }
                else
                {
                    return StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<CategoryModel> GetAllCategoty()
        {
            IEnumerable<CategoryModel> cat = null;
            var client = _initapi.Initial();
            try
            {
                var res = client.GetAsync(ConfigurationManager.AppSettings["CategoryApiUrl"]);
                res.Wait();
                var readdata = res.Result;

                if (readdata.IsSuccessStatusCode)
                {
                    var resulte = readdata.Content.ReadAsAsync<IList<CategoryModel>>();
                    resulte.Wait();
                    cat = resulte.Result;
                }
                return cat;
            }
            catch (Exception e)
            {
                return cat;
            }
        }

        public async Task<IEnumerable<CategoryModel>> GetAll_Categoty()
        {
            IEnumerable<CategoryModel> cat = null;
            var client = _initapi.Initial();
            try
            {
                HttpResponseMessage res = await client.GetAsync(ConfigurationManager.AppSettings["CategoryApiUrl"]);

                if (res.IsSuccessStatusCode)
                {
                    //var resulte = readdata.Content.ReadAsAsync<IList<CategoryModel>>();
                    var resulte = res.Content.ReadAsStringAsync().Result;

                    cat = JsonConvert.DeserializeObject<IEnumerable<CategoryModel>>(resulte);
                }
                return cat;
            }
            catch (Exception e)
            {
                return cat;
            }
        }

        public async Task<CategoryModel> GetCategoryById(int? id)
        {
            CategoryModel cat = null;
            var client = _initapi.Initial();
            try
            {
                HttpResponseMessage res = await client.GetAsync(ConfigurationManager.AppSettings["CategoryApiUrl"]+"/"+id);
              

                if (res.IsSuccessStatusCode)
                {
                    var resulte = res.Content.ReadAsAsync<CategoryModel>();

                    cat = resulte.Result;
                }
                return cat;
            }
            catch (Exception e)
            {
                return cat;
            }
        }

        public async Task<string> UpdateCategory(CategoryModel cat)
        {
            var client = _initapi.Initial();
            try
            {
                var id = cat.CategoryID;
                if (cat == null)
                {
                    throw new ArgumentNullException(nameof(cat));
                }
                var json = JsonConvert.SerializeObject(cat);
                HttpContent c = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PutAsync(ConfigurationManager.AppSettings["CategoryApiUrl"] + "/" + id, c);
                var StatusCode = res.StatusCode;
                if (res.IsSuccessStatusCode)
                {
                    return StatusCode.ToString();
                }
                else
                {
                    return StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        // ใช้สำหรับ
        public async Task<IEnumerable<CategoryModel>> GetCategoryByCondition(CategoryModel cat)
        {
            IEnumerable<CategoryModel> data = null;
            var client = _initapi.Initial();
            try
            {
                if (cat == null)
                {
                    throw new ArgumentNullException(nameof(cat));
                }
                _condition.id = cat.CategoryID;
                _condition.Name = cat.CategoryName;
                _condition.Description = cat.Description;
                //var json = JsonConvert.SerializeObject(_condition);
                var encryptjson = EncryptDecryptService.encryptAes(JsonConvert.SerializeObject(_condition));
                _condition.clear();
                _condition.encrypt = encryptjson;
                var json = JsonConvert.SerializeObject(_condition);
                HttpContent c = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync(ConfigurationManager.AppSettings["ConditionApiUrl"], c);
                if (res.IsSuccessStatusCode)
                {
                    //var resulte = readdata.Content.ReadAsAsync<IList<CategoryModel>>();
                    var resulte = res.Content.ReadAsStringAsync().Result;
                    var condition = JsonConvert.DeserializeObject<ConditionModel>(resulte);
                    var decryptresulte = EncryptDecryptService.DecryptAes(condition.encrypt);
                    
                    data = JsonConvert.DeserializeObject<IEnumerable<CategoryModel>>(decryptresulte);
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}