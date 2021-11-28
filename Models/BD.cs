using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace TP11_Blaser_Garber.Models
{
    public static class BD{
        private static string _connectionString=@"Server=A-CAM-07; DataBase=BDWebCursos; Trusted_Connection=True;";
         private static List<Curso> ListaCursos =new List<Curso>();
         private static List<Especialidad> ListaEspecialidades =new List<Especialidad>();

        public static Curso ConsultaCurso(int IdCurso){
            Curso MiCurso=null;
            string sql="SELECT * FROM Cursos WHERE IdCurso=@pCurso";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
               MiCurso=BD.QueryFirstOrDefault<Curso>(sql,new{pCurso=IdCurso});
            }
            return MiCurso;
        }      
        public static Especialidad ConsultaEspecialidad(int IdEspecialidad){
            Especialidad MiEspecialidad=null;
            string sql="SELECT * FROM Cursos WHERE IdEspecialidad=@pEspecialidad";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
               MiEspecialidad=BD.QueryFirstOrDefault<Especialidad>(sql,new{pEspecialidad=IdEspecialidad});
            }
            return MiEspecialidad;
        }  
        public static List<Curso> ListarCursos(int IdEspecialidad){
            if(IdEspecialidad==-1){
                string sql="SELECT * FROM Cursos";
                    using(SqlConnection BD=new SqlConnection(_connectionString)){
                        ListaCursos=BD.Query<Curso>(sql,new{pEspecialidad=IdEspecialidad}).ToList();
                    }
            }else{
                string sql="SELECT * FROM Cursos WHERE IdEspecialidad=@pEspecialidad";
                    using(SqlConnection BD=new SqlConnection(_connectionString)){
                        ListaCursos=BD.Query<Curso>(sql,new{pEspecialidad=IdEspecialidad}).ToList();
                    }
            }
            
            return ListaCursos;
        }
        public static void AgregarCurso(Curso MiCurso){
            string sql="INSERT INTO[Cursos](Nombre, Descripcion, Imagen, UrlCurso, MeGusta, NoMeGusta, IdEspecialidad) VALUES (@pNombre, @pDescripcion, @pImagen, @pUrlCurso, @pMeGusta, @pNoMeGusta, @pIdEspecialidad)";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
              BD.Execute(sql,new{pIdCurso=MiCurso.IdCurso, pNombre=MiCurso.Nombre, pDescripcion=MiCurso.Descripcion, pImagen=MiCurso.Imagen, pUrlCurso=MiCurso.UrlCurso, pMeGusta=MiCurso.MeGusta, pNoMeGusta=MiCurso.NoMeGusta, pIdEspecialidad=MiCurso.IdEspecialidad});
            }
        }  
        public static void CalificarCurso(int IdCurso, bool LeGusta){
            if(LeGusta){
                string sql="UPDATE Cursos SET MeGusta=MeGusta+1 WHERE IdCurso=@pIdCurso";
                using(SqlConnection BD=new SqlConnection(_connectionString)){
                        ListaCursos=BD.Query<Curso>(sql,new{pIdCurso=IdCurso}).ToList();
                    }
            }else{
                string sql="UPDATE Cursos SET NoMeGusta=NoMeGusta+1 WHERE IdCurso=@pIdCurso";
                using(SqlConnection BD=new SqlConnection(_connectionString)){
                    BD.Execute(sql,new{pIdCurso=IdCurso});
                }
            }            
            
        }
         public static List<Especialidad> ListarEspecialidades(){
            string sql="SELECT * FROM Especialidades";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
               ListaEspecialidades=BD.Query<Especialidad>(sql).ToList();
            }
            return ListaEspecialidades;
        }
    }
}
