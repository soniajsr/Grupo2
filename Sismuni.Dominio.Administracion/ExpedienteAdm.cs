using Sismuni.Dominio.Negocio.Transparencia;
using Sismuni.Transversal.Injeccion;


namespace Sismuni.Dominio.Administracion
{
    public class ExpedienteAdm
    {
        private static ExpedienteAdm _expediente = null;

        public IGNTExpedienteNegocio ExpedienteNegocio { get { return Dependencia.Resolve<IGNTExpedienteNegocio>(); } }


        private ExpedienteAdm() { }

        public static ExpedienteAdm ObtenerServicio()
        {
            if (_expediente == null)
                _expediente = new ExpedienteAdm();
            return _expediente;
        }

    }
}
