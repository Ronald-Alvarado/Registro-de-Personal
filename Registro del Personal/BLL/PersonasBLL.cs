using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Registro_del_Personal.DAL;
using Registro_del_Personal.Entidades;

namespace Registro_del_Personal.BLL
{
    public class PersonasBLL
    {
        public static bool Guardar(Persona persona)
        {
            bool paso = false;
            Context db = new Context();

            try
            {
                if(db.Persona.Add(persona) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Persona persona)
        {
            bool paso = false;
            Context db = new Context();

            try
            {
                db.Entry(persona).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Context db = new Context();

            try
            {
                var eliminar = db.Persona.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Personas Buscar(int id)
        {
            Context db = new Context();
            Persona persona = new Persona();

            try
            {
                persona = db.Persona.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return persona;
        }

        public static List<Persona> GetList(Expression<Func<Persona, bool>> persona)
        {
            List<Persona> Lista = new List<Persona>();
            Context db = new Context();

            try
            {
                Lista = db.Persona.Where(persona).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return Lista;
        }
    }
}
