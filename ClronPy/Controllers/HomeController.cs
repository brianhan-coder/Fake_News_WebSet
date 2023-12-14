using CIronPy.Common;
using CIronPy.Dto;
using CIronPy.Service.Interface;
using CsvHelper;
using IronPython.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Scripting.Hosting;
using System.Dynamic;
using static IronPython.Modules._ast;
using System.Globalization;
using static Community.CsharpSqlite.Sqlite3;
using System.Drawing.Imaging;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace CIronPy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserFile _userFile;
        private readonly IAdmin _admin;
        private readonly IDataEmbedding _dataEmbedding;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IUserFile userFile,IAdmin admin,IDataEmbedding dataEmbedding, IWebHostEnvironment webHostEnvironment) 
        {
            this._userFile = userFile;
            this._admin = admin;
            this._dataEmbedding = dataEmbedding;
            this._webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(AdminDto item)
        {
            dynamic obj = new ExpandoObject();
            obj.msg = -1;
            //var json = Model.ToString();
            if (string.IsNullOrEmpty(item.UserName) || string.IsNullOrEmpty(item.PassWord))
            {
                return Ok(obj);
            }
            if (item.UserName == "admin" && item.PassWord == "123")//a529514287
            {
                string token = Guid.NewGuid().ToString("N");
                CookieOptions option = new CookieOptions();
                option.Expires = System.DateTime.Now.AddHours(1);
                Response.Cookies.Append("clronpy", token, option);
                obj.msg = 1;
                obj.token = token;
            }


            return Ok(obj);
        }

        [HttpPost]
        [Route("PostFile")]
        public async Task<IActionResult> PostFile([FromForm] IFormCollection formCollection)
        {
            dynamic obj = new ExpandoObject();
            FormFileCollection fileCollection = (FormFileCollection)formCollection.Files;
            if(fileCollection.Count == 0)
            {
                obj.msg = "Upload data error";
            }
            var filename = string.Empty;
            var filepath = string.Empty;
            foreach (IFormFile file in fileCollection)
            {
                StreamReader reader = new StreamReader(file.OpenReadStream());
                var content = reader.ReadToEnd();
                filename = file.FileName;
                filepath = $"{_webHostEnvironment.WebRootPath}/Update/{filename}";
                if (System.IO.File.Exists(filepath))
                {
                    System.IO.File.Delete(filepath);
                }
                using (FileStream fs = System.IO.File.Create(filepath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            UserFileDto userdto = new UserFileDto();
            userdto.Id = IdGeneratorHelper.GetYitterNextId();
            userdto.Author = formCollection["author"];
            userdto.AccessLink = filepath;
            userdto.SubmitTime = System.DateTime.Now;

            if(_userFile.Add(userdto) > 0)
            {
                obj.mes = "Data added successfully";
            }
            else
            {
                obj.mes = "Data addition failed";
            }
            return Ok(obj);
        }

        [HttpPost]
        [Route("UserCreate")]
        public async Task<IActionResult> UserCreate([FromForm] IFormCollection formCollection)
        {
            dynamic obj = new ExpandoObject();
            FormFileCollection fileCollection = (FormFileCollection)formCollection.Files;
            if (fileCollection.Count == 0)
            {
                obj.msg = "Upload data error";
            }
            var filename = string.Empty;
            var filepath = string.Empty;
            foreach (IFormFile file in fileCollection)
            {
                StreamReader reader = new StreamReader(file.OpenReadStream());
                var content = reader.ReadToEnd();
                filename = file.FileName;
                filepath = $"{_webHostEnvironment.WebRootPath}/Update/{filename}";
                if (System.IO.File.Exists(filepath))
                {
                    System.IO.File.Delete(filepath);
                }
                using (FileStream fs = System.IO.File.Create(filepath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                UserFileDto userdto = new UserFileDto();
                userdto.Id = IdGeneratorHelper.GetYitterNextId();
                userdto.Uid = int.Parse(formCollection["uid"]);
                userdto.Author = formCollection["author"];
                userdto.Topic = formCollection["topic"];
                userdto.AccessLink = filepath;
                userdto.SubmitTime = System.DateTime.Now;

                if (_userFile.Add(userdto) > 0)
                {
                    obj.mes = "Data added successfully";
                }
                else
                {
                    obj.mes = "Data addition failed";
                }
            }
          
            return Ok(obj);
        }
        [HttpGet]
        [Route("UserView")]
        public async Task<IActionResult> UserView(string path)
        {
            dynamic obj = new ExpandoObject();
            var file = System.IO.File.ReadAllTextAsync(path);
            obj.data = file.Result.ToString();
            return Ok(obj);
        }

        [HttpGet]
        [Route("UserDelete")]
        public async Task<IActionResult> UserDelete(long id)
        {
            dynamic obj = new ExpandoObject();
            if (_userFile.Delete(id) > 0)
            {
                obj.mes = "Data delete successfully";
            }
            else
            {
                obj.mes = "Data delete failed";
            }
            return Ok(obj);
        }


        [HttpGet]
        [Route("GetUserList")]
        public async Task<IActionResult> GetUserList(int page = 1, int limit = 10,string? uid = "",string? author = "",string? submittime = "")
        {
            dynamic msg = new ExpandoObject();
            int total = 0;

            msg.data = _userFile.GetUserList(page, limit, ref total, uid, author, submittime);
            msg.code = 0;
            msg.count = total;
            return Ok(msg);
        }



        [HttpGet]
        [Route("GetAdminList")]
        public async Task<IActionResult> GetAdminList(int page= 1,int limit = 10)
        {
            dynamic msg = new ExpandoObject();
            int total = 0;
            msg.data = _admin.GetAdminList(page, limit,ref total);
            msg.code = 0;
            msg.count = total;
            return Ok(msg);
        }
        [HttpPost]
        [Route("AdminCreate")]
        public async Task<IActionResult> AdminCreate([FromForm] IFormCollection formCollection)
        {
            dynamic obj = new ExpandoObject();
            AdminDto admindto = new AdminDto();
            admindto.Id = IdGeneratorHelper.GetYitterNextId();
            admindto.UserName = formCollection["username"];
            admindto.PassWord = formCollection["password"];
            admindto.Status =0;
            admindto.SubmitTime = System.DateTime.Now;

            if (_admin.Add(admindto) > 0)
            {
                obj.mes = "Data added successfully";
            }
            else
            {
                obj.mes = "Data addition failed";
            }
            return Ok(obj);
        }
        [HttpPost]
        [Route("AdminEdit")]
        public async Task<IActionResult> AdminEdit([FromForm] IFormCollection formCollection)
        {
            dynamic obj = new ExpandoObject();
            AdminDto admindto = new AdminDto();
            admindto.Id = Convert.ToInt64(formCollection["id"]);
            admindto.UserName = formCollection["username"];
            admindto.PassWord = formCollection["password"];
            //admindto.Status = 0;
            //admindto.SubmitTime = DateTime.Now;

            if (_admin.Update(admindto) > 0)
            {
                obj.mes = "Data update successfully";
            }
            else
            {
                obj.mes = "Data update failed";
            }
            return Ok(obj);
        }
        [HttpGet]
        [Route("AdminDelete")]
        public async Task<IActionResult> AdminDelete(long id)
        {
            dynamic obj = new ExpandoObject();
            if (_admin.Delete(id) > 0)
            {
                obj.mes = "Data delete successfully";
            }
            else
            {
                obj.mes = "Data delete failed";
            }
            return Ok(obj);
        }
        [HttpPost]
        [Route("Import")]
        public async Task<IActionResult> Import()
        {
            dynamic obj = new ExpandoObject();
            string path = $"{_webHostEnvironment.WebRootPath}/Update/news_data_with_embeddings.csv";
            using (var reader = new StreamReader(path, Encoding.Default))
            {
                List<DataEmbeddingDto> list = new List<DataEmbeddingDto>();
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    while (csv.Read())
                    {
                        //var records = csv.GetRecords<DataEmbeddingDto>();
                        list = csv.GetRecords<DataEmbeddingDto>().ToList();
                    }
                   
                }
                try
                {
                    
                    _dataEmbedding.Add(list);
                    obj.mes = "Data Import successfully";
                }
                catch(Exception ex)
                {
                    obj.mes = "Data Import failed";
                }
               
                
            }


            return Ok(obj);
        }
        [HttpGet]
        [Route("GetDataEmbeddingList")]
        public async Task<IActionResult> GetDataEmbeddingList(int page = 1, int limit = 10, string? title = "", string? text = "")
        {
            dynamic msg = new ExpandoObject();
            int total = 0;
            msg.data = _dataEmbedding.GetDataEmbeddingList(page, limit, ref total,title,text);
            msg.code = 0;
            msg.count = total;
            return Ok(msg);
        }
        
        [HttpGet]
        [Route("DataEmbeddingDelete")]
        public async Task<IActionResult> DataEmbeddingDelete(long id)
        {
            dynamic obj = new ExpandoObject();
            if (_dataEmbedding.Delete(id) > 0)
            {
                obj.mes = "Data delete successfully";
            }
            else
            {
                obj.mes = "Data delete failed";
            }
            return Ok(obj);
        }



        [HttpGet]
        [Route("py")]
        public async Task<string> py()
        {
            ScriptEngine pyEngine = Python.CreateEngine();//创建Python解释器对象
            dynamic py = pyEngine.ExecuteFile(@"test.py");//读取脚本文件
            int[] array = new int[9] { 9, 3, 5, 7, 2, 1, 3, 6, 8 };
            string reStr = py.main(array);//调用脚本文件中对应的函数
            return reStr;
        }
    }
}
