using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PrototipoOracleAPIFull.Models;
using PrototipoOracleAPIFull.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using PrototipoOracleAPIFull.Classes;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using Oracle.ManagedDataAccess.Client;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrototipoOracleAPIFull.Controllers
{
    [Route("api/region")]
    [ApiController]
    public class RegionController : ControllerBase
    {

        private readonly IConfiguration config;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IUrlHelper helper;

        public RegionController(IConfiguration config, IWebHostEnvironment hostEnvironment) 
        {
            this.config = config;
            this.hostEnvironment = hostEnvironment;
        }


        ////Listado de Regiones
        //[HttpGet]

        //public ActionResult GetRegion()
        //{
        //    try
        //    {
        //       using(ModelContext db = new ModelContext(config.GetConnectionString("Acceso"))) 
        //       {
        //            List<RegionDTO> response = db.Regions.Select(reg => new RegionDTO(reg)).ToList();
        //            if (response.Count == 0)
        //            {
        //                return NotFound(new Response()
        //                {
        //                    Data = response,
        //                    Errors = new List<Error>()
        //                    {
        //                        new Error()
        //                        {
        //                            Id = 1,
        //                            Status = "Not Found",
        //                            Code = 404 ,
        //                            Title = "No Data Found",
        //                            Detail = "There is no data on database"
        //                        }
        //                    }
        //                });
        //            }
        //            else
        //            {
        //                return Ok(new Response() { Data = response });
        //            }
        //       }
        //    }
        //    catch (System.Exception err)
        //    {
        //        Response response = new Response();
        //        response.Errors.Add(new Error()
        //        {
        //            Id = 1,
        //            Status = "Internal Server Error",
        //            Code = 500,
        //            Title = err.Message,
        //            Detail = err.InnerException != null ? err.InnerException.ToString() : err.Message
        //        });
        //        return StatusCode(500, response);
        //    }
        //}

        [HttpGet]
        public ActionResult GetRegion()
        {
            try
            {
                using (ModelContext db = new ModelContext(config.GetConnectionString("Acceso")))
                {
                    //List<RegionDTO> response = db.Regions.Select(reg => new RegionDTO(reg)).ToList();
                    //if (response.Count == 0)
                    //{
                    //    return NotFound(new Response()
                    //    {
                    //        Data = response,
                    //        Errors = new List<Error>()
                    //        {
                    //            new Error()
                    //            {
                    //                Id = 1,
                    //                Status = "Not Found",
                    //                Code = 404 ,
                    //                Title = "No Data Found",
                    //                Detail = "There is no data on database"
                    //            }
                    //        }
                    //    });
                    //}
                    //else
                    //{
                    //    return Ok(new Response() { Data = response });
                    //}
                    using (OracleConnection sql = new OracleConnection(config.GetConnectionString("Acceso")))
                    {
                        OracleDataAdapter objAdapter = new OracleDataAdapter();
                        OracleCommand objSelectCmd = new OracleCommand();
                        objSelectCmd.Connection = sql;
                        objSelectCmd.CommandText = "CRUDHR.GetRegion";
                        objSelectCmd.CommandType = CommandType.StoredProcedure;
                        objSelectCmd.Parameters.Add("cur_region", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        objAdapter.SelectCommand = objSelectCmd;

                        try
                        {
                            DataTable dtRegion = new DataTable();
                            List<Object> dtRegion2 = new List<Object>();
                            RegionDTO regionToAdd = new RegionDTO();
                            objAdapter.Fill(dtRegion);
                            

                            foreach (DataRow row in dtRegion.Rows)
                            {
                                dtRegion2.Add(new RegionDTO() { RegionId = (decimal)row["REGION_ID"], RegionName = row["REGION_NAME"].ToString() });
                            }
                            return Ok(new Response() { Data = dtRegion2 });

                        }
                        catch (Exception err)
                        {
                            Response response = new Response();
                            response.Errors.Add(new Error()
                            {
                                Id = 1,
                                Status = "Internal Server Error",
                                Code = 500,
                                Title = err.Message,
                                Detail = err.InnerException != null ? err.InnerException.ToString() : err.Message
                            });
                            return StatusCode(500, response);
                        }
                    }

                   
                }
            }
            catch (Exception err)
            {
                Response response = new Response();
                response.Errors.Add(new Error()
                {
                    Id = 1,
                    Status = "Internal Server Error",
                    Code = 500,
                    Title = err.Message,
                    Detail = err.InnerException != null ? err.InnerException.ToString() : err.Message
                });
                return StatusCode(500, response);
            }
        }



        // GET api/<RegionController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RegionController1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RegionController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegionController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
