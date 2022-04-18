using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using EmployeeListProject.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using EmployeeListProject.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EmployeeListProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> Delete(int id)
        {
            var dbEmployee = await _context.Employees.FindAsync(id);
            if (dbEmployee == null) return BadRequest("Employee not found.");

            _context.Employees.Remove(dbEmployee);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }
        
        //private readonly IConfiguration _configuration;
        //private readonly IWebHostEnvironment _env;
        //public EmployeeController(IConfiguration configuration, IWebHostEnvironment env)
        //{
        //    _configuration = configuration;
        //    _env = env;
        //}


        //[HttpGet]
        //public JsonResult Get()
        //{
        //    string query = @"
        //                    select EmployeeId, EmployeeName
        //                    from
        //                    dbo.Employee
        //                    ";

        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("ConnectionString");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }

        //    return new JsonResult(table);
        //}

        //[HttpPost]
        //public JsonResult Post(Employee emp)
        //{
        //    string query = @"
        //                   insert into dbo.Employee
        //                   (EmployeeName)
        //            values (@EmployeeName)
        //                    ";

        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("ConnectionString");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myCommand.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName ?? (object)DBNull.Value);
                    

        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }

        //    return new JsonResult("Added Successfully");
        //}


        //[HttpPut]
        //public JsonResult Put(Employee emp)
        //{
        //    string query = @"
        //                   update dbo.Employee
        //                   set EmployeeName= @EmployeeName
        //                    where EmployeeId=@EmployeeId
        //                    ";

        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("ConnectionString");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myCommand.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
        //            myCommand.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }

        //    return new JsonResult("Updated Successfully");
        //}

        //[HttpDelete("{id}")]
        //public JsonResult Delete(int id)
        //{
        //    string query = @"
        //                   delete from dbo.Employee
        //                    where EmployeeId=@EmployeeId
        //                    ";

        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("ConnectionString");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myCommand.Parameters.AddWithValue("@EmployeeId", id);

        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }

        //    return new JsonResult("Deleted Successfully");
        //}


    }       
        
}
