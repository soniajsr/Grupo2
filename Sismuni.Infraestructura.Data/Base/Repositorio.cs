using Sismuni.Dominio.Entidad.General;
using Sismuni.Infraestructura.Data.Recursos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Base
{
    public class Repositorio<TEntidad> : IRepositorio<TEntidad> where TEntidad : class
    {
        #region VARIABLES

        /// <summary>
        /// Unidad de trabajo con la que trabajará el repositorio
        /// </summary>
        private IConsultaUnidadDeTrabajo _unidadTrabajo;

        /// <summary>
        /// DbSet
        /// </summary>
        public DbSet<TEntidad> _dbEntidad;

        #endregion

        #region PROPIEDAES

        /// <summary>
        /// Implementado Unidad de Trabajo
        /// </summary>
        public IUnidadDeTrabajo UnidadDeTrabajo
        {
            get { return _unidadTrabajo; }
        }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Constructor por defecto del repositorio
        /// </summary>
        /// <param name="unidadTrabajo">Unidad de trabajo</param>
        public Repositorio(IConsultaUnidadDeTrabajo unidadTrabajo)
        {
            //Revisar pre-condición
            if (unidadTrabajo == (IUnidadDeTrabajo)null)
                throw new ArgumentNullException("unidadDeTrabajo", MensajesData.Excepcion_UTNoDebeSerNulo);

            //Insertando valor interno de unidad de trabajo
            _unidadTrabajo = unidadTrabajo;

            //db entity para administrar la entidad
            _dbEntidad = _unidadTrabajo.Set<TEntidad>();
        }

        #endregion

        #region MÉTODOS IMPLEMENTADOS

        /// <summary>
        /// Agregar entidad
        /// </summary>
        /// <param name="entidad">entidad</param>
        public void Agregar(TEntidad entidad)
        {
            //Revisar pre-condición
            if (entidad == (TEntidad)null)
                throw new ArgumentNullException("entidad", MensajesData.Excepcion_EntidadArgumentoNoSerNulo);

            //Agregado entidad a la unidad de trabajo
            DbEntityEntry dbEntrada = _unidadTrabajo.Entry<TEntidad>(entidad);
            if (dbEntrada.State != EntityState.Detached)
                dbEntrada.State = EntityState.Added;
            else
                _dbEntidad.Add(entidad);
        }

        /// <summary>
        /// Eliminar entidad
        /// </summary>
        /// <param name="entidad">entidad</param>
        public void Eliminar(TEntidad entidad)
        {
            //Revisar pre-condición
            if (entidad == (TEntidad)null)
                throw new ArgumentNullException("entidad", MensajesData.Excepcion_EntidadArgumentoNoSerNulo);

            //Agregado entidad a la unidad de trabajo
            DbEntityEntry dbEntrada = _unidadTrabajo.Entry<TEntidad>(entidad);
            if (dbEntrada.State != EntityState.Deleted)
                dbEntrada.State = EntityState.Deleted;
            else
            {
                _dbEntidad.Attach(entidad);
                _dbEntidad.Remove(entidad);
            }

        }

        /// <summary>
        /// Modificar entidad
        /// </summary>
        /// <param name="entidad">entidad</param>
        public void Modificar(TEntidad entidad, bool activarDeteccion = false)
        {
            //Revisar pre-condición
            if (entidad == (TEntidad)null)
                throw new ArgumentNullException("entidad", MensajesData.Excepcion_EntidadArgumentoNoSerNulo);
            try
            {
                //Detectando cambios en el EF, para sincronizar los cambios
                if (activarDeteccion) _unidadTrabajo.EnableDetectChange();

                //Modificando entidad a la unidad de trabajo
                DbEntityEntry dbEntrada = _unidadTrabajo.Entry<TEntidad>(entidad);
                if (dbEntrada.State == EntityState.Detached)
                    _dbEntidad.Attach(entidad);
                dbEntrada.State = EntityState.Modified;

                //Deshabilitando cambios en EF
                if (activarDeteccion) _unidadTrabajo.DisableDetectChange();
            }
            catch (Exception ex)
            {
                //Deshabilitando cambios en EF
                if (activarDeteccion) _unidadTrabajo.DisableDetectChange();
                throw ex;
            }

        }

        /// <summary>
        /// Agregar una lista de entidades
        /// </summary>
        /// <param name="entidades">entidades</param>
        public void AgregarRango(IEnumerable<TEntidad> entidades)
        {
            //Revisar pre-condición
            if (entidades == (IEnumerable<TEntidad>)null)
                throw new ArgumentNullException("entidades", MensajesData.Excepcion_EntidadArgumentoNoSerNulo);

            DbEntityEntry dbEntrada = null;

            foreach (var entidad in entidades)
            {
                dbEntrada = _unidadTrabajo.Entry<TEntidad>(entidad);
                if (dbEntrada.State != EntityState.Detached)
                    dbEntrada.State = EntityState.Added;
                else
                    _dbEntidad.Add(entidad);

            }
        }

        /// <summary>
        /// Eliminar una lista de entidades
        /// </summary>
        /// <param name="entidades">entidades</param>
        public void EliminarRango(IEnumerable<TEntidad> entidades)
        {
            //Revisar pre-condición
            if (entidades == (IEnumerable<TEntidad>)null)
                throw new ArgumentNullException("entidades", MensajesData.Excepcion_EntidadArgumentoNoSerNulo);

            DbEntityEntry dbEntrada = null;

            foreach (var entidad in entidades)
            {
                dbEntrada = _unidadTrabajo.Entry<TEntidad>(entidad);
                if (dbEntrada.State != EntityState.Deleted)
                    dbEntrada.State = EntityState.Deleted;
                else
                {
                    _dbEntidad.Attach(entidad);
                    _dbEntidad.Remove(entidad);
                }

            }
        }

        /// <summary>
        /// ListaPorCriterio sin Tracking
        /// </summary>
        /// <param name="criterio">Criterio</param>
        /// <returns>Entidadades</returns>
        public IEnumerable<TEntidad> ListarParaVer(ICriterio<TEntidad> criterio)
        {
            if (criterio == (ICriterio<TEntidad>)null)
                throw new ArgumentNullException("criterio");

            return _dbEntidad.Where(criterio.SatisfacePara()).AsNoTracking().AsEnumerable<TEntidad>();
        }


        /// <summary>
        /// ListarParaVerOrdenar
        /// </summary>
        /// <param name="criterio">Criterio</param>
        /// <returns>Entidadades</returns>
        public IEnumerable<TEntidad> ListarParaVerOrdenar(ICriterio<TEntidad> criterio, string orden, string ordenDir)
        {
            if (criterio == (ICriterio<TEntidad>)null)
                throw new ArgumentNullException("criterio");

            var consulta = _dbEntidad.Where(criterio.SatisfacePara());

            //// Aplicar ordenacion
            if (ordenDir == "ASC")
                consulta = consulta.OrderBy(orden);
            else
                consulta = consulta.OrderByDescending(orden);

            return consulta.AsNoTracking().AsEnumerable<TEntidad>();
        }

        /// <summary>
        /// ListaPorCriterio con tracking
        /// </summary>
        /// <param name="criterio">Criterio</param>
        /// <returns>Entidadades</returns>
        public IEnumerable<TEntidad> ListarParaEditar(ICriterio<TEntidad> criterio)
        {
            if (criterio == (ICriterio<TEntidad>)null)
                throw new ArgumentNullException("criterio");
            var lista = _dbEntidad.Where(criterio.SatisfacePara()).AsEnumerable<TEntidad>();
            return lista;
        }

        /// <summary>
        /// Obtener entidad por criterio con tracking
        /// </summary>
        /// <param name="criterio">criterio</param>
        /// <returns>Entidad</returns>
        public TEntidad EntidadParaVer(ICriterio<TEntidad> criterio)
        {
            if (criterio == (ICriterio<TEntidad>)null)
                throw new ArgumentNullException("criterio");

            return _dbEntidad.Where(criterio.SatisfacePara()).AsNoTracking().FirstOrDefault();
        }

        /// <summary>
        /// Obtener entidad por criterio con tracking
        /// </summary>
        /// <param name="criterio">criterio</param>
        /// <returns>Entidad</returns>
        public TEntidad EntidadParaEditar(ICriterio<TEntidad> criterio)
        {
            if (criterio == (ICriterio<TEntidad>)null)
                throw new ArgumentNullException("criterio");
            var entidad = _dbEntidad.Where(criterio.SatisfacePara()).FirstOrDefault();
            return entidad;
        }

        /// <summary>
        /// Contar criterio sin Tracking
        /// </summary>
        /// <param name="criterio">Criterio</param>
        /// <returns>Entidadades</returns>
        public int ContarPorCriterio(ICriterio<TEntidad> criterio)
        {
            if (criterio == (ICriterio<TEntidad>)null)
                throw new ArgumentNullException("criterio");

            return _dbEntidad.Where(criterio.SatisfacePara()).AsNoTracking().Count();
        }

        #endregion

        #region MÉTODO DE APOYO

        /// <summary>
        /// Obtiene la unidad de trabajo a partir del repositorio
        /// </summary>
        /// <typeparam name="T">Tipo de Unidad de Trabajo</typeparam>
        /// <param name="repositorio">Repositorio</param>
        /// <returns>Unidad de Trabajo</returns>
        internal static T ObtenerSet<T>(IRepositorio<TEntidad> repositorio)
            where T : class, IConsultaUnidadDeTrabajo
        {
            var set = repositorio.UnidadDeTrabajo as T;

            if (set == null)
                throw new InvalidOperationException(string.Format(
                                                                  CultureInfo.InvariantCulture,
                                                                  MensajesData.Excepcion_UTNoDebeSerNuloDeReportorio,
                                                                  repositorio.GetType().Name));

            return set;
        }

        /// <summary>
        /// Marca una entidad como modificado
        /// </summary>
        /// <param name="entidad">entidad</param>
        /// <returns>Se confirma el cambio de estado</returns>
        internal bool MarcadoComoModificado(TEntidad entidad)
        {
            DbEntityEntry dbEntrada = _unidadTrabajo.Entry<TEntidad>(entidad);
            if (dbEntrada.State != EntityState.Detached)
            {
                dbEntrada.State = EntityState.Modified;
                return true;
            }
            return false;
        }

        /// <summary>
        /// ListarPorCriterio
        /// </summary>
        /// <typeparam name="T">Tipo Vob</typeparam>
        /// <param name="consulta">consulta</param>
        /// <param name="criterio">criterio</param>
        /// <param name="indicePagina">indicePagina</param>
        /// <param name="tamanioPagina">tamanioPagina</param>
        /// <returns>Lista de Vob</returns>
        internal PaginadoVob<T> ListarPorCriterio<T>(IQueryable<T> consulta, ICriterio<T> criterio, int indicePagina, int tamanioPagina, string orden, string ordenDir) where T : class //Aqui poner si es necesario 
        {
            // Aplicar criterios
            if (criterio != null)
            {
                consulta = consulta.Where(criterio.SatisfacePara());
            }

            // Aplicar Conteo
            int totalElementos = consulta.Count();

            // Aplicar ordenacion
            if (ordenDir == "ASC")
                consulta = consulta.OrderBy(orden);
            else
                consulta = consulta.OrderByDescending(orden);

            IEnumerable<T> lista;
            if (tamanioPagina > 0)
            {
                lista = consulta
                        .Skip((indicePagina - 1) * tamanioPagina)
                        .Take(tamanioPagina)
                        .AsNoTracking()
                        .AsEnumerable();
            }
            else
            {
                lista = consulta.AsEnumerable();
            }

            return new PaginadoVob<T>(lista, totalElementos);
        }

        internal PaginadoVob<T> ListarPorCriterioOrdenado<T>(IQueryable<T> consulta, ICriterio<T> criterio, int indicePagina, int tamanioPagina, string orden, string ordenDir, string orden2) where T : class //Aqui poner si es necesario 
        {
            // Aplicar criterios
            if (criterio != null)
            {
                consulta = consulta.Where(criterio.SatisfacePara());
            }

            // Aplicar Conteo
            int totalElementos = consulta.Count();

            // Aplicar ordenacion

            if (orden2 == "")
            {
                if (ordenDir == "ASC")
                    consulta = consulta.OrderBy(orden);
                else
                    consulta = consulta.OrderByDescending(orden);
            }

            else
            {
                if (ordenDir == "ASC")
                    consulta = consulta.OrderBy(orden).ThenBy(orden2);
                else
                    consulta = consulta.OrderByDescending(orden).ThenBy(orden2);
            }


            IEnumerable<T> lista;
            if (tamanioPagina > 0)
            {
                lista = consulta
                        .Skip((indicePagina - 1) * tamanioPagina)
                        .Take(tamanioPagina)
                        .AsNoTracking()
                        .AsEnumerable();
            }
            else
            {
                lista = consulta.AsEnumerable();
            }

            return new PaginadoVob<T>(lista, totalElementos);
        }


        #endregion
    }
}
