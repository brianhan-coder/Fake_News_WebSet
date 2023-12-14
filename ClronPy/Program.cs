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
          
            //��ȡ�����ļ�
            IConfiguration _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //���ݿ��м��
            builder.Services.AddScoped(options =>
            {
                //�������ݿ�����
                return new SqlSugarClient(new List<ConnectionConfig>()
                {
                new ConnectionConfig() {
                ConnectionString = _config.GetConnectionString("DefaultConnection"),
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true
                }
                });
            });
            //Dto�м��
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
            options.DefaultFileNames.Add("index.html");    //��index.html��Ϊ��ҪĬ����ʼҳ���ļ���.
            app.UseDefaultFiles(options);


            app.UseAuthorization();


            app.MapControllers();
            app.UseStaticFiles();
            app.Run();
        }
    }
}