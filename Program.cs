using CIronPy.Dto;
using CIronPy.Service.Implement;
using CIronPy.Service.Interface;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using SqlSugar;

namespace CIronPy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDistributedMemoryCache();
          
            //获取配置文件
            IConfiguration _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //数据库中间件
            builder.Services.AddScoped(options =>
            {
                //返回数据库链接
                return new SqlSugarClient(new List<ConnectionConfig>()
                {
                new ConnectionConfig() {
                ConnectionString = _config.GetConnectionString("DefaultConnection"),
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true
                }
                });
            });
            //Dto中间件
            builder.Services.AddAutoMapper(typeof(DtoProfile));
            builder.Services.AddScoped<IUserFile, UserFile>();
            builder.Services.AddScoped<IAdmin, Admin>();
            builder.Services.AddScoped<IDataEmbedding, DataEmbedding>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            // app.UseSwagger();
            //  app.UseSwaggerUI();
            //}
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");    //将index.html改为需要默认起始页的文件名.
            app.UseDefaultFiles(options);


            app.UseAuthorization();


            app.MapControllers();
            app.UseStaticFiles();
            app.Run();
        }
    }
}