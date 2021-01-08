using MVC.Helper;
using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;


namespace MVC.Data
{
    public class ImpCategoryService : ICategoryService
    {
        private readonly InitApi _initapi;

        public ImpCategoryService(InitApi initapi)
        {
            _initapi = initapi;
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


    }
}