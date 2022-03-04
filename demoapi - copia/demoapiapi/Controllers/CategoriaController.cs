using demoapi.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace demoapi.Controllers
{
    
        //config rutas
        [Route("api/[Controller]")]
        [ApiController]

        public class CategoriaController : ControllerBase
        {
            private readonly IConfiguration _configuration;
            public CategoriaController(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            [HttpGet]
            public JsonResult Get()
            {
                String query = @"SELECT Id,Nombre,Descripcion FROM Categoria";
                DataTable tabla = new DataTable();
                String sqlDataSource = _configuration.GetConnectionString(name: "ConAppEmpleado1");
                MySqlDataReader miReader;
                using (MySqlConnection miConnection = new MySqlConnection(sqlDataSource))
                {
                    miConnection.Open();
                    using (MySqlCommand miCommand = new MySqlCommand(query, miConnection))
                    {
                        miReader = miCommand.ExecuteReader();
                        tabla.Load(miReader);//inserto datos en tabla
                        miReader.Close();
                        miConnection.Close();
                    }

                }
                return new JsonResult(tabla);
            }
        
            [HttpPost]
            public JsonResult Post(Categoria dep)
            {
                String query = @"INSERT INTO categoria(Nombre,Descripcion) VALUES (@Nombre,@Descripcion)";
                
                String sqlDataSource = _configuration.GetConnectionString(name: "ConAppEmpleado1");
                MySqlDataReader miReader;
                using (MySqlConnection miConnection = new MySqlConnection(sqlDataSource))
                {
                    miConnection.Open();
                    using (MySqlCommand miCommand = new MySqlCommand(query, miConnection))
                    {
                        miCommand.Parameters.AddWithValue(parameterName: "@Nombre", dep.Nombre);
                        miCommand.Parameters.AddWithValue(parameterName: "@Descripcion", dep.Descripcion);
                        miReader = miCommand.ExecuteReader();
                        miReader.Close();
                        miConnection.Close();
                    }

                }
                return new JsonResult("Creado Exitosamente");
            }

            [HttpPut]
            public JsonResult Put(Categoria dep)
            {
                String query = @"UPDATE categoria SET Nombre=@Nombre Descripcion=@Descripcion WHERE Id=@Id";

                String sqlDataSource = _configuration.GetConnectionString(name: "ConAppEmpleado1");
                MySqlDataReader miReader;
                using (MySqlConnection miConnection = new MySqlConnection(sqlDataSource))
                {
                    miConnection.Open();
                    using (MySqlCommand miCommand = new MySqlCommand(query, miConnection))
                    {
                        miCommand.Parameters.AddWithValue(parameterName: "@Descripcion", dep.Descripcion);
                        miCommand.Parameters.AddWithValue(parameterName: "@Nombre", dep.Nombre);
                        miCommand.Parameters.AddWithValue(parameterName: "@Id", dep.Id);
                        miReader = miCommand.ExecuteReader();
                        miReader.Close();
                        miConnection.Close();
                    }

                }
                return new JsonResult("Modificado Exitosamente");
            }

            [HttpDelete ("{id}")]
            public JsonResult Delete(int id)
            {
                String query = @"DELETE FROM categoria WHERE Id=@Id";

                String sqlDataSource = _configuration.GetConnectionString(name: "ConAppEmpleado1");
                MySqlDataReader miReader;
                using (MySqlConnection miConnection = new MySqlConnection(sqlDataSource))
                {
                    miConnection.Open();
                    using (MySqlCommand miCommand = new MySqlCommand(query, miConnection))
                    {
                        miCommand.Parameters.AddWithValue(parameterName: "@Id", id);
                        miReader = miCommand.ExecuteReader();
                        miReader.Close();
                        miConnection.Close();
                    }

                }
                return new JsonResult("Eliminado Exitosamente");
            }

        }
    
}
