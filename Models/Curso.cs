using System;

namespace TP11_Blaser_Garber.Models
{
    public class Curso
    {
       private int _IdCurso;
       private string _Nombre;
       private int _IdEspecialidad;
       private string _Descripcion;
       private string _Imagen;
       private string _UrlCurso;
       private int _MeGusta;
       private int _NoMeGusta;

       public int IdCurso{
           get{
               return _IdCurso;
           }
           set{
               _IdCurso=value;
           }
       } 
        public string Nombre{
           get{
               return _Nombre;
           }
           set{
               _Nombre=value;
           }
       } 
        public int IdEspecialidad{
           get{
               return _IdEspecialidad;
           }
           set{
               _IdEspecialidad=value;
           }
       } 
        public string Descripcion{
           get{
               return _Descripcion;
           }
           set{
               _Descripcion=value;
           }
       } 
        public string Imagen{
           get{
               return _Imagen;
           }
           set{
               _Imagen=value;
           }
       } 
        public string UrlCurso{
           get{
               return _UrlCurso;
           }
           set{
               _UrlCurso=value;
           }
       } 
       public int MeGusta{
           get{
               return _MeGusta;
           }
           set{
               _MeGusta=value;
           }
       }
       public int NoMeGusta{
           get{
               return _NoMeGusta;
           }
           set{
               _NoMeGusta=value;
           }
       }

       public Curso(){

       }  
    
        public Curso(int _IdCurso,string Nombre, int IdEspecialidad,string Descripcion,string Imagen,string UrlCurso, int MeGusta, int NoMeGusta){
            _IdCurso=IdCurso;
            _Nombre=Nombre;
            _IdEspecialidad=IdEspecialidad;
            _Descripcion=Descripcion;
            _Imagen=Imagen;
            _UrlCurso=UrlCurso;
            _MeGusta=MeGusta;
            _NoMeGusta=NoMeGusta;
       }  


    }
}


