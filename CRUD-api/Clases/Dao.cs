using CRUD_api.Context;
using CRUD_api.Models.Local;

namespace CRUD_api.Clases
{
    public class Dao
    {
        public List<Producto> trearDatos()
        {
            try
            {
                using (TiendaContext db = new TiendaContext())
                {
                    return db.Productos.ToList();
                }
            }
            catch(Exception ) {
                throw;
            }
        }
        public  string insertar(Producto proc)
        {
            try
            {
                using (TiendaContext db = new TiendaContext())
                {
                    db.Productos.Add(proc);
                    db.SaveChanges();
                    return "ok";
                }
            }catch(Exception e) {
                throw e;
            }
        }

        public string eliminar(Producto id )
        {
            try
            {
                using (TiendaContext db = new TiendaContext())
                {
  
                    db.Productos.Remove(id);
                    db.SaveChanges();
                    return "ok";
                }
            }catch(Exception e) {
                throw e;
            }
        }
        public string actualizar(Producto id)
        {
            try
            {
                using (TiendaContext db = new TiendaContext())
                {

                    db.Productos.Update(id);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

