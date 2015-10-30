using Sismuni.Dominio.Entidad.Seguridad;
using Sismuni.Infraestructura.Data.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.UnidadDeTrabajo
{
    public class ModeloUnidadDeTrabajo : UPC_MUNIEntities, IModeloUnidadDeTrabajo
    {
        public void Confirmar()
        {
            //Variables iniciales
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    SaveChanges();
                }
                catch (DbUpdateConcurrencyException duce)
                {
                    //Cuando ocurre un problema de concurrencia optimista
                    //No deberia ocurrir porque en la capa ya se usa DTOs
                    saveFailed = true;
                    try
                    {
                        foreach (var entidad in duce.Entries)
                        {
                            var obj = entidad.CurrentValues.Clone();
                            entidad.Reload();
                            entidad.CurrentValues.SetValues(obj);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        saveFailed = false;
                        //Revierte los cambios cuando ocurre errores no controlados
                        //due.Entries
                        RollbackEntries(ChangeTracker.Entries());
                        throw ex;
                    }

                }
                catch (DbUpdateException due)
                {
                    saveFailed = false;
                    //Revierte los cambios cuando ocurre errores no controlados
                    RollbackEntries(ChangeTracker.Entries());
                    throw due;

                }
            } while (saveFailed);
        }

        public void Confirmar(string idTransaccion, UsuarioVob usuario)
        {
            //Variables iniciales
            var activarAuditoria = true;
            //AUDITORIA auditoria = null;

            // Activando auditoria por transacción
            if (idTransaccion == null && usuario == null)
                activarAuditoria = false;

            // Inicializamos la auditoria
            //if (activarAuditoria)
            //{
            //    //Inicializamos el repositorio
            //    if (_auditoriaRepositorio == null) _auditoriaRepositorio = new AuditoriaRepositorio(this);
            //    if (_auditoriaDetalleRepositorio == null) _auditoriaDetalleRepositorio = new AuditoriaDetalleRepositorio(this);

            //    //Inicializamos la auditoria
            //    auditoria = new AUDITORIA();
            //    auditoria.ProcesaAgregar(idTransaccion, usuario.IdUsuario, usuario.IpCliente);
            //}

            //Guardar los cambios
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {

                    //if (activarAuditoria)
                    //  //  SaveChangesWithAudit(auditoria);
                    //else
                        SaveChanges();
                }
                catch (DbUpdateConcurrencyException duce)
                {
                    //Cuando ocurre un problema de concurrencia optimista
                    //No deberia ocurrir porque en la capa ya se usa DTOs
                    saveFailed = true;
                    try
                    {
                        foreach (var entidad in duce.Entries)
                        {
                            var obj = entidad.CurrentValues.Clone();
                            entidad.Reload();
                            entidad.CurrentValues.SetValues(obj);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        saveFailed = false;
                        //Revierte los cambios cuando ocurre errores no controlados
                        //due.Entries
                        RollbackEntries(ChangeTracker.Entries());
                        throw ex;
                    }

                }
                catch (DbUpdateException due)
                {
                    saveFailed = false;
                    //Revierte los cambios cuando ocurre errores no controlados
                    RollbackEntries(ChangeTracker.Entries());
                    throw due;

                }
            } while (saveFailed);

            //return auditoria.IdAuditoria;
        }

        private void RollbackEntries(IEnumerable<DbEntityEntry> entries)
        {
            foreach (var entidad in entries)
            {
                switch (entidad.State)
                {
                    case System.Data.Entity.EntityState.Modified:
                        entidad.State = System.Data.Entity.EntityState.Unchanged;
                        break;
                    case System.Data.Entity.EntityState.Deleted:
                        entidad.Reload();
                        break;
                    case System.Data.Entity.EntityState.Added:
                        entidad.State = System.Data.Entity.EntityState.Detached;
                        break;
                    default: break;
                }
            }
        }

        public void EnableDetectChange()
        {
            throw new System.NotImplementedException();
        }

        public void DisableDetectChange()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TEntidad> ExecuteStoreQuery<TEntidad>(string sqlQuery, params object[] parameters)
        {
            throw new System.NotImplementedException();
        }

        public int ExecuteStoreCommand(string sqlCommand, params object[] parameters)
        {
            throw new System.NotImplementedException();
        }

    }
}
