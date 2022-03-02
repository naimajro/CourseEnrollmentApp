using Domain.Entities;
using Domain.Repositories;
using Newtonsoft.Json;
using Persistence;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class FileInitializerService
    {
       public static async Task SeedData(RepositoryDbContext repContext)
        {
            if(!repContext.Courses.Any())
            {
                string fileJSON = System.IO.File.ReadAllText("courses.json");
                List<FileModel> fileList = JsonConvert.DeserializeObject<List<FileModel>>(fileJSON);
                List<Course> courses = new List<Course>();
                List<Date> dates = new List<Date>();
                List<CourseAndDateRelation> cdrs = new List<CourseAndDateRelation>();

                foreach (var file in fileList)
                {
                    var courseId = ToGuid(file.Id);
                    courses.Add(new Course(){ Id = courseId,Name=file.Name });

                    foreach (var dateList in file.Dates)
                    {
                        var dateId = Guid.NewGuid();
                        var cdrId = Guid.NewGuid();
                        dates.Add(new Date() { Id = dateId, CourseDate = DateTime.Parse(dateList.ToString("MM/dd/yyyy HH:mm"))});
                        cdrs.Add(new CourseAndDateRelation() { Id = cdrId, CourseId = courseId, DateId = dateId });    
                    }
                }

                await repContext.Courses.AddRangeAsync(courses);
                await repContext.Dates.AddRangeAsync(dates);
                await repContext.CoursesAndDateRelations.AddRangeAsync(cdrs);
                await repContext.SaveChangesAsync();
            }
        }
        public static Guid ToGuid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
     


    }
}
